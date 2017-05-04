using Archdiocese.Helpers;
using System;
using System.Windows.Forms;

namespace Archdiocese.Forms
{
    public partial class frmTelephoneNumberTypesView : Form
    {
        public frmTelephoneNumberTypesView()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsTelephoneNumberTypes_List _Data = new clsTelephoneNumberTypes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, 0, String.Empty);
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
            frmTelephoneNumberTypes frm = new frmTelephoneNumberTypes();
            frm._ID = (int)grd.CurrentRow.Cells["ID"].Value;
            frm._Description = (string)grd.CurrentRow.Cells["Description"].Value;
            frm._isDeleted = (bool)grd.CurrentRow.Cells["isDeleted"].Value;

            frm.ShowDialog();
            LoadData();
        }

        private void frmJobTypesView_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
