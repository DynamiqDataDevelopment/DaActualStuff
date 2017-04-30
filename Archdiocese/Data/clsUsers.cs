
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsUsers_List : List<clsUsers_Item>
{
    private string _connectionString = string.Empty;

    public clsUsers_List(string connectionString)
    {
        _connectionString = connectionString;
    }
    public clsUsers_List(string connectionString, ref Exception pEx, int ID, string username, string password, int userGroupID)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetUsers";
            cmd.Parameters.AddWithValue("@ID", ID);
            if (!(username == string.Empty)) cmd.Parameters.AddWithValue("@username", username);
            if (!(password == string.Empty)) cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@userGroupID", userGroupID);
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
                clsUsers_Item tmp = new clsUsers_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["username"] == DBNull.Value)) tmp.username = (string)data_reader["username"];
                if (!(data_reader["password"] == DBNull.Value)) tmp.password = (string)data_reader["password"];
                if (!(data_reader["userGroupID"] == DBNull.Value)) tmp.userGroupID = (int)data_reader["userGroupID"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, int ID, string username, string password, int userGroupID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertUsers";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@userGroupID", userGroupID);
            if (Save(ref pEx, cmd))
            {
                this.Add(new clsUsers_Item(ID, username, password, userGroupID));
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

    public int Add_Item_ReturnID(ref Exception pEx, clsUsers_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int ID = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertUsers";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@username", obj.username);
            cmd.Parameters.AddWithValue("@password", obj.password);
            cmd.Parameters.AddWithValue("@userGroupID", obj.userGroupID);
            ID = Save_Read(ref pEx, cmd);

            if (ID != 0)
            {
                //this.Add(new clsUsers_Item(ID, username, password, userGroupID));
                conn.Close();
                return ID;
            }
            else
            {
                conn.Close();
                return ID;
            }
        }
        catch (Exception ex)
        {
            pEx = ex;
        }
        conn.Close();
        return ID;
    }

    public bool Update_Item(ref Exception pEx, int ID, string username, string password, int userGroupID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateUsers";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@userGroupID", userGroupID);
            if (Save(ref pEx, cmd))
            {
                foreach (clsUsers_Item Item in this)
                {
                    if (Item.ID == ID)
                    {
                        Item.ID = ID;
                        Item.username = username;
                        Item.password = password;
                        Item.userGroupID = userGroupID;
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
            cmd.CommandText = "usp_DeleteUsers";
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

    public bool ChangePassword(ref Exception pEx, int ID, string currentPassword, string newPassword)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ChangePassword";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@currentPassword", currentPassword);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
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
    /// <summary>
    /// Returns the System Generated ID if successful
    /// </summary>
    /// <param name="pEx">By ref Exception</param>
    /// <param name="cmd">Sql Command to execute</param>
    /// <returns></returns>
    private int Save_Read(ref Exception pEx, SqlCommand cmd)
    {
        int ID = 0;
        try
        {
            var retVal = cmd.ExecuteScalar().ToString();
            ID = Convert.ToInt32(retVal);
            return ID;
        }
        catch (Exception ex)
        {
            pEx = ex;
            return ID;
        }
    }
}

public class clsUsers_Item
{
    private int _ID;
    private string _username;
    private string _password;
    private int _userGroupID;
    private bool _isDeleted;

    public clsUsers_Item()
    {
        //Default constructor
    }

    public clsUsers_Item(int ID, string username, string password, int userGroupID)
    {
        _ID = ID;
        _username = username;
        _password = password;
        _userGroupID = userGroupID;
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
    public string username
    {
        get
        {
            return _username;
        }

        set
        {
            if (!(_username == value))
            {
                _username = value;
            }
        }
    }

    [XmlElement(typeof(string))]
    public string password
    {
        get
        {
            return _password;
        }

        set
        {
            if (!(_password == value))
            {
                _password = value;
            }
        }
    }

    [XmlElement(typeof(int))]
    public int userGroupID
    {
        get
        {
            return _userGroupID;
        }

        set
        {
            if (!(_userGroupID == value))
            {
                _userGroupID = value;
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


public class clsUsersVerify_List : List<clsUsersVerify_Item>
{
    private string _connectionString = string.Empty;
    public clsUsersVerify_List(string connectionString)
    {
        _connectionString = connectionString;
    }
    public clsUsersVerify_List(string connectionString, ref Exception pEx, string username, string password)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_VerifyUsernameAndPassword";
            if (!(username == string.Empty)) cmd.Parameters.AddWithValue("@username", username);
            if (!(password == string.Empty)) cmd.Parameters.AddWithValue("@password", password);
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
                clsUsersVerify_Item tmp = new clsUsersVerify_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["username"] == DBNull.Value)) tmp.username = (string)data_reader["username"];
                if (!(data_reader["permissionString"] == DBNull.Value)) tmp.userGroupPermissionString = (string)data_reader["permissionString"];
                this.Add(tmp);
            }
        }
    }
}
public class clsUsersVerify_Item
{
    private int _ID;
    private string _username;
    private string _userGroupPermissionString;

    public clsUsersVerify_Item()
    {
        //Default constructor
    }

    public clsUsersVerify_Item(int ID, string username, string password, string userGroupPermissionString)
    {
        _ID = ID;
        _username = username;
        _userGroupPermissionString = userGroupPermissionString;
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
    public string username
    {
        get
        {
            return _username;
        }

        set
        {
            if (!(_username == value))
            {
                _username = value;
            }
        }
    }

    [XmlElement(typeof(int))]
    public string userGroupPermissionString
    {
        get
        {
            return _userGroupPermissionString;
        }

        set
        {
            if (!(_userGroupPermissionString == value))
            {
                _userGroupPermissionString = value;
            }
        }
    }
}


