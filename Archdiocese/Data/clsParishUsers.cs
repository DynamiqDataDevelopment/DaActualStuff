
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsParishUsers_List : List<clsParishUsers_Item>
{
    private string _connectionString = string.Empty;
    private Guid _userCde = Guid.Empty;

    public clsParishUsers_List(string connectionString, ref Exception pEx, int ID, int parishID, int userID)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetParishUsers";
            //cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@parishID", parishID);
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
                clsParishUsers_Item tmp = new clsParishUsers_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["parishID"] == DBNull.Value)) tmp.parishID = (int)data_reader["parishID"];
                if (!(data_reader["userID"] == DBNull.Value)) tmp.userID = (int)data_reader["userID"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, int ID, int parishID, int userID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertParishUsers";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@parishID", parishID);
            cmd.Parameters.AddWithValue("@userID", userID);
            if (Save(ref pEx, cmd))
            {
                this.Add(new clsParishUsers_Item(ID, parishID, userID));
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

    public bool Update_Item(ref Exception pEx, int ID, int parishID, int userID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateParishUsers";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@parishID", parishID);
            cmd.Parameters.AddWithValue("@userID", userID);
            if (Save(ref pEx, cmd))
            {
                foreach (clsParishUsers_Item Item in this)
                {
                    if (Item.ID == ID)
                    {
                        Item.ID = ID;
                        Item.parishID = parishID;
                        Item.userID = userID;
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
            cmd.CommandText = "usp_DeleteParishUsers";
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

public class clsParishUsers_Item
{
    private int _ID;
    private int _parishID;
    private int _userID;
    private bool _isDeleted;

    private bool _changed = false;

    public clsParishUsers_Item()
    {
        //Default constructor
    }

    public clsParishUsers_Item(int ID, int parishID, int userID)
    {
        _ID = ID;
        _parishID = parishID;
        _userID = userID;
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
                _changed = true;
            }
        }
    }

    [XmlElement(typeof(int))]
    public int userID
    {
        get
        {
            return _userID;
        }

        set
        {
            if (!(_userID == value))
            {
                _userID = value;
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


