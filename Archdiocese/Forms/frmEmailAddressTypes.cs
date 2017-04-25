using Archdiocese.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Archdiocese.Forms
{
    public partial class frmEmailAddressTypes : Form
    {
        public int _ID;
        public string _Description;
        public bool _isDeleted;
        public clsEmailAddressTypes_List _List = new clsEmailAddressTypes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString));
        public frmEmailAddressTypes()
        {
            InitializeComponent();
        }

        private void populateWithValues()
        {
            if (_ID != 0)
            {
                if (_isDeleted)
                {
                    btnSave.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                }
                btnClear.Text = _isDeleted ? "Enable" : "Disable";
                txtDescription.Text = _Description;
            }
            else
            {
                btnClear.Text = "Clear";
            }
        }
        private void Save()
        {
            clsEmailAddressTypes_Item mcObject = new clsEmailAddressTypes_Item();
            mcObject = prepareObject();
            Exception exResult = new Exception(Globals.gsExceptionString);
            bool mbSuccess = false;
            if (_ID != 0)
            {
                mbSuccess = _List.Update_Item(ref exResult, mcObject);
            }
            else
            {
                mbSuccess = _List.Add_Item(ref exResult, mcObject);
            }

            if (mbSuccess)
            {
                //bad bad coding
                var fc = Application.OpenForms["frmEmailAddressTypesView"];
                if (fc != null)
                {
                    fc.Close();
                    fc.Dispose();
                }
                //end of bad bad coding
                MessageBox.Show("Successfully saved to the database.", "Success");
                frmEmailAddressTypesView frm = new frmEmailAddressTypesView();
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

        private clsEmailAddressTypes_Item prepareObject()
        {
            clsEmailAddressTypes_Item obj = new clsEmailAddressTypes_Item();
            obj.ID = _ID;
            obj.description = txtDescription.Text;

            return obj;
        }

        private void Disable()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            bool mbSuccess = false;
            mbSuccess = _List.Enable_Item(ref exResult, _ID, false);
            if (mbSuccess)
            {
                MessageBox.Show("Successfully disabled.", "Success");
                btnCancel_Click(null, null);
            }
            else
            {
                MessageBox.Show("Oops something went wrong. The system generated error message is:" + System.Environment.NewLine + exResult.Message, "Failure");
            }
        }

        private void Enable()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            bool mbSuccess = false;
            mbSuccess = _List.Enable_Item(ref exResult, _ID, true);
            if (mbSuccess)
            {
                MessageBox.Show("Successfully Enabled.", "Success");
                btnCancel_Click(null, null);
            }
            else
            {
                MessageBox.Show("Oops something went wrong. The system generated error message is:" + System.Environment.NewLine + exResult.Message, "Failure");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OpenView();
            this.Close();
            this.Dispose();
        }

        private void OpenView()
        {
            var mfForm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "frmMain").FirstOrDefault();
            if (_ID != 0)
            {
                frmEmailAddressTypesView frm = new frmEmailAddressTypesView();
                frm.MdiParent = mfForm;
                frm.Size = mfForm.Size;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_ID != 0)
            {
                EnableOrDisable();
            }
            else
            {
                txtDescription.Text = string.Empty;
            }
        }

        private void EnableOrDisable()
        {
            if (_isDeleted) { Enable(); } else { Disable(); }
        }
        private void frm_Load(object sender, EventArgs e)
        {
            populateWithValues();
        }
    }
}
