using Archdiocese.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Archdiocese.Menus;

namespace Archdiocese.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            MyInitializeComponent();
        }

        private void MyInitializeComponent()
        {
            bool flagTest = true;
            if (flagTest)
            {
                Globals.giUserID = 1;
                Globals.giParishUserID = 1;
                Globals.giParishID = 1;
                outlookBar1.SelectedButton = outlookBar1.Buttons[0];
            }
            else
            {
                frmLogin frm = new frmLogin();
                DialogResult _Result = frm.ShowDialog();
                this.tsslParish.Text = Globals.gsParishName + " is the selected Parish";
                this.tsslUser.Text = Globals.gsUserName + " is logged in";
                outlookBar1.SelectedButton = outlookBar1.Buttons[0]; 
            }
            
        }
        private void collectionTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmCollectionTypesView frm = new frmCollectionTypesView();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void collectionTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmCollectionTypes frm = new frmCollectionTypes();
            frm.Show();
        }

        private void CloseOpenForms()
        {
            var moOpenForms = Application.OpenForms;
            try
            {
                foreach (Form form in moOpenForms)
                {
                    if (form.Name != "frmMain")
                    {
                        form.Close();
                        form.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                //ignore, OpenForms will change and throw an exception but i don't care
                //throw;
            }
            
        }
        
        private void submitCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmSubmitCollection frm = new frmSubmitCollection();
            frm.Show();
        }

        private void parishTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmParishTypesView frm = new frmParishTypesView();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void leaveTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmLeaveTypesView frm = new frmLeaveTypesView();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void addressTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmAddressTypesView frm = new frmAddressTypesView();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void emailAddressTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmEmailAddressTypesView frm = new frmEmailAddressTypesView();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void expenseTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmExpenseTypesView frm = new frmExpenseTypesView();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

       
        private void incomeTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmIncomeTypesView frm = new frmIncomeTypesView();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void maritalStatusesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmMaritalStatusesView frm = new frmMaritalStatusesView();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void personTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmPersonTypesView frm = new frmPersonTypesView();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void telephoneNumberTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmTelephoneNumberTypesView frm = new frmTelephoneNumberTypesView();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void addressTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmAddressTypes frm = new frmAddressTypes();
            frm.Show();
        }

        private void emailAddressTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmEmailAddressTypes frm = new frmEmailAddressTypes();
            frm.Show();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.ShowDialog();
        }

        public void ShowMenu_Users()
        {
            frmUsersMenu frm = new frmUsersMenu();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        public void ShowMenu_Persons()
        {
            CloseOpenForms();
            frmMenu_Persons frm = new frmMenu_Persons();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        public void ShowMenu_Accounting()
        {
            CloseOpenForms();
            frmMenu_Accounting frm = new frmMenu_Accounting();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void outlookBar1_Click(object sender, OutlookStyleControls.OutlookBar.ButtonClickEventArgs e)
        {
            CloseOpenForms();
            int idx = outlookBar1.Buttons.IndexOf(e.SelectedButton);
            switch (idx)
            {
                case 0: // Home
                    int r = 0;
                    break;
                case 1: // People
                    ShowMenu_Persons();
                    break;
                case 2: // Accounting
                    ShowMenu_Accounting();
                    break;
                case 3: // Parishes
                    MessageBox.Show("Parishes");
                    break;
                case 4: // Groups
                    MessageBox.Show("Groups");
                    break;
                case 5: // Reports
                    MessageBox.Show("Reports");
                    break;
                default: 
                    MessageBox.Show("Default");
                    break;
            }
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CloseOpenForms();
            //frmExpenses frm = new frmExpenses();
            //frm.MdiParent = this;
            //frm.Size = this.Size;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
        }

        private void incomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CloseOpenForms();
            //frmIncomes frm = new frmIncomes();
            //frm.MdiParent = this;
            //frm.Size = this.Size;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Are you sure that you want to exit the application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CloseOpenForms();
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog();
        }

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUsers frm = new frmUsers();
            frm.Show();
        }

        private void personsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenForms();
            frmParishPersonsView frm = new frmParishPersonsView();
            frm.MdiParent = this;
            frm.Size = this.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
