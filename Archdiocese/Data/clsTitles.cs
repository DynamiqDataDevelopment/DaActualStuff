
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsTitles_List : List<clsTitles_Item>
{
    private string _connectionString = string.Empty;
    

    public clsTitles_List(string connectionString, ref Exception pEx, int ID, string description, string abbreviation)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetTitles";
            //cmd.Parameters.AddWithValue("@ID", ID);
            //if (!(description == string.Empty)) cmd.Parameters.AddWithValue("@description", description);
            //if (!(abbreviation == string.Empty)) cmd.Parameters.AddWithValue("@abbreviation", abbreviation);
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
                clsTitles_Item tmp = new clsTitles_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["description"] == DBNull.Value)) tmp.description = (string)data_reader["description"];
                if (!(data_reader["abbreviation"] == DBNull.Value)) tmp.abbreviation = (string)data_reader["abbreviation"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, int ID, string description, string abbreviation)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertTitles";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@abbreviation", abbreviation);
            if (Save(ref pEx, cmd))
            {
                this.Add(new clsTitles_Item(ID, description, abbreviation));
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }
        catch (Exception ex)
        {
            pEx = ex;
        }
        conn.Close();
        return false;
    }

    public bool Update_Item(ref Exception pEx, int ID, string description, string abbreviation)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateTitles";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@abbreviation", abbreviation);
            if (Save(ref pEx, cmd))
            {
                foreach (clsTitles_Item Item in this)
                {
                    if (Item.ID == ID)
                    {
                        Item.ID = ID;
                        Item.description = description;
                        Item.abbreviation = abbreviation;
                    }
                }
            }
            else
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return true;
        }
        catch (Exception ex)
        {
            pEx = ex;
        }
        conn.Close();
        return false;
    }

    public bool Delete_Item(ref Exception pEx, int ID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteTitles";
            cmd.Parameters.AddWithValue("@ID", ID);
            if (Save(ref pEx, cmd))
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }
        catch (Exception ex)
        {
            pEx = ex;
        }
        conn.Close();
        return false;
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

public class clsTitles_Item
{
    private int _ID;
    private string _description;
    private string _abbreviation;
    private bool _isDeleted;


    public clsTitles_Item()
    {
        //Default constructor
    }

    public clsTitles_Item(int ID, string description, string abbreviation)
    {
        _ID = ID;
        _description = description;
        _abbreviation = abbreviation;
        _isDeleted = isDeleted;
    }

    [XmlElement(typeof(int))]
    public int ID
    {
        get
        {
            return _ID;
        }

        set
        {
            if (!(_ID == value))
            {
                _ID = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string description
    {
        get
        {
            return _description;
        }

        set
        {
            if (!(_description == value))
            {
                _description = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string abbreviation
    {
        get
        {
            return _abbreviation;
        }

        set
        {
            if (!(_abbreviation == value))
            {
                _abbreviation = value;

            }
        }
    }

    [XmlElement(typeof(bool))]
    public bool isDeleted
    {
        get
        {
            return _isDeleted;
        }

        set
        {
            if (!(_isDeleted == value))
            {
                _isDeleted = value;

            }
        }
    }


}


