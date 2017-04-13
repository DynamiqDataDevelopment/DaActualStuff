
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsParishes_List : List<clsParishes_Item>
{
    private string _connectionString = string.Empty;
    private Guid _userCde = Guid.Empty;

    public clsParishes_List(string connectionString, ref Exception pEx, int ID, string parishName, int parishTypeID)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetParishes";
            cmd.Parameters.AddWithValue("@ID", ID);
            if (!(parishName == string.Empty)) cmd.Parameters.AddWithValue("@parishName", parishName);
            cmd.Parameters.AddWithValue("@parishTypeID", parishTypeID);
            SqlDataReader data_reader = cmd.ExecuteReader();
            Populate_Members(data_reader);
        }
        catch (Exception ex)
        {
            pEx = ex;
        }
        conn.Close();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="connectionString">SQL Server Connection String</param>
    /// <param name="pEx">Referenced Exception</param>
    /// <param name="userID">UserID used to filter the parishes by User</param>
    public clsParishes_List(string connectionString, ref Exception pEx, int userID)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetParishesByUserID";
            cmd.Parameters.AddWithValue("@userID", userID);
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
                clsParishes_Item tmp = new clsParishes_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["parishName"] == DBNull.Value)) tmp.parishName = (string)data_reader["parishName"];
                if (!(data_reader["parishTypeID"] == DBNull.Value)) tmp.parishTypeID = (int)data_reader["parishTypeID"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, int ID, string parishName, int parishTypeID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertParishes";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@parishName", parishName);
            cmd.Parameters.AddWithValue("@parishTypeID", parishTypeID);
            if (Save(ref pEx, cmd))
            {
                this.Add(new clsParishes_Item(ID, parishName, parishTypeID));
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

    public bool Update_Item(ref Exception pEx, int ID, string parishName, int parishTypeID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateParishes";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@parishName", parishName);
            cmd.Parameters.AddWithValue("@parishTypeID", parishTypeID);
            if (Save(ref pEx, cmd))
            {
                foreach (clsParishes_Item Item in this)
                {
                    if (Item.ID == ID)
                    {
                        Item.ID = ID;
                        Item.parishName = parishName;
                        Item.parishTypeID = parishTypeID;
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
            cmd.CommandText = "usp_DeleteParishes";
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

public class clsParishes_Item
{
    private int _ID;
    private string _parishName;
    private int _parishTypeID;
    private bool _isDeleted;

    private bool _changed = false;

    public clsParishes_Item()
    {
        //Default constructor
    }

    public clsParishes_Item(int ID, string parishName, int parishTypeID)
    {
        _ID = ID;
        _parishName = parishName;
        _parishTypeID = parishTypeID;
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
                _changed = true;
            }
        }
    }

    [XmlElement(typeof(int))]
    public int parishTypeID
    {
        get
        {
            return _parishTypeID;
        }

        set
        {
            if (!(_parishTypeID == value))
            {
                _parishTypeID = value;
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


