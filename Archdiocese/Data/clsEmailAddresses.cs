
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsEmailAddresses_List : List<clsEmailAddresses_Item>
{
    private string _connectionString = string.Empty;

    public clsEmailAddresses_List(string connectionString)
    {
        _connectionString = connectionString;
    }
    public clsEmailAddresses_List(string connectionString, ref Exception pEx, int entityID, int emailAddressTypeID, string emailAddress, bool isDefault)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetEmailAddresses";
            cmd.Parameters.AddWithValue("@entityID", entityID);
            cmd.Parameters.AddWithValue("@emailAddressTypeID", emailAddressTypeID);
            if (!(emailAddress == string.Empty)) cmd.Parameters.AddWithValue("@emailAddress", emailAddress);
            cmd.Parameters.AddWithValue("@isDefault", isDefault);
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
                clsEmailAddresses_Item tmp = new clsEmailAddresses_Item();
                if (!(data_reader["entityID"] == DBNull.Value)) tmp.entityID = (int)data_reader["entityID"];
                if (!(data_reader["emailAddressTypeID"] == DBNull.Value)) tmp.emailAddressTypeID = (int)data_reader["emailAddressTypeID"];
                if (!(data_reader["emailAddress"] == DBNull.Value)) tmp.emailAddress = (string)data_reader["emailAddress"];
                if (!(data_reader["isDefault"] == DBNull.Value)) tmp.isDefault = (bool)data_reader["isDefault"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsEmailAddresses_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertEmailAddresses";
            cmd.Parameters.AddWithValue("@entityID", obj.entityID);
            cmd.Parameters.AddWithValue("@emailAddressTypeID", obj.emailAddressTypeID);
            cmd.Parameters.AddWithValue("@emailAddress", obj.emailAddress);
            cmd.Parameters.AddWithValue("@isDefault", obj.isDefault);
            if (Save(ref pEx, cmd))
            {
                //this.Add(new clsEmailAddresses_Item(entityID, emailAddressTypeID, emailAddress, isDefault));
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

    public bool Update_Item(ref Exception pEx, clsEmailAddresses_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateEmailAddresses";
            cmd.Parameters.AddWithValue("@entityID", obj.entityID);
            cmd.Parameters.AddWithValue("@emailAddressTypeID", obj.emailAddressTypeID);
            cmd.Parameters.AddWithValue("@emailAddress", obj.emailAddress);
            cmd.Parameters.AddWithValue("@isDefault", obj.isDefault);
            if (Save(ref pEx, cmd))
            {
                foreach (clsEmailAddresses_Item Item in this)
                {
                    //if (Item.emailAddressTypeID == emailAddressTypeID)
                    //{
                    //    Item.entityID = entityID;
                    //    Item.emailAddressTypeID = emailAddressTypeID;
                    //    Item.emailAddress = emailAddress;
                    //    Item.isDefault = isDefault;
                    //}
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

    public bool Delete_Item(ref Exception pEx, int emailAddressTypeID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteEmailAddresses";
            cmd.Parameters.AddWithValue("@emailAddressTypeID", emailAddressTypeID);
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

    public bool Enable_Item(ref Exception pEx, int emailAddressTypeID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EnableEmailAddresses";
            cmd.Parameters.AddWithValue("@emailAddressTypeID", emailAddressTypeID);
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

    public bool Disable_Item(ref Exception pEx, int emailAddressTypeID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DisableEmailAddresses";
            cmd.Parameters.AddWithValue("@emailAddressTypeID", emailAddressTypeID);
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

public class clsEmailAddresses_Item
{
    private int _entityID;
    private int _emailAddressTypeID;
    private string _emailAddress;
    private bool _isDefault;


    public clsEmailAddresses_Item()
    {
        //Default constructor
    }

    public clsEmailAddresses_Item(int entityID, int emailAddressTypeID, string emailAddress, bool isDefault)
    {
        _entityID = entityID;
        _emailAddressTypeID = emailAddressTypeID;
        _emailAddress = emailAddress;
        _isDefault = isDefault;
    }

    [XmlElement(typeof(int))]
    public int entityID
    {
        get
        {
            return _entityID;
        }

        set
        {
            if (!(_entityID == value))
            {
                _entityID = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int emailAddressTypeID
    {
        get
        {
            return _emailAddressTypeID;
        }

        set
        {
            if (!(_emailAddressTypeID == value))
            {
                _emailAddressTypeID = value;

            }
        }
    }

    [XmlElement(typeof(string))]
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

    [XmlElement(typeof(bool))]
    public bool isDefault
    {
        get
        {
            return _isDefault;
        }

        set
        {
            if (!(_isDefault == value))
            {
                _isDefault = value;

            }
        }
    }


}


