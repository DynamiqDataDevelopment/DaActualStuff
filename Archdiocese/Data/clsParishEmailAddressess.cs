
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsParishEmailAddress_List : List<clsParishesEmailAddress_Item>
{
    private string _connectionString = string.Empty;


    public clsParishEmailAddress_List(string connectionString, ref Exception pEx)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetParishEmailAddresses";
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
                clsParishesEmailAddress_Item tmp = new clsParishesEmailAddress_Item();
                if (!(data_reader["parishID"] == DBNull.Value)) tmp.parishID = (int)data_reader["parishID"];
                if (!(data_reader["parishName"] == DBNull.Value)) tmp.parishName = (string)data_reader["parishName"];
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

public class clsParishesEmailAddress_Item
{
    private int _parishID;
    private string _parishName;
    private string _emailAddress;

    public clsParishesEmailAddress_Item()
    {
        //Default constructor
    }

    public clsParishesEmailAddress_Item(int parishID, string parishName, string emailAddress)
    {
        _parishID = parishID;
        _parishName = parishName;
        _emailAddress = emailAddress;
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
    public string parishName
    {
        get
        {
            return _parishName;
        }

        set
        {
            if (!(_parishName == value))
            {
                _parishName = value;

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