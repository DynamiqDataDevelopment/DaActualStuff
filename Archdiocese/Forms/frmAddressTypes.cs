using Archdiocese.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Archdiocese.Forms
{
    public partial class frmAddressTypes : Form
    {
        public int _ID;
        public string _Description;
        public bool _isDeleted;
        public clsAddressTypes_List _List = new clsAddressTypes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString));
        public frmAddressTypes()
        {
            InitializeComponent();
        }

        #region Specific Data Methods

        private void Save()
        {
            clsAddressTypes_Item mcObject = new clsAddressTypes_Item();
            mcObject = PrepareObject();
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
                MessageBox.Show(Globals.gsSuccessMessage, Globals.gsSuccessCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Cancel();
            }
            else
            {
                MessageBox.Show(Globals.gsErrorMessage + System.Environment.NewLine + exResult.Message, Globals.gsErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private clsAddressTypes_Item PrepareObject()
        {
            clsAddressTypes_Item obj = new clsAddressTypes_Item();
            obj.ID = _ID;
            obj.description = txtDescription.Text;
            return obj;
        }

        #endregion Specific Data Methods

        #region Generic Methods
        private void PopulateWithValues()
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

        private void Disable()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            bool mbSuccess = false;
            mbSuccess = _List.Enable_Item(ref exResult, _ID, false);
            if (mbSuccess)
            {
                MessageBox.Show(Globals.gsDisabledSuccessMessage, Globals.gsSuccessCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Cancel();
            }
            else
            {
                MessageBox.Show(Globals.gsErrorMessage + System.Environment.NewLine + exResult.Message, Globals.gsErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Enable()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            bool mbSuccess = false;
            mbSuccess = _List.Enable_Item(ref exResult, _ID, true);
            if (mbSuccess)
            {
                MessageBox.Show(Globals.gsEnabledSuccessMessage, Globals.gsSuccessCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Cancel();
            }
            else
            {
                MessageBox.Show(Globals.gsErrorMessage + System.Environment.NewLine + exResult.Message, Globals.gsErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableOrDisable()
        {
            if (_isDeleted) { Enable(); } else { Disable(); }
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

        private void Cancel()
        {
            Close();
            Dispose();
        }

        #endregion Generic Methods

        #region Event Handler Methods
        private void Click_Save()
        {
            if (ValidateScreen())
            {
                Save();
            }
            else
            {
                MessageBox.Show(Globals.gsFieldsValidationMessage, Globals.gsWarningCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Click_Clear()
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

        private void Click_Cancel()
        {
            DialogResult dlgResult = MessageBox.Show(Globals.gsCancelButtonQuestion, Globals.gsCancelButtonCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult == DialogResult.Yes)
            {
                Cancel();
            }
        }

        #endregion Event Handler Methods

        #region Event Handlers

        private void frm_Load(object sender, EventArgs e)
        {
            PopulateWithValues();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Click_Save();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Click_Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Click_Cancel();
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.LightBlue;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Control.DefaultBackColor;
        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.LightBlue;
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.BackColor = Control.DefaultBackColor;
        }

        #endregion Event Handlers
    }
}
