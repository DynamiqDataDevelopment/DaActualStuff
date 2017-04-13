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
    public partial class frmMenu_Persons : Form
    {
        public frmMenu_Persons()
        {
            InitializeComponent();
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            Form frmMain = GetMainForm();
            frmPersons frm = new frmPersons();
            frm.MdiParent = frmMain;
            frm.Size = frmMain.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btnPersonType_MouseHover(object sender, EventArgs e)
        {
            btnPersonType.BackColor = Color.LightBlue;
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

        private void btnPersonType_MouseLeave(object sender, EventArgs e)
        {
            btnPersonType.BackColor = Control.DefaultBackColor;
        }

        private void btnPerson_MouseHover(object sender, EventArgs e)
        {
            btnPerson.BackColor = Color.LightBlue;
        }

        private void btnPerson_MouseLeave(object sender, EventArgs e)
        {
            btnPerson.BackColor = Control.DefaultBackColor;
        }

        private void btnPerson_Click_1(object sender, EventArgs e)
        {
            Form MainForm = GetMainForm();
            frmPersons frm = new frmPersons();
            frm.MdiParent = MainForm;
            frm.Size = MainForm.Size;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
