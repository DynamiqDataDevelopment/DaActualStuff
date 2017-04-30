
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsClergyTitles_List : List<clsClergyTitles_Item>
{
    private string _connectionString = string.Empty;

    public clsClergyTitles_List(string connectionString)
    {
        _connectionString = connectionString;
    }

    public clsClergyTitles_List(string connectionString, ref Exception pEx, int ID, string description, string abbreviation)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetClergyTitles";
            if (!(ID == 0)) cmd.Parameters.AddWithValue("@ID", ID);
            if (!(description == string.Empty)) cmd.Parameters.AddWithValue("@description", description);
            if (!(abbreviation == string.Empty)) cmd.Parameters.AddWithValue("@abbreviation", abbreviation);
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
                clsClergyTitles_Item tmp = new clsClergyTitles_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["description"] == DBNull.Value)) tmp.description = (string)data_reader["description"];
                if (!(data_reader["abbreviation"] == DBNull.Value)) tmp.abbreviation = (string)data_reader["abbreviation"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsClergyTitles_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertClergyTitles";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@description", obj.description);
            cmd.Parameters.AddWithValue("@abbreviation", obj.abbreviation);
            if (Save(ref pEx, cmd))
            {
                this.Add(new clsClergyTitles_Item(obj.ID, obj.description, obj.abbreviation));
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

    public bool Update_Item(ref Exception pEx, clsClergyTitles_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateClergyTitles";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@description", obj.description);
            cmd.Parameters.AddWithValue("@abbreviation", obj.abbreviation);
            if (Save(ref pEx, cmd))
            {
                foreach (clsClergyTitles_Item Item in this)
                {
                    if (Item.ID == obj.ID)
                    {
                        Item.ID = obj.ID;
                        Item.description = obj.description;
                        Item.abbreviation = obj.abbreviation;
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
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteClergyTitles";
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

    public bool Enable_Item(ref Exception pEx, int ID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EnableClergyTitles";
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

    public bool Disable_Item(ref Exception pEx, int ID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DisableClergyTitles";
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

public class clsClergyTitles_Item
{
    private int _ID;
    private string _description;
    private string _abbreviation;
    private bool _isDeleted;


    public clsClergyTitles_Item()
    {
        //Default constructor
    }

    public clsClergyTitles_Item(int ID, string description, string abbreviation)
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


