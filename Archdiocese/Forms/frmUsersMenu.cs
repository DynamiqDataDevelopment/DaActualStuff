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
    public partial class frmUsersMenu : Form
    {
        public frmUsersMenu()
        {
            InitializeComponent();
        }

        private void btnUserGroupMaintenance_MouseHover(object sender, EventArgs e)
        {
            btnUserGroupMaintenance.BackColor = Color.Navy;
        }

        private void btnUserGroupMaintenance_MouseLeave(object sender, EventArgs e)
        {
            btnUserGroupMaintenance.BackColor = Color.Red;
        }

        private void btnUserMaintenance_MouseHover(object sender, EventArgs e)
        {
            btnUserMaintenance.BackColor = Color.Navy;
        }

        private void btnUserMaintenance_MouseLeave(object sender, EventArgs e)
        {
            btnUserMaintenance.BackColor = Color.Red;
        }
    }
}
