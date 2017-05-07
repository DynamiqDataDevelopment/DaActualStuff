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
    public partial class frmAccountingInput : Form
    {
        public frmAccountingInput()
        {
            InitializeComponent();
        }

        private void grd_SelectionChanged(object sender, EventArgs e)
        {
            if (grd.Rows[grd.CurrentCell.RowIndex].Cells["type"].Value != null)
            {
                if (grd.Rows[grd.CurrentCell.RowIndex].Cells["type"].Value.ToString() == "E")
                {
                    grd.Rows[grd.CurrentCell.RowIndex].Cells["amount"].Style.ForeColor = Color.Red;
                }
                else
                {
                    grd.Rows[grd.CurrentCell.RowIndex].Cells["amount"].Style.ForeColor = DefaultForeColor;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            clsIncomes_List _data = new clsIncomes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString));
            clsExpenses_List _dataExpenses = new clsExpenses_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString));
            for (int i = 0; i < grd.Rows.Count; i++)
            {
                if (grd.Rows[i].Cells["date"].Value != null)
                {
                    if (grd.Rows[i].Cells["type"].Value.ToString() == "Income")
                    {
                        clsIncomes_Item obj = new clsIncomes_Item();
                        obj.description = grd.Rows[i].Cells["description"].Value.ToString();
                        obj.incomeDate = DateTime.Parse(grd.Rows[i].Cells["date"].Value.ToString());
                        obj.incomeTypeID = (int)grd.Rows[i].Cells["accountNumber"].Value;
                        obj.amount = decimal.Parse(grd.Rows[i].Cells["amount"].Value.ToString());
                        obj.parishUserID = Globals.giParishUserID;
                        _data.Add(obj);
                    }
                    else
                    {
                        clsExpenses_Item obj = new clsExpenses_Item();
                        obj.description = grd.Rows[i].Cells["description"].Value.ToString();
                        obj.expenseDate = DateTime.Parse(grd.Rows[i].Cells["date"].Value.ToString());
                        obj.expenseTypeID = (int)grd.Rows[i].Cells["accountNumber"].Value;
                        obj.amount = decimal.Parse(grd.Rows[i].Cells["amount"].Value.ToString());
                        obj.parishUserID = Globals.giParishUserID;
                        _dataExpenses.Add(obj);
                    }
                }
            }

            MessageBox.Show(_data.Count.ToString());
            foreach (clsIncomes_Item item in _data)
            {
                Exception exResult = new Exception("SUCCESS");
                _data.Add_Item(ref exResult, item);
                if (exResult.Message != "SUCCESS")
                {
                    MessageBox.Show(exResult.Message);
                }
                else
                {
                    //MessageBox.Show("yay");
                }
            }

            foreach (clsExpenses_Item item in _dataExpenses)
            {
                Exception exResult = new Exception("SUCCESS");
                _dataExpenses.Add_Item(ref exResult, item);
                if (exResult.Message != "SUCCESS")
                {
                    MessageBox.Show(exResult.Message);
                }
                else
                {
                    //MessageBox.Show("yay Expense");
                }
            }
        }
    }
}
