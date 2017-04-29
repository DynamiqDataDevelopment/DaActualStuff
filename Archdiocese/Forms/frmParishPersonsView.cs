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
    public partial class frmParishPersonsView : Form
    {
        List<clsPersonParish_Item> Person_Data = new List<clsPersonParish_Item>();
        List<clsPersonParish_Item> Person_Data_Filtered = new List<clsPersonParish_Item>();
        public frmParishPersonsView()
        {
            InitializeComponent();
            MyInitializeComponent();
        }

        private void MyInitializeComponent()
        {
            LoadData();
        }

        private void LoadData()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsPersonParish_List _Data = new clsPersonParish_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, Globals.giParishID);
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

                Person_Data = _Data;
                if (_Data.Count < 1)
                {
                    MessageBox.Show("No data has been captured for " + Globals.gsParishName, "Persons");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            switch (cmbSearchBy.Text)
            {
                case "First Name":
                    Person_Data_Filtered = Person_Data.Where(i => i.firstName.Contains(txtSearchCriteria.Text)).Select(i => i).ToList();
                    break;
                case "Middle Name":
                    Person_Data_Filtered = Person_Data.Where(i => i.middleName.Contains(txtSearchCriteria.Text)).Select(i => i).ToList();
                    break;
                case "Surname":
                    Person_Data_Filtered = Person_Data.Where(i => i.surname.Contains(txtSearchCriteria.Text)).Select(i => i).ToList();
                    break;
                case "Email Address":
                    Person_Data_Filtered = Person_Data.Where(i => i.emailAddress.Contains(txtSearchCriteria.Text)).Select(i => i).ToList();
                    break;
                case "Telephone Number":
                    Person_Data_Filtered = Person_Data.Where(i => i.telephoneNumber.Contains(txtSearchCriteria.Text)).Select(i => i).ToList();
                    break;
            }

            //Person_Data_Filtered = Person_Data.Where(i => i.firstName.Equals(txtSearchCriteria.Text)).Select(i => i).ToList();
            BindingSource _bindingSource = new BindingSource();
            _bindingSource.DataSource = Person_Data_Filtered;
            grd.DataSource = _bindingSource;
            grd.Refresh();

            //addressinfo.Where(i => i.Value<string>("RiskType") == Constants.AttributeRiskTypes.ADR.ToString()).Select(i => i.Value<string>("CARDINALGUID")).FirstOrDefault();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BindingSource _bindingSource = new BindingSource();
            _bindingSource.DataSource = Person_Data;
            grd.DataSource = _bindingSource;
            grd.Refresh();

            cmbSearchBy.SelectedIndex = -1;
            txtSearchCriteria.Text = string.Empty;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (ValidateScreen())
            {
                Filter();
            }            
        }

        private bool ValidateScreen()
        {
            bool retVal = true;
            if (cmbSearchBy.SelectedIndex != -1)
            {
                if (txtSearchCriteria.Text == string.Empty) retVal = false;
            }  
            else
            {
                retVal = false;
            }          

            return retVal;
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
    }
}
