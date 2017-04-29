using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Serialization;



public class clsPersonParish_List : List<clsPersonParish_Item>
{
    string _connectionString;
    public clsPersonParish_List(string connectionString)
    {
        _connectionString = connectionString;
    }

    public clsPersonParish_List(string connectionString, ref Exception pEx, int parishID)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetParishPersons";
            //cmd.Parameters.AddWithValue("@entityID", entityID);
            if (!(parishID == 0)) cmd.Parameters.AddWithValue("@parishID", parishID);
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
                if (!(data_reader["personID"] == DBNull.Value)) tmp.personID = (int)data_reader["personID"];
                if (!(data_reader["titleID"] == DBNull.Value)) tmp.titleID = (int)data_reader["titleID"];
                if (!(data_reader["title"] == DBNull.Value)) tmp.title = (string)data_reader["title"];
                if (!(data_reader["personTypeID"] == DBNull.Value)) tmp.personTypeID = (int)data_reader["personTypeID"];
                if (!(data_reader["personType"] == DBNull.Value)) tmp.personType = (string)data_reader["personType"];
                if (!(data_reader["firstName"] == DBNull.Value)) tmp.firstName = (string)data_reader["firstName"];
                if (!(data_reader["middleName"] == DBNull.Value)) tmp.middleName = (string)data_reader["middleName"];
                if (!(data_reader["surname"] == DBNull.Value)) tmp.surname = (string)data_reader["surname"];
                if (!(data_reader["dateOfBirth"] == DBNull.Value)) tmp.dateOfBirth = (DateTime)data_reader["dateOfBirth"];
                if (!(data_reader["genderID"] == DBNull.Value)) tmp.genderID = (int)data_reader["genderID"];
                if (!(data_reader["gender"] == DBNull.Value)) tmp.gender = (string)data_reader["gender"];
                if (!(data_reader["maritalStatusID"] == DBNull.Value)) tmp.maritalStatusID = (int)data_reader["maritalStatusID"];
                if (!(data_reader["maritalStatus"] == DBNull.Value)) tmp.maritalStatus = (string)data_reader["maritalStatus"];
                if (!(data_reader["parishID"] == DBNull.Value)) tmp.parishID = (int)data_reader["parishID"];
                if (!(data_reader["parishName"] == DBNull.Value)) tmp.parishName = (string)data_reader["parishName"];
                if (!(data_reader["joinedDate"] == DBNull.Value)) tmp.joinedDate = (DateTime)data_reader["joinedDate"];
                if (!(data_reader["leftDate"] == DBNull.Value)) tmp.leftDate = (DateTime)data_reader["leftDate"];
                if (!(data_reader["addressLine1"] == DBNull.Value)) tmp.addressLine1 = (string)data_reader["addressLine1"];
                if (!(data_reader["addressLine2"] == DBNull.Value)) tmp.addressLine2 = (string)data_reader["addressLine2"];
                if (!(data_reader["addressLine3"] == DBNull.Value)) tmp.addressLine3 = (string)data_reader["addressLine3"];
                if (!(data_reader["addressTypeID"] == DBNull.Value)) tmp.addressTypeID = (int)data_reader["addressTypeID"];
                if (!(data_reader["addressTypeDescription"] == DBNull.Value)) tmp.addressTypeDescription = (string)data_reader["addressTypeDescription"];
                if (!(data_reader["city"] == DBNull.Value)) tmp.city = (string)data_reader["city"];
                if (!(data_reader["suburb"] == DBNull.Value)) tmp.suburb = (string)data_reader["suburb"];
                if (!(data_reader["postalCode"] == DBNull.Value)) tmp.postalCode = (string)data_reader["postalCode"];
                if (!(data_reader["emailAddress"] == DBNull.Value)) tmp.emailAddress = (string)data_reader["emailAddress"];
                if (!(data_reader["emailTypeID"] == DBNull.Value)) tmp.emailTypeID = (int)data_reader["emailTypeID"];
                if (!(data_reader["emailTypeDescription"] == DBNull.Value)) tmp.emailTypeDescription = (string)data_reader["emailTypeDescription"];
                if (!(data_reader["telephoneNumber"] == DBNull.Value)) tmp.telephoneNumber = (string)data_reader["telephoneNumber"];
                if (!(data_reader["telephoneNumberTypeID"] == DBNull.Value)) tmp.telephoneNumberTypeID = (int)data_reader["telephoneNumberTypeID"];
                if (!(data_reader["telephoneNumberTypeDescription"] == DBNull.Value)) tmp.telephoneNumberTypeDescription = (string)data_reader["telephoneNumberTypeDescription"];
                if (!(data_reader["pledgeAmount"] == DBNull.Value)) tmp.pledgeAmount = (decimal)data_reader["pledgeAmount"];
                if (!(data_reader["pledgeTypeID"] == DBNull.Value)) tmp.pledgeTypeID = (int)data_reader["pledgeTypeID"];
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
    decimal _pledgeAmount;
    int _pledgeTypeID;

    public clsPersonParish_Item()
    {
        //Default Constructor for the clsPersonParish Class
    }

    public clsPersonParish_Item(int personID, int titleID, string title, int personTypeID, string personType, string firstName, string middleName, string surname, DateTime dateOfBirth, int genderID,
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

    [XmlElement(typeof(decimal))]
    public decimal pledgeAmount
    {
        get { return _pledgeAmount; }
        set { _pledgeAmount = value; }
    }

    [XmlElement(typeof(int))]
    public int pledgeTypeID
    {
        get { return _pledgeTypeID; }
        set { _pledgeTypeID = value; }
    }
}

