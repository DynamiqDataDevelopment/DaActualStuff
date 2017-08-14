using Archdiocese.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Archdiocese.Forms
{
    public partial class frmAccountingView : Form
    {
        public frmAccountingView()
        {
            InitializeComponent();
        }

        private void CalculateTotal(List<clsAccounting_Item> RawData)
        {
            decimal expenseTotal = 0;
            decimal incomeTotal = 0;
            decimal Total = 0;

            for (int i = 0; i < RawData.Count; i++)
            {
                if (RawData[i].Type == "Income")
                {
                    incomeTotal += RawData[i].amount;
                }
                else
                {
                    expenseTotal += RawData[i].amount;
                }
            }
            Total = incomeTotal - expenseTotal;
            //MessageBox.Show(incomeTotal.ToString());
            lblIncomeTotal.Text = "Total Income: " + incomeTotal.ToString("C");
            //MessageBox.Show(expenseTotal.ToString());
            lblExpenseTotal.Text = "Total Expense: " + expenseTotal.ToString("C");
            //MessageBox.Show(Total.ToString());
            lblTotal.Text = "Total: " + Total.ToString("C");

            if (Total < 0)
            {
                lblTotal.ForeColor = Color.Red;
            }
            else
            {
                lblTotal.ForeColor = Color.Green;
            }
        }
        private void LoadData()
        {
            if (ValidateDates())
            {
                Exception exResult = new Exception(Globals.gsExceptionString);
                clsAccounting_List _Data = new clsAccounting_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, Globals.giParishID, dtpFrom.Value, dtpTo.Value, txtAccountNumber.Text, txtDescription.Text);
                if (!(exResult.Message == Globals.gsExceptionString))
                {
                    MessageBox.Show(Globals.gsErrorMessage + exResult.Message, Globals.gsErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    BindingSource _bindingSource = new BindingSource();
                    _bindingSource.DataSource = _Data;
                    grd.DataSource = _bindingSource;
                    grd.Refresh();
                    if (_Data.Count < 1)
                    {
                        MessageBox.Show("No Data has been captured.", "Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    CalculateTotal(_Data);
                }
            }
            else
            {
                MessageBox.Show("Date From cannot be greater than Date To", Globals.gsWarningCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidateDates()
        {
            bool retVal = true;
            if (dtpFrom.Value > dtpTo.Value) retVal = false;
            return retVal;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }
        private void ClearScreen()
        {
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            grd.DataSource = new List<clsAccounting_Item>();
            grd.Refresh();
            lblExpenseTotal.Text = "Total Expense: R 0.00";
            lblIncomeTotal.Text = "Total Income: R 0.00";
            lblTotal.Text = "Total: R 0.00";
        }

        private void chkAccountNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAccountNumber.Checked)
            {
                txtAccountNumber.Enabled = true;
            }
            else
            {
                txtAccountNumber.Enabled = false;
            }
        }

        private void chkDescription_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDescription.Checked)
            {
                txtDescription.Enabled = true;
            }
            else
            {
                txtDescription.Enabled = false;
            }
        }
    }
}
