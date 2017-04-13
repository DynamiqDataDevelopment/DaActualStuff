
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsParishTypes_List : List<clsParishTypes_Item>
{
    private string _connectionString = string.Empty;
    public clsParishTypes_List(string connectionString)
    {
        _connectionString = connectionString;
    }
    public clsParishTypes_List(string connectionString, ref Exception pEx, int ID, string parishTypeDescription)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetParishTypes";
            cmd.Parameters.AddWithValue("@ID", ID);
            if (!(parishTypeDescription == string.Empty)) cmd.Parameters.AddWithValue("@parishTypeDescription", parishTypeDescription);
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
                clsParishTypes_Item tmp = new clsParishTypes_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["parishTypeDescription"] == DBNull.Value)) tmp.parishTypeDescription = (string)data_reader["parishTypeDescription"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, int ID, string parishTypeDescription)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertParishTypes";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@parishTypeDescription", parishTypeDescription);
            if (Save(ref pEx, cmd))
            {
                this.Add(new clsParishTypes_Item(ID, parishTypeDescription));
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

    public bool Update_Item(ref Exception pEx, int ID, string parishTypeDescription)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateParishTypes";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@parishTypeDescription", parishTypeDescription);
            if (Save(ref pEx, cmd))
            {
                foreach (clsParishTypes_Item Item in this)
                {
                    if (Item.ID == ID)
                    {
                        Item.ID = ID;
                        Item.parishTypeDescription = parishTypeDescription;
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

    public bool Delete_Item(ref Exception pEx, Guid ID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteParishTypes";
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

public class clsParishTypes_Item
{
    private int _ID;
    private string _parishTypeDescription;
    private bool _isDeleted;

    private bool _changed = false;

    public clsParishTypes_Item()
    {
        //Default constructor
    }

    public clsParishTypes_Item(int ID, string parishTypeDescription)
    {
        _ID = ID;
        _parishTypeDescription = parishTypeDescription;
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
                _changed = true;
            }
        }
    }

    [XmlElement(typeof(string))]
    public string parishTypeDescription
    {
        get
        {
            return _parishTypeDescription;
        }

        set
        {
            if (!(_parishTypeDescription == value))
            {
                _parishTypeDescription = value;
                _changed = true;
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
                _changed = true;
            }
        }
    }


}


