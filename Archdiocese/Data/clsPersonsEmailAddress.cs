
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsPersonsEmailAddress_List : List<clsPersonsEmailAddress_Item>
{
    private string _connectionString = string.Empty;


    public clsPersonsEmailAddress_List(string connectionString, ref Exception pEx, int parishID)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetParishEmailAddresses";
            cmd.Parameters.AddWithValue("@parishID", parishID);
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
                clsPersonsEmailAddress_Item tmp = new clsPersonsEmailAddress_Item();
                if (!(data_reader["personID"] == DBNull.Value)) tmp.personID = (int)data_reader["personID"];
                if (!(data_reader["parishID"] == DBNull.Value)) tmp.parishID = (int)data_reader["parishID"];
                if (!(data_reader["firstName"] == DBNull.Value)) tmp.firstName = (string)data_reader["firstName"];
                if (!(data_reader["surname"] == DBNull.Value)) tmp.surname = (string)data_reader["surname"];
                if (!(data_reader["emailAddress"] == DBNull.Value)) tmp.emailAddress = (string)data_reader["emailAddress"];
                this.Add(tmp);
            }
        }
    }

    private bool Save(ref Exception pEx, SqlCommand cmd)
    {
        try
        {
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            pEx = ex;
            return false;
        }
    }
}

public class clsPersonsEmailAddress_Item
{
    private int _personID;
    private string _firstName;
    private string _surname;
    private string _emailAddress;
    private int _parishID;

    public clsPersonsEmailAddress_Item()
    {
        //Default constructor
    }

    public clsPersonsEmailAddress_Item(int personID, string firstName, string surname, string emailAddress, int parishID)
    {
        _personID = personID;
        _parishID = parishID;
        _firstName = firstName;
        _surname = surname;
        _emailAddress = emailAddress;
    }
    [XmlElement(typeof(int))]
    public int personID
    {
        get
        {
            return _personID;
        }

        set
        {
            if (!(_personID == value))
            {
                _personID = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int parishID
    {
        get
        {
            return _parishID;
        }

        set
        {
            if (!(_parishID == value))
            {
                _parishID = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string firstName
    {
        get
        {
            return _firstName;
        }

        set
        {
            if (!(_firstName == value))
            {
                _firstName = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string surname
    {
        get
        {
            return _surname;
        }

        set
        {
            if (!(_surname == value))
            {
                _surname = value;
            }
        }
    }

    [XmlElement(typeof(int))]
    public string emailAddress
    {
        get
        {
            return _emailAddress;
        }

        set
        {
            if (!(_emailAddress == value))
            {
                _emailAddress = value;

            }
        }
    }
}