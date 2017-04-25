using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Archdiocese.Data
{

    public class clsPersonParish_List : List<clsPersonParish_Item>
    {
        string _connectionString;
        public clsPersonParish_List(string connectionString)
        {
            _connectionString = connectionString;
        }

        public clsPersonParish_List(string connectionString, Exception pEx)
        {
            _connectionString = connectionString;
            SqlConnection conn = new SqlConnection((_connectionString));
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_GetAddresses";
                //cmd.Parameters.AddWithValue("@entityID", entityID);
                //cmd.Parameters.AddWithValue("@addressTypeID", addressTypeID);
                //if (!(addressLine1 == string.Empty)) cmd.Parameters.AddWithValue("@addressLine1", addressLine1);
                //if (!(addressLine2 == string.Empty)) cmd.Parameters.AddWithValue("@addressLine2", addressLine2);
                //if (!(addressLine3 == string.Empty)) cmd.Parameters.AddWithValue("@addressLine3", addressLine3);
                //if (!(suburb == string.Empty)) cmd.Parameters.AddWithValue("@suburb", suburb);
                //if (!(city == string.Empty)) cmd.Parameters.AddWithValue("@city", city);
                SqlDataReader data_reader = cmd.ExecuteReader();
                Populate_Members(data_reader);
            }
            catch (Exception ex)
            {
                pEx = ex;
            }
            conn.Close();
        }

        private void Populate_Members(SqlDataReader data_reader)
        {
            this.Clear();
            if (data_reader.HasRows)
            {
                while (data_reader.Read())
                {
                    clsPersonParish_Item tmp = new clsPersonParish_Item();
                    //if (!(data_reader["entityID"] == DBNull.Value)) tmp.entityID = (int)data_reader["entityID"];
                    if (!(data_reader["addressTypeID"] == DBNull.Value)) tmp.addressTypeID = (int)data_reader["addressTypeID"];
                    if (!(data_reader["addressLine1"] == DBNull.Value)) tmp.addressLine1 = (string)data_reader["addressLine1"];
                    if (!(data_reader["addressLine2"] == DBNull.Value)) tmp.addressLine2 = (string)data_reader["addressLine2"];
                    if (!(data_reader["addressLine3"] == DBNull.Value)) tmp.addressLine3 = (string)data_reader["addressLine3"];
                    if (!(data_reader["suburb"] == DBNull.Value)) tmp.suburb = (string)data_reader["suburb"];
                    if (!(data_reader["city"] == DBNull.Value)) tmp.city = (string)data_reader["city"];
                    this.Add(tmp);
                }
            }
        }
    }

    public class clsPersonParish_Item
    {
        int _personID;
        int _titleID;
        string _title;
        int _personTypeID;
        string _personType;
        string _firstName;
        string _middleName;
        string _surname;
        DateTime _dateOfBirth;
        int _genderID;
        string _gender;
        int _maritalStatusID;
        string _maritalStatus;
        int _parishID;
        string _parishName;
        DateTime _joinedDate;
        DateTime _leftDate;
        string _addressLine1;
        string _addressLine2;
        string _addressLine3;
        int _addressTypeID;
        string _addressTypeDescription;
        string _city;
        string _suburb;
        string _postalCode;
        string _emailAddress;
        int _emailTypeID;
        string _emailTypeDescription;
        string _telephoneNumber;
        int _telephoneNumberTypeID;
        string _telephoneNumberTypeDescription;

        public clsPersonParish()
        {
            //Default Constructor for the clsPersonParish Class
        }

        public clsPersonParish(int personID, int titleID, string title, int personTypeID, string personType, string firstName, string middleName, string surname, DateTime dateOfBirth, int genderID,
        string gender, int maritalStatusID, string maritalStatus, int parishID, string parishName, DateTime joinedDate, DateTime leftDate, string addressLine1, string addressLine2, string addressLine3,
        int addressTypeID, string addressTypeDescription, string city, string suburb, string postalCode, string emailAddress, int emailTypeID, string emailTypeDescription, string telephoneNumber, int telephoneNumberTypeID,
        string telephoneNumberTypeDescription)
        {
            //Default Constructor for the clsPersonParish Class
            _personID = personID;
            _titleID = titleID;
            _title = title;
            _personTypeID = personTypeID;
            _personType = personType;
            _firstName = firstName;
            _middleName = middleName;
            _surname = surname;
            _dateOfBirth = dateOfBirth;
            _genderID = genderID;
            _gender = gender;
            _maritalStatusID = maritalStatusID;
            _maritalStatus = maritalStatus;
            _parishID = parishID;
            _parishName = parishName;
            _joinedDate = joinedDate;
            _leftDate = leftDate;
            _addressLine1 = addressLine1;
            _addressLine2 = addressLine2;
            _addressLine3 = addressLine3;
            _addressTypeID = addressTypeID;
            _addressTypeDescription = addressTypeDescription;
            _city = city;
            _suburb = suburb;
            _postalCode = postalCode;
            _emailAddress = emailAddress;
            _emailTypeID = emailTypeID;
            _emailTypeDescription = emailTypeDescription;
            _telephoneNumber = telephoneNumber;
            _telephoneNumberTypeID = telephoneNumberTypeID;
            _telephoneNumberTypeDescription = telephoneNumberTypeDescription;

        }


        [XmlElement(typeof(int))]
        public int personID
        {
            get { return _personID; }
            set { _personID = value; }
        }


        [XmlElement(typeof(int))]
        public int titleID
        {
            get { return _titleID; }
            set { _titleID = value; }
        }


        [XmlElement(typeof(string))]
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }


        [XmlElement(typeof(int))]
        public int personTypeID
        {
            get { return _personTypeID; }
            set { _personTypeID = value; }
        }


        [XmlElement(typeof(string))]
        public string personType
        {
            get { return _personType; }
            set { _personType = value; }
        }


        [XmlElement(typeof(string))]
        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }


        [XmlElement(typeof(string))]
        public string middleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }


        [XmlElement(typeof(string))]
        public string surname
        {
            get { return _surname; }
            set { _surname = value; }
        }


        [XmlElement(typeof(DateTime))]
        public DateTime dateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }


        [XmlElement(typeof(int))]
        public int genderID
        {
            get { return _genderID; }
            set { _genderID = value; }
        }


        [XmlElement(typeof(string))]
        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }


        [XmlElement(typeof(int))]
        public int maritalStatusID
        {
            get { return _maritalStatusID; }
            set { _maritalStatusID = value; }
        }


        [XmlElement(typeof(string))]
        public string maritalStatus
        {
            get { return _maritalStatus; }
            set { _maritalStatus = value; }
        }


        [XmlElement(typeof(int))]
        public int parishID
        {
            get { return _parishID; }
            set { _parishID = value; }
        }


        [XmlElement(typeof(string))]
        public string parishName
        {
            get { return _parishName; }
            set { _parishName = value; }
        }


        [XmlElement(typeof(DateTime))]
        public DateTime joinedDate
        {
            get { return _joinedDate; }
            set { _joinedDate = value; }
        }


        [XmlElement(typeof(DateTime))]
        public DateTime leftDate
        {
            get { return _leftDate; }
            set { _leftDate = value; }
        }


        [XmlElement(typeof(string))]
        public string addressLine1
        {
            get { return _addressLine1; }
            set { _addressLine1 = value; }
        }


        [XmlElement(typeof(string))]
        public string addressLine2
        {
            get { return _addressLine2; }
            set { _addressLine2 = value; }
        }


        [XmlElement(typeof(string))]
        public string addressLine3
        {
            get { return _addressLine3; }
            set { _addressLine3 = value; }
        }

        [XmlElement(typeof(int))]
        public int addressTypeID
        {
            get { return _addressTypeID; }
            set { _addressTypeID = value; }
        }

        [XmlElement(typeof(string))]
        public string addressTypeDescription
        {
            get { return _addressTypeDescription; }
            set { _addressTypeDescription = value; }
        }

        [XmlElement(typeof(string))]
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }

        [XmlElement(typeof(string))]
        public string suburb
        {
            get { return _suburb; }
            set { _suburb = value; }
        }

        [XmlElement(typeof(string))]
        public string postalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        [XmlElement(typeof(string))]
        public string emailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        [XmlElement(typeof(int))]
        public int emailTypeID
        {
            get { return _emailTypeID; }
            set { _emailTypeID = value; }
        }

        [XmlElement(typeof(string))]
        public string emailTypeDescription
        {
            get { return _emailTypeDescription; }
            set { _emailTypeDescription = value; }
        }

        [XmlElement(typeof(string))]
        public string telephoneNumber
        {
            get { return _telephoneNumber; }
            set { _telephoneNumber = value; }
        }

        [XmlElement(typeof(int))]
        public int telephoneNumberTypeID
        {
            get { return _telephoneNumberTypeID; }
            set { _telephoneNumberTypeID = value; }
        }

        [XmlElement(typeof(string))]
        public string telephoneNumberTypeDescription
        {
            get { return _telephoneNumberTypeDescription; }
            set { _telephoneNumberTypeDescription = value; }
        }
    }
}
