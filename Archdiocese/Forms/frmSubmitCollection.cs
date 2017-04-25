using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Archdiocese.Helpers;

namespace Archdiocese.Forms
{
    public partial class frmSubmitCollection : Form
    {
        public frmSubmitCollection()
        {
            InitializeComponent();
            MyInitializeComponent();
        }

        private void MyInitializeComponent()
        {
            cmbCollectionType.ToCollectionsTypeComboBox();
            cmbParishPersons.ToParishPersonsComboBox();
        }
        private void frmSubmitCollection_Load(object sender, EventArgs e)
        {
            //cmbCollectionType.ToCollectionsTypeComboBox();
            //cmbDateOfMass.Items.Add("15 January 2017");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Are you sure that" + Environment.NewLine + "you want to leave?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult == DialogResult.Yes)
            {
                Close();
                Dispose();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetControls();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateScreen())
            {
                Insert(PrepareObject());
                MessageBox.Show("Successfully added to the Database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetControls();
            }
            else
            {
                MessageBox.Show("Please fill out all the fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private clsCollections_Item PrepareObject()
        {
            clsCollections_Item obj = new clsCollections_Item();
            obj.parishUserID = Globals.giParishUserID;
            obj.amount = decimal.Parse(txtAmount.Text);
            obj.collectionTypeID = (int)cmbCollectionType.SelectedValue;
            obj.parishID = Globals.giParishID;
            obj.personID = (int)cmbParishPersons.SelectedValue;
            obj.collectionDateTime = dtpCollectionDate.Value;            
            return obj;
        }

        private void Insert(clsCollections_Item obj)
        {
            clsCollections_List _Data = new clsCollections_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString));
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data.Add_Item(ref exResult, obj);
            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message);
            }
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
    }
}
