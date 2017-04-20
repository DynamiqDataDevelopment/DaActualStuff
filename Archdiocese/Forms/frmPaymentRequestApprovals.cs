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
    public partial class frmPaymentRequestApprovals : Form
    {
        public frmPaymentRequestApprovals()
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
            clsPaymentRequestsNew_List _Data = new clsPaymentRequestsNew_List(Archdiocese.Properties.Settings.Default.SqlConnectionString, ref exResult, 0, String.Empty, String.Empty, String.Empty, 0, 0, 0, DateTime.MinValue, DateTime.MinValue);
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
                if (_Data.Count < 1)
                {
                    MessageBox.Show("No Requests Need Approval", "Payment Approvals");
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (ValidateScreen())
            {
                Add_PaymentApproval(PrepareObject());
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (ValidateScreen())
            {
                string rejectionReason = string.Empty;
                DialogResult dr = Globals.InputBox("Rejection Reason", "Please provide a reason as to why you are rejecting the request.", ref rejectionReason);

                //string input = Microsoft.VisualBasic.Interaction.InputBox("Title", "Prompt", "Default", 0, 0);
                //if (input != string.Empty)
                if (dr == DialogResult.OK)
                {
                    if (rejectionReason != string.Empty)
                        Add_PaymentApproval(PrepareObject(false, rejectionReason));
                }
                
            }
        }

        private void Add_PaymentApproval(clsPaymentApprovals_Item obj)
        {
            clsPaymentApprovals_List _Data = new clsPaymentApprovals_List(Properties.Settings.Default.SqlConnectionString);
            Exception exResult = new Exception(Globals.gsExceptionString);
            _Data.Add_Item(ref exResult, obj);

            if (exResult.Message != Globals.gsExceptionString)
            {
                MessageBox.Show(Globals.gsErrorMessage + " " + exResult.Message);
            }
            else
            {
                MessageBox.Show("Successfully added to the Database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }
        private bool ValidateScreen()
        {
            bool retVal = true;
            if ((int)grd.CurrentRow.Cells["ID"].Value == 0) retVal = false;
            return retVal;
        }
        private clsPaymentApprovals_Item PrepareObject(bool approve = true, string reason = "Approved")
        {
            clsPaymentApprovals_Item obj = new clsPaymentApprovals_Item();
            obj.paymentRequestID = (int)grd.CurrentRow.Cells["ID"].Value;
            obj.approverParishUserID = Globals.giParishUserID;
            obj.reason = reason; //hahahahahahahahaha
            obj.approvalStatus = approve ? true : false;
            return obj;
        }
    }
}
