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
    public partial class frmExpenses : Form
    {
        public frmExpenses()
        {
            InitializeComponent();
            MyInitializeComponent();
        }

        private void MyInitializeComponent()
        {
            cmbAccountingLevel3.ToExpenseTypesLevel3ComboBox();
        }

        private void Add_Expense(clsExpenses_Item obj)
        {
            clsExpenses_List _Data = new clsExpenses_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString));
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data.Add_Item(ref exResult, PrepareObject());

            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + " " + exResult.Message);
            }
            else
            {
                MessageBox.Show(Globals.gsSuccessMessage);
            }
        }

        private clsExpenses_Item PrepareObject()
        {
            clsExpenses_Item obj = new clsExpenses_Item();
            obj.expenseTypeID = (int)cmbAccountingLevel3.SelectedValue;
            obj.amount = decimal.Parse(txtAmount.Text);
            obj.description = txtDescription.Text;
            obj.expenseDate = dtpExpenseDate.Value.Date;
            obj.parishUserID = Globals.giParishUserID;
            return obj;
        }

        private void btnSave_Click(object sender, EventArgs e)
        { 
            if (ValidateScreen())
            {
                Add_Expense(PrepareObject());
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
            dtpExpenseDate.Value = DateTime.Today;
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
