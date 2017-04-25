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
    public partial class frmUsers : Form
    {
        public int miUserID = 0;
        public frmUsers()
        {
            InitializeComponent();
            MyInitializeComponent();
        }

        private void MyInitializeComponent()
        {
            cmbUserGroup.ToUserGroupsComboBox();
        }
        #region Standard Procedures
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
                if (C.GetType() == typeof(ComboBox))
                {
                    var Ctrl = (ComboBox)C;
                    if (Ctrl.SelectedIndex == -1)
                    {
                        retVal = false;
                        break;
                    }
                }
            }

            return retVal;
        }

        private void ResetControls()
        {
            foreach (Control C in this.Controls)
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

        private void Call_Cancel()
        {
            DialogResult dlgResult = MessageBox.Show("Are you sure that" + Environment.NewLine + "you want to leave?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult == DialogResult.Yes)
            {
                Close();
                Dispose();
            }
        }

        #endregion Standard Procedures

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Call_Cancel();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateScreen())
            {
                Add_User(PrepareObject());
            }
            else
            {
                MessageBox.Show("Please fill out all the fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private clsUsers_Item PrepareObject()
        {
            clsUsers_Item obj = new clsUsers_Item();
            obj.username = txtUsername.Text;
            obj.password = Globals.EncryptString(txtPassword.Text);
            obj.userGroupID = (int)cmbUserGroup.SelectedValue;
            return obj;
        }
        private bool Add_User(clsUsers_Item obj)
        {
            bool retVal = true;
            clsUsers_List _Data = new clsUsers_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString));
            Exception exResult = new Exception(Globals.gsExceptionString);
            int ID = _Data.Add_Item_ReturnID(ref exResult, obj);

            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + " " + exResult.Message);
            }
            else
            {
                miUserID = ID;
                //add email address and ParishPerson record
                Add_ParishUser(PrepareObject_ParishUser());
                //change above to bool returning functions and then show success message
                MessageBox.Show("Successfully added to the Database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetControls();
            }

            return retVal;
        }
        private clsParishUsers_Item PrepareObject_ParishUser()
        {
            clsParishUsers_Item obj = new clsParishUsers_Item();
            obj.userID = miUserID;
            obj.parishID = Globals.giParishID;
            return obj;
        }

        private void Add_ParishUser(clsParishUsers_Item obj)
        {
            clsParishUsers_List _Data = new clsParishUsers_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString));
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data.Add_Item(ref exResult, obj);

            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + " " + exResult.Message);
            }
            else
            {
                //MessageBox.Show("Successfully added to the Database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetControls();
            }
        }
    }
}
