using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Archdiocese.Helpers;
using System.Globalization;

namespace Archdiocese.Forms
{
    public partial class frmAccountingInput : Form
    {
        private List<clsIncomeTypesLevel3_Item> _IncomeTypesLevel3_Data;
        private List<clsExpenseTypesLevel3_Item> _ExpenseTypesLevel3_Data;
        private List<clsIncomeTypesLevel3_Item> _IncomeTypesLevel3_Data_Filtered;
        private List<clsExpenseTypesLevel3_Item> _ExpenseTypesLevel3_Data_Filtered;
        public frmAccountingInput()
        {
            InitializeComponent();
            MyInitializeComponent();
        }

        private void MyInitializeComponent()
        {
            PopulateExpenseAccountNumbers();
            PopulateIncomeAccountNumbers();
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
            clsValidation_Item obj = new clsValidation_Item();
            obj = ValidateScreen();
            if (obj.returnStatus)
            {
                Save();
            }
            else
            {
                MessageBox.Show(obj.returnMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private clsValidation_Item ValidateScreen()
        {
            int RowCount = 0;
            if (grd.Rows.Count == 1) RowCount = grd.Rows.Count; else RowCount = grd.Rows.Count - 1;
            //MessageBox.Show("Please fill out all the fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            bool retVal = true;
            string retMessage = string.Empty;
            for (int i = 0; i < RowCount; i++)
            {
                //Type
                if (grd.Rows[i].Cells["type"].Value.ToString().ToUpper().Equals("I") | grd.Rows[i].Cells["type"].Value.ToString().ToUpper().Equals("E"))
                {
                    //can't get the ! operand right, no time to mess with it
                }
                else
                {
                    retVal = false;
                    retMessage = "Type needs to be I or E";
                    break;
                }
                //Date
                if (grd.Rows[i].Cells["date"].Value != null)
                {
                    try
                    {
                        DateTime dateValue;
                        bool isValidDate = DateTime.TryParseExact(grd.Rows[i].Cells["date"].Value.ToString(), "dd/MM/yyyy", null, DateTimeStyles.None,out dateValue);
                        if (!isValidDate)
                        {
                            retVal = false;
                            retMessage = grd.Rows[i].Cells["date"].Value.ToString() + " is in the incorrect format";
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        retVal = false;
                        retMessage = grd.Rows[i].Cells["date"].Value.ToString() + " is in the incorrect format";
                        break;
                    }
                }
                else
                {
                    retVal = false;
                    retMessage = "Date field is empty";
                    break;
                }

                //Account Number
                if (grd.Rows[i].Cells["accountNumber"].Value != null)
                {
                    if (grd.Rows[i].Cells["type"].Value.ToString().ToUpper() == "E")
                    {
                        _ExpenseTypesLevel3_Data_Filtered = _ExpenseTypesLevel3_Data.Where(x => x.accountNumber == grd.Rows[i].Cells["accountNumber"].Value.ToString()).ToList();
                        if (_ExpenseTypesLevel3_Data_Filtered.Count == 0)
                        {
                            retVal = false;
                            retMessage = "Account Number " + grd.Rows[i].Cells["accountNumber"].Value.ToString() + " does not exist";
                            break;
                        }
                    }
                    if (grd.Rows[i].Cells["type"].Value.ToString().ToUpper() == "I")
                    {
                        _IncomeTypesLevel3_Data_Filtered = _IncomeTypesLevel3_Data.Where(x => x.accountNumber == grd.Rows[i].Cells["accountNumber"].Value.ToString()).ToList();
                        if (_IncomeTypesLevel3_Data_Filtered.Count == 0)
                        {
                            retVal = false;
                            retMessage = "Account Number " + grd.Rows[i].Cells["accountNumber"].Value.ToString() + " does not exist";
                            break;
                        }
                    }
                }
                else
                {
                    retVal = false;
                    retMessage = "Account Number field is blank";
                    break;
                }
            }
            clsValidation_Item obj = new clsValidation_Item(retVal, retMessage);
            return obj;
        }

        private int Get_IncomeTypesLevel3ID(string accountNumber)
        {
            int retVal = 0;
            retVal = _IncomeTypesLevel3_Data.Where(x => x.accountNumber == accountNumber).Select(x => x.ID).FirstOrDefault();
            return retVal;
        }

        private int Get_ExpenseTypesLevel3ID(string accountNumber)
        {
            int retVal = 0;
            retVal = _ExpenseTypesLevel3_Data.Where(x => x.accountNumber == accountNumber).Select(x => x.ID).FirstOrDefault();
            return retVal;
        }
        private void Save()
        {
            bool canExit = true;
            clsIncomes_List _data = new clsIncomes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString));
            clsExpenses_List _dataExpenses = new clsExpenses_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString));
            for (int i = 0; i < grd.Rows.Count; i++)
            {
                if (grd.Rows[i].Cells["date"].Value != null)
                {
                    if (grd.Rows[i].Cells["type"].Value.ToString().ToUpper() == "I")
                    {
                        clsIncomes_Item obj = new clsIncomes_Item();
                        obj.description = grd.Rows[i].Cells["description"].Value.ToString();
                        obj.incomeDate = DateTime.ParseExact(grd.Rows[i].Cells["date"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        obj.incomeTypeID = Get_IncomeTypesLevel3ID( grd.Rows[i].Cells["accountNumber"].Value.ToString());
                        obj.amount = decimal.Parse(grd.Rows[i].Cells["amount"].Value.ToString());
                        obj.parishUserID = Globals.giParishUserID;
                        _data.Add(obj);
                    }
                    else
                    {
                        clsExpenses_Item obj = new clsExpenses_Item();
                        obj.description = grd.Rows[i].Cells["description"].Value.ToString();
                        obj.expenseDate = DateTime.ParseExact(grd.Rows[i].Cells["date"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        obj.expenseTypeID = Get_ExpenseTypesLevel3ID(grd.Rows[i].Cells["accountNumber"].Value.ToString());
                        obj.amount = decimal.Parse(grd.Rows[i].Cells["amount"].Value.ToString());
                        obj.parishUserID = Globals.giParishUserID;
                        _dataExpenses.Add(obj);
                    }
                }
            }

            foreach (clsIncomes_Item item in _data)
            {
                Exception exResult = new Exception("SUCCESS");
                _data.Add_Item(ref exResult, item);
                if (exResult.Message != "SUCCESS")
                {
                    MessageBox.Show(exResult.Message);
                    canExit = false;
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
                    canExit = false;
                }
                else
                {
                    //MessageBox.Show("yay Expense");
                }
            }

            if (canExit)
            {
                MessageBox.Show(Globals.gsSuccessMessage, Globals.gsSuccessCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
        }

        private void PopulateIncomeAccountNumbers()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsIncomeTypesLevel3_List Data = new clsIncomeTypesLevel3_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult);

            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _IncomeTypesLevel3_Data = Data;
            }
        }

        private void PopulateExpenseAccountNumbers()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsExpenseTypesLevel3_List Data = new clsExpenseTypesLevel3_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult);

            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _ExpenseTypesLevel3_Data = Data;
            }
        }
    }
}
