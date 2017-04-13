
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsUserGroups_List : List<clsUserGroups_Item>
{
    private string _connectionString = string.Empty;

    public clsUserGroups_List(string connectionString)
    {
        //default Constructor
    }
    public clsUserGroups_List(string connectionString, ref Exception pEx, int ID, string userGroupName, string permissionString)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetUserGroups";
            cmd.Parameters.AddWithValue("@ID", ID);
            if (!(userGroupName == string.Empty)) cmd.Parameters.AddWithValue("@userGroupName", userGroupName);
            if (!(permissionString == string.Empty)) cmd.Parameters.AddWithValue("@permissionString", permissionString);
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
                clsUserGroups_Item tmp = new clsUserGroups_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["userGroupName"] == DBNull.Value)) tmp.userGroupName = (string)data_reader["userGroupName"];
                if (!(data_reader["permissionString"] == DBNull.Value)) tmp.permissionString = (string)data_reader["permissionString"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsUserGroups_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertUserGroups";
            //cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@userGroupName", obj.userGroupName);
            cmd.Parameters.AddWithValue("@permissionString", obj.permissionString);
            if (Save(ref pEx, cmd))
            {
                this.Add(new clsUserGroups_Item(obj.ID, obj.userGroupName, obj.permissionString));
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

    public bool Update_Item(ref Exception pEx, clsUserGroups_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateUserGroups";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@userGroupName", obj.userGroupName);
            cmd.Parameters.AddWithValue("@permissionString", obj.permissionString);
            if (Save(ref pEx, cmd))
            {
                foreach (clsUserGroups_Item Item in this)
                {
                    if (Item.ID == obj.ID)
                    {
                        Item.ID = obj.ID;
                        Item.userGroupName = obj.userGroupName;
                        Item.permissionString = obj.permissionString;
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
            cmd.CommandText = "usp_DeleteUserGroups";
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

public class clsUserGroups_Item
{
    private int _ID;
    private string _userGroupName;
    private string _permissionString;
    private bool _isDeleted;

    private bool _changed = false;

    public clsUserGroups_Item()
    {
        //Default constructor
    }

    public clsUserGroups_Item(int ID, string userGroupName, string permissionString)
    {
        _ID = ID;
        _userGroupName = userGroupName;
        _permissionString = permissionString;
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
    public string userGroupName
    {
        get
        {
            return _userGroupName;
        }

        set
        {
            if (!(_userGroupName == value))
            {
                _userGroupName = value;
                _changed = true;
            }
        }
    }

    [XmlElement(typeof(string))]
    public string permissionString
    {
        get
        {
            return _permissionString;
        }

        set
        {
            if (!(_permissionString == value))
            {
                _permissionString = value;
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


