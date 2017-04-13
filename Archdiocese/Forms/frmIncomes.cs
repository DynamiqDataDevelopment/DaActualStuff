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
    public partial class frmIncomes : Form
    {
        public frmIncomes()
        {
            InitializeComponent();
            MyInitializeComponent();
        }

        private void MyInitializeComponent()
        {
            cmbAccountingLevel3.ToIncomeTypesLevel3ComboBox();
        }

        private void Add_Income(clsIncomes_Item obj)
        {
            clsIncomes_List _Data = new clsIncomes_List(Properties.Settings.Default.SqlConnectionString);
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data.Add_Item(ref exResult, obj);

            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + " " + exResult.Message);
            }
            else
            {
                MessageBox.Show(Globals.gsSuccessMessage);
            }
        }

        private clsIncomes_Item PrepareObject()
        {
            clsIncomes_Item obj = new clsIncomes_Item();
            obj.incomeTypeID = (int)cmbAccountingLevel3.SelectedValue;
            obj.amount = float.Parse(txtAmount.Text);
            obj.description = txtDescription.Text;
            obj.incomeDate = dtpDate.Value.Date;
            obj.parishUserID = Globals.giParishUserID;
            return obj;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateScreen())
            {
                Add_Income(PrepareObject());
            }
            else
            {
                MessageBox.Show("Please fill out all the fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
        private void ResetControls()
        {
            cmbAccountingLevel3.SelectedIndex = -1;
            txtAmount.Text = string.Empty;
            txtDescription.Text = string.Empty;
            dtpDate.Value = DateTime.Today;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Are you sure that you went to leave?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult == DialogResult.Yes)
            {
                Close();
                Dispose();
            }
        }

        private bool ValidateScreen()
        {
            bool retVal = false;
            if (cmbAccountingLevel3.SelectedIndex == -1 | txtAmount.Text == string.Empty | txtDescription.Text == string.Empty)
            {
                retVal = false;
            }
            else
            {
                retVal = true;
            }

            return retVal;
        }
    }
}
