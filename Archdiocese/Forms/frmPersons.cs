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
    public partial class frmPersons : Form
    {
        int miPersonID = 0;
        public frmPersons()
        {
            InitializeComponent();
            MyInitializeComponent();
        }

        private void MyInitializeComponent()
        {
            cmbGender.ToGendersComboBox();
            cmbMaritalStatus.ToMaritalStatuesComboBox();
            cmbPersonType.ToPersonTypesComboBox();
            cmbTitle.ToTitlesComboBox();
            cmbPledgeType.ToPledgeTypesComboBox();
        }

        private void Add_Person(clsPersons_Item obj)
        {
            clsPersons_List _Data = new clsPersons_List(Properties.Settings.Default.SqlConnectionString);
            Exception exResult = new Exception(Globals.gsExceptionString);
            int ID = _Data.Add_Item_ReturnID(ref exResult, obj);

            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + " " + exResult.Message);
            }
            else
            {
                miPersonID = ID;
                //add email address and ParishPerson record
                Add_EmailAddress(PrepareObject_EmailAddress());
                Add_Address(PrepareObject_Address());
                Add_TelephoneNumber(PrepareObject_TelephoneNumber());
                Add_ParishPerson(PrepareObject_ParishPerson());
                Add_ParishPersonPledge(PrepareObject_ParishPersonPledge());
                //change above to bool returning functions and then show success message
                MessageBox.Show("Successfully added to the Database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetControls();
            }
        }

        private void Add_EmailAddress(clsEmailAddresses_Item obj)
        {
            clsEmailAddresses_List _Data = new clsEmailAddresses_List(Properties.Settings.Default.SqlConnectionString);
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data.Add_Item(ref exResult, obj);
            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message);
            }
        }

        private void Add_Address(clsAddresses_Item obj)
        {
            clsAddresses_List _Data = new clsAddresses_List(Properties.Settings.Default.SqlConnectionString);
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data.Add_Item(ref exResult, obj);
            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message);
            }
        }

        private void Add_TelephoneNumber(clsTelephoneNumbers_Item obj)
        {
            clsTelephoneNumbers_List _Data = new clsTelephoneNumbers_List(Properties.Settings.Default.SqlConnectionString);
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data.Add_Item(ref exResult, obj);
            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message);
            }
        }

        private void Add_ParishPerson(clsParishPersons_Item obj)
        {
            clsParishPersons_List _Data = new clsParishPersons_List(Properties.Settings.Default.SqlConnectionString);
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data.Add_Item(ref exResult, obj);
            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message);
            }
        }

        private void Add_ParishPersonPledge(clsParishPersonPledges_Item obj)
        {
            clsParishPersonPledges_List _Data = new clsParishPersonPledges_List(Properties.Settings.Default.SqlConnectionString);
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data.Add_Item(ref exResult, obj);
            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message);
            }
        }
        private clsPersons_Item PrepareObject()
        {
            clsPersons_Item obj = new clsPersons_Item();
            obj.titleID = (int)cmbTitle.SelectedValue;
            obj.maritalStatusID = (int)cmbMaritalStatus.SelectedValue;
            obj.personTypeID = (int)cmbPersonType.SelectedValue;
            obj.genderID = (int)cmbGender.SelectedValue;
            obj.firstName = txtFirstName.Text;
            obj.middleName = txtMiddleName.Text;
            obj.surname = txtSurname.Text;
            obj.dateOfBirth = dtpDateOfBirth.Value;
            if (chkBaptised.Checked) obj.dateBaptised = dtpBaptised.Value; else obj.dateBaptised = DateTime.MinValue;
            if (chkConfirmed.Checked) obj.dateConfirmed = dtpConfirmed.Value; else obj.dateConfirmed = DateTime.MinValue;
            obj.ID = 0;//remove
            return obj;
        }

        private clsEmailAddresses_Item PrepareObject_EmailAddress()
        {
            clsEmailAddresses_Item obj = new clsEmailAddresses_Item();
            obj.emailAddress = txtEmailAddress.Text;
            obj.emailAddressTypeID = 1;//default
            obj.isDefault = true;
            obj.entityID = miPersonID;
            return obj;
        }

        private clsAddresses_Item PrepareObject_Address()
        {
            clsAddresses_Item obj = new clsAddresses_Item();
            obj.addressLine1 = txtAddressLine1.Text;
            obj.addressLine2 = txtAddressLine2.Text;
            obj.addressLine3 = txtAddressLine3.Text;
            obj.suburb = txtSuburb.Text;
            obj.city = txtCity.Text;
            obj.addressTypeID = 1;//default
            obj.entityID = miPersonID;
            return obj;
        }

        private clsTelephoneNumbers_Item PrepareObject_TelephoneNumber()
        {
            clsTelephoneNumbers_Item obj = new clsTelephoneNumbers_Item();
            obj.telephoneNumber = txtTelephoneNumber.Text;
            obj.telephoneNumberTypeID = 1;//default
            obj.entityID = miPersonID;
            return obj;
        }

        private clsParishPersons_Item PrepareObject_ParishPerson()
        {
            clsParishPersons_Item obj = new clsParishPersons_Item();
            obj.parishID = Globals.giParishID;
            obj.personID = miPersonID;//default
            obj.joinedDate = dtpJoinedDate.Value;
            return obj;
        }

        private clsParishPersonPledges_Item PrepareObject_ParishPersonPledge()
        {
            clsParishPersonPledges_Item obj = new clsParishPersonPledges_Item();
            obj.personID = miPersonID;
            obj.parishID = Globals.giParishID;
            obj.pledgeYear = 2017;//must change
            obj.amount = decimal.Parse(txtPledgeAmount.Text);///CHANGE TO txtPledgeAmount
            obj.pledgeTypeID = (int)cmbPledgeType.SelectedValue;
            return obj;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateScreen())
            {
                Add_Person(PrepareObject());
            }
            else
            {
                MessageBox.Show("Please fill out all the fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Are you sure that" + Environment.NewLine + "you want to leave?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult == DialogResult.Yes)
            {
                Close();
                Dispose();
            }
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.LightBlue;
        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.LightBlue;
        }

        private void btnCancel_MouseHover(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.LightBlue;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Control.DefaultBackColor;
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.BackColor = Control.DefaultBackColor;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Control.DefaultBackColor;
        }

        private void chkBaptised_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBaptised.Checked)
            {
                dtpBaptised.Visible = true;
            }
            else
            {
                dtpBaptised.Visible = false;
            }
        }

        private void chkConfirmed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConfirmed.Checked)
            {
                dtpConfirmed.Visible = true;
            }
            else
            {
                dtpConfirmed.Visible = false;
            }
        }
    }
}
