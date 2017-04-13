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
    public partial class frmUserGroupsView : Form
    {
        public frmUserGroupsView()
        {
            InitializeComponent();
        }

        private void LoadUserGroups()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsUserGroups_List UserGroup_Data = new clsUserGroups_List(Archdiocese.Properties.Settings.Default.SqlConnectionString, ref exResult, 0, string.Empty, string.Empty);
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving User Groups");
            }
            else
            {
                BindingSource _bindingSource = new BindingSource();
                _bindingSource.DataSource = UserGroup_Data;
                grdUserGroups.DataSource = _bindingSource;
                grdUserGroups.Refresh();
                if (UserGroup_Data.Count < 1)
                {

                    MessageBox.Show("No User Groups have been captured.", "User Groups");
                }
            }
        }

        private void frmUserGroupsView_Load(object sender, EventArgs e)
        {
            LoadUserGroups();
        }

        private void grdUserGroups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUserGroups frm = new frmUserGroups();
            frm._ID = (int)grdUserGroups.CurrentRow.Cells["ID"].Value;
            frm._userGroupDescription = (string)grdUserGroups.CurrentRow.Cells["userGroupDescription"].Value;
         
            frm.Show();
            //this.Dispose();
        }
    }
}
