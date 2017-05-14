using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Archdiocese.Forms;

namespace Archdiocese.Menus
{
    public partial class frmMenu_Accounting : Form
    {
        public frmMenu_Accounting()
        {
            InitializeComponent();
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
        private void btnIncome_MouseHover(object sender, EventArgs e)
        {
            btnIncome.BackColor = Color.LightBlue;
        }

        private void btnExpense_MouseHover(object sender, EventArgs e)
        {
            btnExpense.BackColor = Color.LightBlue;
        }

        private void btnAccountsSetup_MouseHover(object sender, EventArgs e)
        {
            btnAccountsSetup.BackColor = Color.LightBlue;
        }

        private void btnIncome_MouseLeave(object sender, EventArgs e)
        {
            btnIncome.BackColor = Control.DefaultBackColor;
        }

        private void btnExpense_MouseLeave(object sender, EventArgs e)
        {
            btnExpense.BackColor = Control.DefaultBackColor;
        }

        private void btnAccountsSetup_MouseLeave(object sender, EventArgs e)
        {
            btnAccountsSetup.BackColor = Control.DefaultBackColor;
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            Form MainForm = GetMainForm();
            frmIncomes frm = new frmIncomes();
            frm.MdiParent = MainForm;
            frm.Size = MainForm.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            Form MainForm = GetMainForm();
            frmAccountingView frm = new frmAccountingView();
            frm.MdiParent = MainForm;
            frm.Size = MainForm.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form MainForm = GetMainForm();
            frmPaymentRequests frm = new frmPaymentRequests();
            frm.MdiParent = MainForm;
            frm.Size = MainForm.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btnPaymentApprovals_Click(object sender, EventArgs e)
        {
            Form MainForm = GetMainForm();
            frmPaymentRequestApprovals frm = new frmPaymentRequestApprovals();
            frm.MdiParent = MainForm;
            frm.Size = MainForm.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btnAccountsSetup_Click(object sender, EventArgs e)
        {
            Form MainForm = GetMainForm();
            frmAccountingInput frm = new frmAccountingInput();
            frm.MdiParent = MainForm;
            frm.Size = MainForm.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
