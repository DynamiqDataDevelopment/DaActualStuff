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
    public partial class frmPaymentRequests : Form
    {
        public frmPaymentRequests()
        {
            InitializeComponent();
            MyInitializeComponent();
        }

        private void MyInitializeComponent()
        {
            cmbBankBranchCode.ToBankBranchCodesComboBox();
            cmbRequester.ToParishPersonsComboBox();
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

        private clsPaymentRequests_Item PrepareObject()
        {
            clsPaymentRequests_Item obj = new clsPaymentRequests_Item();
            obj.actionDate = dtpActionDate.Value;
            obj.branchCodeID = (int)cmbBankBranchCode.SelectedValue;
            obj.fromAccountNumber = txtFromAccountNumber.Text;
            obj.toAccountNumber = txtToAccountNumber.Text;
            obj.recipientName = txtRecipientReference.Text;
            obj.requesterPersonID = (int)cmbRequester.SelectedValue;
            obj.parishUserID = Globals.giParishUserID;
            obj.ID = 0;//remove
            return obj;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateScreen())
            {
                Add_PaymentRequest(PrepareObject());
            }
            else
            {
                MessageBox.Show("Please fill out all the fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Add_PaymentRequest(clsPaymentRequests_Item obj)
        {
            clsPaymentRequests_List _Data = new clsPaymentRequests_List(Properties.Settings.Default.SqlConnectionString);
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data.Add_Item(ref exResult, obj);

            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + " " + exResult.Message);
            }
            else
            {
                MessageBox.Show("Successfully added to the Database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetControls();
            }
        }
    }
}
