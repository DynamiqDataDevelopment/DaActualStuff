
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml.Serialization;

public class clsAccounting_List : List<clsAccounting_Item>
{
    private string _connectionString = string.Empty;

    public clsAccounting_List(string connectionString)
    {
        _connectionString = connectionString;
    }

    public clsAccounting_List(string connectionString, ref Exception pEx, int parishID, DateTime dateFrom, DateTime dateTo, string accountNumber, string description)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "usp_GetAccounting";
            cmd.CommandText = "usp_GetAccounting_Test";
            if (!(parishID == 0)) cmd.Parameters.AddWithValue("@parishID", parishID);
            if (!(dateFrom == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            if (!(dateTo == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateTo", dateTo);
            if (!(accountNumber == string.Empty)) cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
            if (!(description == string.Empty)) cmd.Parameters.AddWithValue("@description", description);
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
                clsAccounting_Item tmp = new clsAccounting_Item();
                if (!(data_reader["Type"] == DBNull.Value)) tmp.Type = (string)data_reader["Type"];
                if (!(data_reader["amount"] == DBNull.Value)) tmp.amount = (decimal)data_reader["amount"];
                if (!(data_reader["description"] == DBNull.Value)) tmp.description = (string)data_reader["description"];
                if (!(data_reader["accountNumber"] == DBNull.Value)) tmp.accountNumber = (string)data_reader["accountNumber"];
                if (!(data_reader["accountName"] == DBNull.Value)) tmp.accountName = (string)data_reader["accountName"];
                if (!(data_reader["theDate"] == DBNull.Value)) tmp.theDate = (DateTime)data_reader["theDate"];
                if (!(data_reader["dateSubmitted"] == DBNull.Value)) tmp.dateSubmitted = (DateTime)data_reader["dateSubmitted"];
                if (!(data_reader["captureUser"] == DBNull.Value)) tmp.captureUser = (string)data_reader["captureUser"];

                this.Add(tmp);
            }
        }
    }
}
    public class clsAccounting_Item
{
    string _Type;
    decimal _amount;
    string _description;
    string _accountNumber;
    string _accountName;
    DateTime _theDate;
    DateTime _dateSubmitted;
    string _captureUser;

    public clsAccounting_Item()
    {
        //Default Constructor for the clsAccounting_Item Class
    }

    public clsAccounting_Item(string Type, decimal amount, string description, string accountNumber, string accountName, DateTime theDate, DateTime dateSubmitted, string captureUser)
    {
        //Default Constructor for the clsAccounting_Item Class
        _Type = Type;
        _amount = amount;
        _description = description;
        _accountNumber = accountNumber;
        _accountName = accountName;
        _theDate = theDate;
        _dateSubmitted = dateSubmitted;
        _captureUser = captureUser;
    }

    [XmlElement(typeof(string))]
    public string Type
    {
        get { return _Type; }
        set { _Type = value; }
    }

    [XmlElement(typeof(decimal))]
    public decimal amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    [XmlElement(typeof(string))]
    public string description
    {
        get { return _description; }
        set { _description = value; }
    }

    [XmlElement(typeof(string))]
    public string accountNumber
    {
        get { return _accountNumber; }
        set { _accountNumber = value; }
    }

    [XmlElement(typeof(string))]
    public string accountName
    {
        get { return _accountName; }
        set { _accountName = value; }
    }

    [XmlElement(typeof(DateTime))]
    public DateTime theDate
    {
        get { return _theDate; }
        set { _theDate = value; }
    }

    [XmlElement(typeof(DateTime))]
    public DateTime dateSubmitted
    {
        get { return _dateSubmitted; }
        set { _dateSubmitted = value; }
    }

    [XmlElement(typeof(string))]
    public string captureUser
    {
        get { return _captureUser; }
        set { _captureUser = value; }
    }
}


