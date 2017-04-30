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

            //addressinfo.Where(i => i.Value<string>("RiskType") == Constants.AttributeRiskTypes.ADR.ToString()).Select(i => i.Value<string>("CARDINALint")).FirstOrDefault();
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

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Call_PersonsForm();
        }

        private void Call_PersonsForm()
        {
            frmPersons frm = new frmPersons();
            frm.miPersonID = (int)grd.CurrentRow.Cells["personID"].Value;
            frm._title = (string)grd.CurrentRow.Cells["title"].Value;
            frm._titleID = (int)grd.CurrentRow.Cells["titleID"].Value;
            frm._firstName = (string)grd.CurrentRow.Cells["firstName"].Value;
            frm._middleName = (string)grd.CurrentRow.Cells["middleName"].Value;
            frm._surname = (string)grd.CurrentRow.Cells["surname"].Value;
            frm._emailAddress = (string)grd.CurrentRow.Cells["emailAddress"].Value;
            frm._telephoneNumber = (string)grd.CurrentRow.Cells["telephoneNumber"].Value;
            frm._pledgeTypeID = (int)grd.CurrentRow.Cells["pledgeTypeID"].Value;
            frm._pledgeAmount = (decimal)grd.CurrentRow.Cells["pledgeAmount"].Value;
            frm._maritalStatusID = (int)grd.CurrentRow.Cells["maritalStatusID"].Value;
            frm._genderID = (int)grd.CurrentRow.Cells["genderID"].Value;
            frm._personTypeID = (int)grd.CurrentRow.Cells["personTypeID"].Value;
            frm._dateOfBirth = (DateTime)grd.CurrentRow.Cells["dateOfBirth"].Value;
            frm._dateJoined = (DateTime)grd.CurrentRow.Cells["joinedDate"].Value;
            frm._dateBaptised = (DateTime)grd.CurrentRow.Cells["dateBaptised"].Value;
            frm._dateConfirmed = (DateTime)grd.CurrentRow.Cells["dateConfirmed"].Value;
            frm._addressLine1 = (string)grd.CurrentRow.Cells["addressLine1"].Value;
            frm._addressLine2 = (string)grd.CurrentRow.Cells["addressLine2"].Value;
            frm._addressLine3 = (string)grd.CurrentRow.Cells["addressLine3"].Value;
            frm._suburb = (string)grd.CurrentRow.Cells["suburb"].Value;
            frm._city = (string)grd.CurrentRow.Cells["city"].Value;
            frm._postalCode = (string)grd.CurrentRow.Cells["postalCode"].Value;

            frm._update = true;

            Form MainForm = GetMainForm();

            frm.MdiParent = MainForm;
            frm.Size = MainForm.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            this.Close();
            this.Dispose();
        }

        private Form GetMainForm()
        {
            Form frm = new Form();
            var moOpenForms = Application.OpenForms;
            try
            {
                foreach (Form form in moOpenForms)
                {
                    if (form.Name == "frmMain")
                    {
                        frm = form;
                        break;
                    }
                }
                return frm;
            }
            catch (Exception)
            {
                //ignore, OpenForms will change and throw an exception but i don't care
                //throw;
                return frm;
            }
        }
    }
}
