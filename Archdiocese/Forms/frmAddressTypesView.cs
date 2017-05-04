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
    public partial class frmAddressTypesView : Form
    {
        public frmAddressTypesView()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsAddressTypes_List _Data = new clsAddressTypes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, 0, String.Empty);
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error");
            }
            else
            {
                BindingSource _bindingSource = new BindingSource();
                _bindingSource.DataSource = _Data;
                grd.DataSource = _bindingSource;
                grd.Refresh();
                if (_Data.Count < 1)
                {
                    MessageBox.Show("No Types have been captured.", "Types");
                }
            }
        }

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAddressTypes frm = new frmAddressTypes();
            frm._ID = (int)grd.CurrentRow.Cells["ID"].Value;
            frm._Description = (string)grd.CurrentRow.Cells["Description"].Value;
            frm._isDeleted = (bool)grd.CurrentRow.Cells["isDeleted"].Value;

            frm.ShowDialog();
            //Dispose();
            //Close();
            LoadData();
        }

        private void frmJobTypesView_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}