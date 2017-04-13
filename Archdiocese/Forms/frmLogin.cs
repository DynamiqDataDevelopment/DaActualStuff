using Archdiocese.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archdiocese.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            txtUsername.Focus();
        }
        
        private bool ValidateUsernameAndPassword()
        {
            bool retVal = true;
            if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                retVal = false;
            }
            return retVal;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateUsernameAndPassword())
            {
                if (cmbParish.Visible == false)
                {
                    btnLogin.Enabled = false;
                    CheckUsernameAndPassword();
                }
                else
                {
                    if (cmbParish.SelectedIndex != -1)
                    {
                        SetParishUserID();
                        //SetStatusBar();
                        this.Close();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Please select a Parish", "Error");
                    }
                }
            }
            
        }

        private void SetParishUserID()
        {
            if (Globals.giParishID != 0 & Globals.giUserID != 0)
            {
                Exception exResult = new Exception(Globals.gsExceptionString);
                clsParishUsers_List _Data = new clsParishUsers_List(Archdiocese.Properties.Settings.Default.SqlConnectionString, ref exResult, 0, Globals.giParishID, Globals.giUserID);
                if (!(exResult.Message == Globals.gsExceptionString))
                {
                    MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error");
                }
                else
                {
                    if (_Data.Count < 1)
                    {
                        MessageBox.Show("Oops something went wrong. Please contact your System Administrator", "Error");
                        btnLogin.Enabled = true;
                    }
                    else
                    {
                        Globals.giParishUserID = _Data[0].ID;
                    }
                }
            }
        }
        private void CheckUsernameAndPassword()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsUsersVerify_List _Data = new clsUsersVerify_List(Archdiocese.Properties.Settings.Default.SqlConnectionString, ref exResult, txtUsername.Text, txtPassword.Text);
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error");
                btnLogin.Enabled = true;
            }
            else
            {
                if (_Data.Count < 1)
                {
                    MessageBox.Show("The username and password entered are incorrect", "Login Error");
                    btnLogin.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Username and Password Verified." + System.Environment.NewLine + "Please select the Parish and click Continue", "User Verified");
                    btnLogin.Text = "Continue";
                    Globals.giUserID = _Data[0].ID;
                    Globals.gsUserName = _Data[0].username;
                    Globals.gsPermissionString = _Data[0].userGroupPermissionString;
                    PopulateParishes();
                    cmbParish.Visible = true;
                    lblParish.Visible = true;
                    btnLogin.Enabled = true;
                    cmbParish.Focus();
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;
                }
            }
        }

        private void PopulateParishes()
        {
            cmbParish.ToUserLoginParishComboBox();
        }

        private void cmbParish_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbParish.SelectedIndex != -1)
            {
                Globals.giParishID = (int)cmbParish.SelectedValue;
                Globals.gsParishName = cmbParish.Text;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        private void SetStatusBar()
        {
            var moOpenForms = Application.OpenForms;
            try
            {
                foreach (Form form in moOpenForms)
                {
                    if (form.Name == "frmMain")
                    {
                        form.Controls["tsslParish"].Text = Globals.gsUserName;
                        form.Controls["tsslUser"].Text = Globals.gsUserName;
                    }
                }
            }
            catch (Exception ex)
            {
                //ignore, OpenForms will change and throw an exception but i don't care
                throw ex;
            }
        }
    }
}
