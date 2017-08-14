using Archdiocese.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Archdiocese.Dashboards
{
    public partial class frmMainDashboard : Form
    {
        public frmMainDashboard()
        {
            InitializeComponent();
        }

        private void frmMainDashboard_Load(object sender, EventArgs e)
        {
            LoadData();
            SetUsername();
        }


        private void LoadData()
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsParishStatistics_List _Data = new clsParishStatistics_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, Globals.giParishID);
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error");
            }
            else
            {
                if (_Data.Count < 1)
                {
                    MessageBox.Show("No Types have been captured.", "Types");
                }
                else
                {
                    lblNumberOfBaptised.Text = _Data[0].numberOfBaptised.ToString();
                    lblNumberOfConfirmed.Text = _Data[0].numberOfConfirmed.ToString();
                    lblNumberOfParishioners.Text = _Data[0].numberOfParishioners.ToString();
                }
            }
        }

        private void SetUsername()
        {
            lblWelcomeMessage.Text = "Welcome " + Globals.gsUserName + "!";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Globals.SendEmailThroughDefaultClient();
        }
    }
}
