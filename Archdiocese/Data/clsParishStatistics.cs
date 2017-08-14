
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsParishStatistics_List : List<clsParishStatistics_Item>
{
    private string _connectionString = string.Empty;


    public clsParishStatistics_List(string connectionString, ref Exception pEx, int parishID)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        SqlConnection conn2 = new SqlConnection((_connectionString));
        SqlConnection conn3 = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            //numberOfBaptised
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetParishNumberOfBaptised";
            cmd.Parameters.AddWithValue("@parishID", parishID);
            SqlDataReader data_reader = cmd.ExecuteReader();

            //numberOfConfirmed
            conn2.Open();
            SqlCommand cmd2 = conn2.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "usp_GetParishNumberOfConfirmed";
            cmd2.Parameters.AddWithValue("@parishID", parishID);
            SqlDataReader data_reader2 = cmd2.ExecuteReader();

            //numberOfParishioners
            conn3.Open();
            SqlCommand cmd3 = conn3.CreateCommand();
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.CommandText = "usp_GetParishNumberOfPersons";
            cmd3.Parameters.AddWithValue("@parishID", parishID);
            SqlDataReader data_reader3 = cmd3.ExecuteReader();

            Populate_Members(data_reader, data_reader2, data_reader3);
        }
        catch (Exception ex)
        {
            pEx = ex;
        }
        conn.Close();
        conn2.Close();
        conn3.Close();
    }

    private void Populate_Members(SqlDataReader data_reader, SqlDataReader data_reader2, SqlDataReader data_reader3)
    {
        this.Clear();
        clsParishStatistics_Item tmp = new clsParishStatistics_Item();
        if (data_reader.HasRows)
        {
            while (data_reader.Read())
            {
                
                //if (!(data_reader3["numberOfParishioners"] == DBNull.Value)) tmp.numberOfParishioners = (int)data_reader3["numberOfParishioners"];
                if (!(data_reader["numberBaptised"] == DBNull.Value)) tmp.numberOfBaptised = (int)data_reader["numberBaptised"];
                //if (!(data_reader2["numberOfConfirmed"] == DBNull.Value)) tmp.numberOfConfirmed = (int)data_reader2["numberOfConfirmed"];
                //this.Add(tmp);
            }
        }

        if (data_reader2.HasRows)
        {
            while (data_reader2.Read())
            {
                //if (!(data_reader3["numberOfParishioners"] == DBNull.Value)) tmp.numberOfParishioners = (int)data_reader3["numberOfParishioners"];
                //if (!(data_reader["numberOfBaptised"] == DBNull.Value)) tmp.numberOfBaptised = (int)data_reader["numberOfBaptised"];
                if (!(data_reader2["numberConfirmed"] == DBNull.Value)) tmp.numberOfConfirmed = (int)data_reader2["numberConfirmed"];
                //this.Add(tmp);
            }
        }

        if (data_reader3.HasRows)
        {
            while (data_reader3.Read())
            {
                if (!(data_reader3["numberOfParishioners"] == DBNull.Value)) tmp.numberOfParishioners = (int)data_reader3["numberOfParishioners"];
                //if (!(data_reader["numberOfBaptised"] == DBNull.Value)) tmp.numberOfBaptised = (int)data_reader["numberOfBaptised"];
                //if (!(data_reader2["numberOfConfirmed"] == DBNull.Value)) tmp.numberOfConfirmed = (int)data_reader2["numberOfConfirmed"];
                //this.Add(tmp);
            }
        }

        this.Add(tmp);
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

public class clsParishStatistics_Item
{
    private int _numberOfConfirmed;
    private int _numberOfBaptised;
    private int _numberOfParishioners;

    public clsParishStatistics_Item()
    {
        //Default constructor
    }

    public clsParishStatistics_Item(int numberOfConfirmed, int numberOfBaptised, int numberOfParishioners)
    {
        _numberOfBaptised = numberOfBaptised;
        _numberOfConfirmed = numberOfConfirmed;
        _numberOfParishioners = numberOfParishioners;
    }

    [XmlElement(typeof(int))]
    public int numberOfBaptised
    {
        get
        {
            return _numberOfBaptised;
        }

        set
        {
            if (!(_numberOfBaptised == value))
            {
                _numberOfBaptised = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int numberOfConfirmed
    {
        get
        {
            return _numberOfConfirmed;
        }

        set
        {
            if (!(_numberOfConfirmed == value))
            {
                _numberOfConfirmed = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int numberOfParishioners
    {
        get
        {
            return _numberOfParishioners;
        }

        set
        {
            if (!(_numberOfParishioners == value))
            {
                _numberOfParishioners = value;

            }
        }
    }
}