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
        List<clsParishPersons_Item> Person_Data = new List<clsParishPersons_Item>();
        List<clsParishPersons_Item> Person_Data_Filtered = new List<clsParishPersons_Item>();
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
            clsParishPersons_List _Data = new clsParishPersons_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, Globals.giParishID);
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
                    MessageBox.Show("No data has been captured for " + Globals.gsParishName, "Persons");
                }
            }
        }
    }
}
