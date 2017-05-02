using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archdiocese.Helpers
{
    internal static class ComboBoxes
    {
        public static clsCollectionTypes_List CollectionTypes_Data;
        public static Dictionary<int, string> CollectionTypes_Dictionary = new Dictionary<int, string>();

        public static clsParishTypes_List ParishTypes_Data;
        public static Dictionary<int, string> ParishTypes_Dictionary = new Dictionary<int, string>();

        public static clsUserGroups_List UserGroups_Data;
        public static Dictionary<int, string> UserGroups_Dictionary = new Dictionary<int, string>();


        private static void Bind_ComboBox(ref ComboBox cb, Dictionary<int, string> dict)
        {
            cb.DataSource = null;
            cb.DataBindings.Clear();
            cb.DataSource = new BindingSource(dict, null);
            cb.DisplayMember = "Value";
            cb.ValueMember = "Key";
        }
        public static void ToCollectionsTypeComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            CollectionTypes_Data = new clsCollectionTypes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, 0, string.Empty);
            //User_Data_Filtered = User_Data;
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Collection Types");
            }
            else
            {
                if (CollectionTypes_Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    CollectionTypes_Dictionary.Clear();
                    foreach (clsCollectionTypes_Item item in CollectionTypes_Data)
                    {
                        CollectionTypes_Dictionary.Add(item.ID, item.collectionTypeDescription);
                    }
                    Bind_ComboBox(ref cb, CollectionTypes_Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There are no Collection Types loaded. Please contact your System Administrator.", "Error");
                }
            }
        }
        public static void ToParishTypesComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            ParishTypes_Data = new clsParishTypes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, 0, string.Empty);
            //User_Data_Filtered = User_Data;
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Parish Types");
            }
            else
            {
                if (ParishTypes_Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    ParishTypes_Dictionary.Clear();
                    foreach (clsParishTypes_Item item in ParishTypes_Data)
                    {
                        ParishTypes_Dictionary.Add(item.ID, item.parishTypeDescription);
                    }
                    Bind_ComboBox(ref cb, ParishTypes_Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There are no Parish Types loaded. Please contact your System Administrator.", "Error");
                }
            }
        }

        public static void ToUserGroupsComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            UserGroups_Data = new clsUserGroups_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, 0, string.Empty, string.Empty);
            //User_Data_Filtered = User_Data;
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving User Groups");
            }
            else
            {
                if (UserGroups_Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    UserGroups_Dictionary.Clear();
                    foreach (clsUserGroups_Item item in UserGroups_Data)
                    {
                        UserGroups_Dictionary.Add(item.ID, item.userGroupName);
                    }
                    Bind_ComboBox(ref cb, UserGroups_Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There are no User Groups loaded. Please contact your System Administrator.", "Error");
                }
            }
        }
        public static void ToUserLoginParishComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsParishes_List Data = new clsParishes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, Globals.giUserID);
            //User_Data_Filtered = User_Data;
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Parishes");
            }
            else
            {
                if (Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    UserGroups_Dictionary.Clear();
                    foreach (clsParishes_Item item in Data)
                    {
                        UserGroups_Dictionary.Add(item.ID, item.parishName);
                    }
                    Bind_ComboBox(ref cb, UserGroups_Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There are no Parishes linked to the specified User. Please contact your System Administrator.", "Error");
                }
            }
        }
        
        public static void ToTitlesComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsTitles_List Data = new clsTitles_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, 0, string.Empty, string.Empty);
            Dictionary<int, string> _Dictionary = new Dictionary<int, string>();
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data");
            }
            else
            {
                if (Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    _Dictionary.Clear();
                    foreach (clsTitles_Item item in Data)
                    {
                        _Dictionary.Add(item.ID, item.description + " (" + item.abbreviation + ")");
                    }
                    Bind_ComboBox(ref cb, _Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There is no data loaded. Please contact your System Administrator.", "Error");
                }
            }
        }

        public static void ToClergyTitlesComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsClergyTitles_List Data = new clsClergyTitles_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, 0, string.Empty, string.Empty);
            Dictionary<int, string> _Dictionary = new Dictionary<int, string>();
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data");
            }
            else
            {
                if (Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    _Dictionary.Clear();
                    foreach (clsClergyTitles_Item item in Data)
                    {
                        _Dictionary.Add(item.ID, item.description + " (" + item.abbreviation + ")");
                    }
                    Bind_ComboBox(ref cb, _Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There is no data loaded. Please contact your System Administrator.", "Error");
                }
            }
        }

        public static void ToGendersComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsGenders_List Data = new clsGenders_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult);
            Dictionary<int, string> _Dictionary = new Dictionary<int, string>();
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data");
            }
            else
            {
                if (Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    _Dictionary.Clear();
                    foreach (clsGenders_Item item in Data)
                    {
                        _Dictionary.Add(item.ID, item.description);
                    }
                    Bind_ComboBox(ref cb, _Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There is no data loaded. Please contact your System Administrator.", "Error");
                }
            }
        }

        public static void ToMaritalStatuesComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsMaritalStatuses_List Data = new clsMaritalStatuses_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult);
            Dictionary<int, string> _Dictionary = new Dictionary<int, string>();
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data");
            }
            else
            {
                if (Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    _Dictionary.Clear();
                    foreach (clsMaritalStatuses_Item item in Data)
                    {
                        _Dictionary.Add(item.ID, item.description);
                    }
                    Bind_ComboBox(ref cb, _Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There is no data loaded. Please contact your System Administrator.", "Error");
                }
            }
        }

        public static void ToPersonTypesComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsPersonTypes_List Data = new clsPersonTypes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult);
            Dictionary<int, string> _Dictionary = new Dictionary<int, string>();
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data");
            }
            else
            {
                if (Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    _Dictionary.Clear();
                    foreach (clsPersonTypes_Item item in Data)
                    {
                        _Dictionary.Add(item.ID, item.description);
                    }
                    Bind_ComboBox(ref cb, _Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There is no data loaded. Please contact your System Administrator.", "Error");
                }
            }
        }

        public static void ToClergyTypesComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsClergyTypes_List Data = new clsClergyTypes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, 0, string.Empty);
            Dictionary<int, string> _Dictionary = new Dictionary<int, string>();
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data");
            }
            else
            {
                if (Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    _Dictionary.Clear();
                    foreach (clsClergyTypes_Item item in Data)
                    {
                        _Dictionary.Add(item.ID, item.description);
                    }
                    Bind_ComboBox(ref cb, _Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There is no data loaded. Please contact your System Administrator.", "Error");
                }
            }
        }

        public static void ToExpenseTypesLevel3ComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsExpenseTypesLevel3_List Data = new clsExpenseTypesLevel3_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult);
            Dictionary<int, string> _Dictionary = new Dictionary<int, string>();
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data");
            }
            else
            {
                if (Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    _Dictionary.Clear();
                    foreach (clsExpenseTypesLevel3_Item item in Data)
                    {
                        _Dictionary.Add(item.ID, item.accountNumber + " (" + item.description + ")");
                    }
                    Bind_ComboBox(ref cb, _Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There is no data loaded. Please contact your System Administrator.", "Error");
                }
            }
        }

        public static void ToIncomeTypesLevel3ComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsIncomeTypesLevel3_List Data = new clsIncomeTypesLevel3_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult);
            Dictionary<int, string> _Dictionary = new Dictionary<int, string>();
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data");
            }
            else
            {
                if (Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    _Dictionary.Clear();
                    foreach (clsIncomeTypesLevel3_Item item in Data)
                    {
                        _Dictionary.Add(item.ID, item.accountNumber + " (" + item.description + ")");
                    }
                    Bind_ComboBox(ref cb, _Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There is no data loaded. Please contact your System Administrator.", "Error");
                }
            }
        }

        public static void ToPledgeTypesComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsPledgeTypes_List Data = new clsPledgeTypes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, 0, string.Empty);
            Dictionary<int, string> _Dictionary = new Dictionary<int, string>();
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data");
            }
            else
            {
                if (Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    _Dictionary.Clear();
                    foreach (clsPledgeTypes_Item item in Data)
                    {
                        _Dictionary.Add(item.ID, item.description);
                    }
                    Bind_ComboBox(ref cb, _Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There is no data loaded. Please contact your System Administrator.", "Error");
                }
            }
        }

        public static void ToParishPersonsComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsPersons_List Data = new clsPersons_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, 0, 0, 0, string.Empty, string.Empty, string.Empty, DateTime.MinValue, 0, DateTime.MinValue, DateTime.MinValue, 0, Globals.giParishID);
            Dictionary<int, string> _Dictionary = new Dictionary<int, string>();
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data");
            }
            else
            {
                if (Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    _Dictionary.Clear();
                    foreach (clsPersons_Item item in Data)
                    {
                        _Dictionary.Add(item.ID, item.firstName + " " + item.surname + " (" + item.dateOfBirth.ToShortDateString() + ")" );
                    }
                    Bind_ComboBox(ref cb, _Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There is no data loaded. Please contact your System Administrator.", "Error");
                }
            }
        }

        public static void ToBankBranchCodesComboBox(this ComboBox cb)
        {
            Exception exResult = new Exception(Globals.gsExceptionString);
            clsBankBranchCodes_List Data = new clsBankBranchCodes_List(Globals.DecryptString(Properties.Settings.Default.SqlConnectionString), ref exResult, 0, string.Empty, string.Empty);
            Dictionary<int, string> _Dictionary = new Dictionary<int, string>();
            if (!(exResult.Message == Globals.gsExceptionString))
            {
                MessageBox.Show(Globals.gsErrorMessage + exResult.Message, "Error retrieving Data");
            }
            else
            {
                if (Data.Count > 0)
                {
                    cb.DataSource = null;
                    cb.DataBindings.Clear();
                    _Dictionary.Clear();
                    foreach (clsBankBranchCodes_Item item in Data)
                    {
                        _Dictionary.Add(item.ID, item.code + " (" + item.description + ")");
                    }
                    Bind_ComboBox(ref cb, _Dictionary);
                    cb.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("There is no data loaded. Please contact your System Administrator.", "Error");
                }
            }
        }
    }
}
