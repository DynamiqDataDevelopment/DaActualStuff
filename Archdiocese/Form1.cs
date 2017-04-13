using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Archdiocese
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void outlookBar1_Load(object sender, EventArgs e)
        {

        }

        private void outlookBar1_Click(object sender, OutlookStyleControls.OutlookBar.ButtonClickEventArgs e)
        {
            int idx = outlookBar1.Buttons.IndexOf(e.SelectedButton);
            switch (idx)
            {
                case 0: // People
                    MessageBox.Show("Hi");
                    break;
                case 1: // Groups
                    MessageBox.Show("Ho");
                    break;
                case 2: // Accounting
                    MessageBox.Show("Accounting");
                    break;
                default: // notes
                    MessageBox.Show("Default");
                    break;
            }
        }
    }
}
