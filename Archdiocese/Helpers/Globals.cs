using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;

namespace Archdiocese.Helpers
{
    internal static class Globals
    {
        public const string gsExceptionString = "SUCCESS!";
        public static string gsSuccessMessage = "Successfully saved to the Database";
        public static string gsErrorMessage = "An error has occurred in the application. " + Environment.NewLine + "The actual error message is:" + Environment.NewLine;
        public static string gsSuccessCaption = "Success";
        public static string gsErrorCaption = "Error";
        public static string gsWarningCaption = "Warning";
        public static string gsDisabledSuccessMessage = "Successfully Disabled";
        public static string gsEnabledSuccessMessage = "Successfully Enabled";
        public static string gsCancelButtonQuestion = "Are you sure that" + Environment.NewLine + "you want to leave?";
        public static string gsCancelButtonCaption = "";
        public static string gsFieldsValidationMessage = "Please fill out all the fields";
        public static int giUserID = 0;
        public static int giParishUserID = 0;
        public static int giParishID = 0;
        public static string gsParishName = string.Empty;
        public static string gsUserName = String.Empty;
        public static string gsPermissionString = String.Empty;
        public static string gsEncryptedPassword = string.Empty;
        public static clsUsers_Item gcUser;

        public static string EncryptString(string psText)
        {
            try
            {
                TripleDESCryptoServiceProvider crp = new TripleDESCryptoServiceProvider();
                UnicodeEncoding uEncode = new UnicodeEncoding();
                byte[] bytPlainText = uEncode.GetBytes(psText);
                MemoryStream stmCipherText = new MemoryStream();
                byte[] slt = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes("D10Lync", slt);
                byte[] bytDerivedKey = pdb.GetBytes(24);
                crp.Key = bytDerivedKey;
                crp.IV = pdb.GetBytes(8);
                CryptoStream csEncrypted = new CryptoStream(stmCipherText, crp.CreateEncryptor(), CryptoStreamMode.Write);
                csEncrypted.Write(bytPlainText, 0, bytPlainText.Length);
                csEncrypted.FlushFinalBlock();
                return Convert.ToBase64String(stmCipherText.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string DecryptString(string psText)
        {
            //Decrypt text
            TripleDESCryptoServiceProvider crp = null;
            string retVal = string.Empty;
            try
            {
                crp = new TripleDESCryptoServiceProvider();
                UnicodeEncoding uEncode = new UnicodeEncoding();
                byte[] bytCipherText = Convert.FromBase64String(psText);
                MemoryStream stmPlainText = new MemoryStream();
                MemoryStream stmCipherText = new MemoryStream(bytCipherText);
                byte[] slt = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes("D10Lync", slt);
                byte[] bytDerivedKey = pdb.GetBytes(24);
                crp.Key = bytDerivedKey;
                crp.IV = pdb.GetBytes(8);
                CryptoStream csDecrypted = new CryptoStream(stmCipherText, crp.CreateDecryptor(), CryptoStreamMode.Read);
                StreamWriter sw = new StreamWriter(stmPlainText);
                StreamReader sr = new StreamReader(csDecrypted);
                sw.Write(sr.ReadToEnd());
                sw.Flush();
                csDecrypted.Clear();
                crp.Clear();
                retVal = uEncode.GetString(stmPlainText.ToArray());
            }
            catch (Exception)
            {
                MessageBox.Show("Error decrypting.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return retVal;
        }

        //re-look at these functions and clean it up later so that 1 function is called
        public static string RemoveSpecialCharacters(string Text)
        {
            StringBuilder _stringBuilder = new StringBuilder();
            foreach (char chr in Text)
            {
                if ((chr >= '0' && chr <= '9') || (chr >= 'A' && chr <= 'Z') || (chr >= 'a' && chr <= 'z') || chr == '.' || chr == '_')
                {
                    _stringBuilder.Append(chr);
                }
            }
            return _stringBuilder.ToString();
        }

        public static string RemoveNonNumericCharacters(string Text)
        {
            StringBuilder _stringBuilder = new StringBuilder();
            foreach (char chr in Text)
            {
                if ((chr >= '0' && chr <= '9'))
                {
                    _stringBuilder.Append(chr);
                }
            }
            return _stringBuilder.ToString();
        }

        public static void GetUserDetails(string psUsername, string psPassword)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsUsers_List User_Data = new clsUsers_List(Globals.DecryptString(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString)), ref exResult, 0, psUsername, psPassword, 0);
            //User_Data_Filtered = User_Data;
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Users");
                Application.Exit();
                Environment.Exit(0);
            }
            else
            {
                if (User_Data.Count > 0)
                {

                    foreach (clsUsers_Item item in User_Data)
                    {
                        Globals.giUserID = item.ID;
                        gcUser = item;
                    }
                }
                else
                {
                    MessageBox.Show("You are not authorised to use this application.\r\nPlease contact your System Administrator.", "Login Error");
                    Application.Exit();
                    Environment.Exit(0);
                }
            }
        }

        public static void ResetControls(ref Control.ControlCollection Controls)
        {
            foreach (Control C in Controls)
            {
                if (C.GetType() == typeof(TextBox))
                {
                    C.Text = string.Empty;
                }
                if (C.GetType() == typeof(ComboBox))
                {
                    var Ctrl = (ComboBox)C;
                    Ctrl.SelectedIndex = -1;
                }
                if (C.GetType() == typeof(DateTimePicker))
                {
                    var Ctrl = (DateTimePicker)C;
                    Ctrl.Value = DateTime.Today;
                }

            }
        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            //Jarred Work of Art
            //buttonOk.Enabled = false; //create a fucking handler for this
            //end of Jarred Work of Art

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

    }
}
