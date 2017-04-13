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
    public partial class frmUserGroups : Form
    {
        public int _ID;
        public string _userGroupDescription;
        public static clsUserGroups_List gcUserGroup_List = new clsUserGroups_List(Archdiocese.Properties.Settings.Default.SqlConnectionString);

        public frmUserGroups()
        {
            InitializeComponent();
        }

        private void populateWithValues()
        {
            if (_ID != 0)
            {
                btnClear.Text = "Delete";
                txtUserGroupDescription.Text = _userGroupDescription; ;
            }
            else
            {
                btnClear.Text = "Clear";
            }
        }
        private void Save()
        {
            clsUserGroups_Item mcUserGroup = new clsUserGroups_Item();
            mcUserGroup = prepareObject();
            Exception exResult = new Exception(Globals.gsExceptionString);
            bool mbSuccess = false;
            if (_ID != 0)
            {
                mbSuccess = gcUserGroup_List.Update_Item(ref exResult, mcUserGroup);
            }
            else
            {
                mbSuccess = gcUserGroup_List.Add_Item(ref exResult, mcUserGroup);
            }

            if (mbSuccess)
            {
                //bad bad coding
                var fc = Application.OpenForms["frmUserGroupsView"];
                if (fc != null)
                {
                    fc.Close();
                    fc.Dispose();
                }
                //end of bad bad coding
                MessageBox.Show("Successfully saved to the database.", "Success");
                frmUserGroupsView frm = new frmUserGroupsView();
                frm.MdiParent = Application.OpenForms["frmMain"];
                frm.Size = Application.OpenForms["frmMain"].Size;
                frm.WindowState = FormWindowState.Maximized;

                btnCancel_Click(null, null);
                frm.Show();
            }
            else
            {
                MessageBox.Show(exResult.Message, "Input Error");
            }
        }

        private clsUserGroups_Item prepareObject()
        {
            clsUserGroups_Item obj = new clsUserGroups_Item();
            obj.ID = _ID;
            obj.userGroupName = txtUserGroupDescription.Text;

            return obj;
        }

        private void Delete()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            bool mbSuccess = false;
            mbSuccess = gcUserGroup_List.Delete_Item(ref exResult, _ID);
            if (mbSuccess)
            {
                MessageBox.Show("Successfully deleted.", "Success");
                btnCancel_Click(null, null);
            }
            else
            {
                MessageBox.Show("Oops something went wrong. The system generated error message is:" + System.Environment.NewLine + exResult.Message, "Delete Failure");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_ID != 0)
            {
                Delete();
            }
            else
            {
                txtUserGroupDescription.Text = string.Empty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void frmUserGroups_Load(object sender, EventArgs e)
        {
            populateWithValues();
        }
    }
}