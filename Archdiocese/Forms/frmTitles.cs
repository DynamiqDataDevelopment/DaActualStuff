using Archdiocese.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Archdiocese.Forms
{
    public partial class frmTitles : Form
    {
        public int _ID;
        public string _Description;
        public bool _isDeleted;
        public clsCollectionTypes_List _List = new clsCollectionTypes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString));
        public frmTitles()
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
            clsCollectionTypes_Item mcObject = new clsCollectionTypes_Item();
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
                var fc = Application.OpenForms["frmCollectionTypesView"];
                if (fc != null)
                {
                    fc.Close();
                    fc.Dispose();
                }
                //end of bad bad coding
                MessageBox.Show(Globals.gsSuccessMessage, "Success");
                frmCollectionTypesView frm = new frmCollectionTypesView();
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

        private clsCollectionTypes_Item prepareObject()
        {
            clsCollectionTypes_Item obj = new clsCollectionTypes_Item();
            obj.ID = _ID;
            obj.collectionTypeDescription = txtDescription.Text;

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
                MessageBox.Show(Globals.gsErrorMessage + System.Environment.NewLine + exResult.Message, "Failure");
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
                MessageBox.Show(Globals.gsErrorMessage + System.Environment.NewLine + exResult.Message, "Failure");
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
                frmCollectionTypesView frm = new frmCollectionTypesView();
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
