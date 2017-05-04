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
    public partial class frmEmailAddressTypesView : Form
    {
        public frmEmailAddressTypesView()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsEmailAddressTypes_List _Data = new clsEmailAddressTypes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, 0, String.Empty);
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
            frmEmailAddressTypes frm = new frmEmailAddressTypes();
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
