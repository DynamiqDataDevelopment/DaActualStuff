using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Archdiocese.Helpers;

namespace Archdiocese.Forms
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Are you sure that" + Environment.NewLine + "you want to leave?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult == DialogResult.Yes)
            {
                Close();
                Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateScreen())
            {
                if (ValidatePassword())
                {
                    if (ValidateNewPassword())
                    {
                        ChangePassword(Globals.giUserID, Globals.EncryptString(txtCurrentPassword.Text), Globals.EncryptString(txtNewPassword.Text));
                    }
                    else
                    {
                        MessageBox.Show("New Password does not match Confirm Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                }
                else
                {
                    MessageBox.Show("Current Password is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please fill out all the fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidatePassword()
        {
            bool retVal = true;
            if (!(Globals.EncryptString(txtCurrentPassword.Text).Equals(Globals.gsEncryptedPassword))) retVal = false;
            return retVal;
        }

        private bool ValidateNewPassword()
        {
            bool retVal = true;
            if (!(txtNewPassword.Text.Equals(txtConfirmNewPassword.Text))) retVal = false;
            return retVal;
        }

        private void ChangePassword(int ID, string currentPassword, string newPassword)
        {
            clsUsers_List _Data = new clsUsers_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString));
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data.ChangePassword(ref exResult, Globals.giUserID, Globals.EncryptString(txtCurrentPassword.Text), Globals.EncryptString(txtNewPassword.Text));
            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + " " + exResult.Message);
            }
            else
            {
                //change above to bool returning functions and then show success message
                MessageBox.Show("Password Successfully Changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
        }

        private bool ValidateScreen()
        {
            bool retVal = true;
            foreach (Control C in this.Controls)
            {
                if (C.GetType() == typeof(TextBox))
                {
                    if (C.Tag.ToString() == "Mandatory")
                    {
                        if (C.Text == string.Empty)
                        {
                            retVal = false;
                            break;
                        }
                    }
                }
            }

            return retVal;
        }

        private void btnViewPasswords_Click(object sender, EventArgs e)
        {
            foreach (Control C in this.Controls)
            {
                if (C.GetType() == typeof(TextBox))
                {
                    ((TextBox)C).UseSystemPasswordChar = false;

                }
            }
        }
    }
}
