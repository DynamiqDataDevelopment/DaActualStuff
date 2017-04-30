
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsTelephoneNumbers_List : List<clsTelephoneNumbers_Item>
{
    private string _connectionString = string.Empty;

    public clsTelephoneNumbers_List(string connectionString)
    {
        _connectionString = connectionString;
    }
    public clsTelephoneNumbers_List(string connectionString, ref Exception pEx, int entityID, int telephoneNumberTypeID, string telephoneNumber, bool isDefault)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetTelephoneNumbers";
            cmd.Parameters.AddWithValue("@entityID", entityID);
            cmd.Parameters.AddWithValue("@telephoneNumberTypeID", telephoneNumberTypeID);
            if (!(telephoneNumber == string.Empty)) cmd.Parameters.AddWithValue("@telephoneNumber", telephoneNumber);
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
                clsTelephoneNumbers_Item tmp = new clsTelephoneNumbers_Item();
                if (!(data_reader["entityID"] == DBNull.Value)) tmp.entityID = (int)data_reader["entityID"];
                if (!(data_reader["telephoneNumberTypeID"] == DBNull.Value)) tmp.telephoneNumberTypeID = (int)data_reader["telephoneNumberTypeID"];
                if (!(data_reader["telephoneNumber"] == DBNull.Value)) tmp.telephoneNumber = (string)data_reader["telephoneNumber"];
                if (!(data_reader["isDefault"] == DBNull.Value)) tmp.isDefault = (bool)data_reader["isDefault"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsTelephoneNumbers_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertTelephoneNumbers";
            cmd.Parameters.AddWithValue("@entityID", obj.entityID);
            cmd.Parameters.AddWithValue("@telephoneNumberTypeID", obj.telephoneNumberTypeID);
            cmd.Parameters.AddWithValue("@telephoneNumber", obj.telephoneNumber);
            cmd.Parameters.AddWithValue("@isDefault", obj.isDefault);
            if (Save(ref pEx, cmd))
            {
                //this.Add(new clsTelephoneNumbers_Item(entityID, telephoneNumberTypeID, telephoneNumber, isDefault));
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

    public bool Update_Item(ref Exception pEx, clsTelephoneNumbers_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateTelephoneNumbers";
            cmd.Parameters.AddWithValue("@entityID", obj.entityID);
            cmd.Parameters.AddWithValue("@telephoneNumberTypeID", obj.telephoneNumberTypeID);
            cmd.Parameters.AddWithValue("@telephoneNumber", obj.telephoneNumber);
            cmd.Parameters.AddWithValue("@isDefault", obj.isDefault);
            if (Save(ref pEx, cmd))
            {
                foreach (clsTelephoneNumbers_Item Item in this)
                {
                    //if (Item.telephoneNumberTypeID == telephoneNumberTypeID)
                    //{
                    //    Item.entityID = entityID;
                    //    Item.telephoneNumberTypeID = telephoneNumberTypeID;
                    //    Item.telephoneNumber = telephoneNumber;
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

    public bool Delete_Item(ref Exception pEx, int telephoneNumberTypeID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteTelephoneNumbers";
            cmd.Parameters.AddWithValue("@telephoneNumberTypeID", telephoneNumberTypeID);
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

    public bool Enable_Item(ref Exception pEx, int telephoneNumberTypeID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EnableTelephoneNumbers";
            cmd.Parameters.AddWithValue("@telephoneNumberTypeID", telephoneNumberTypeID);
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

    public bool Disable_Item(ref Exception pEx, int telephoneNumberTypeID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DisableTelephoneNumbers";
            cmd.Parameters.AddWithValue("@telephoneNumberTypeID", telephoneNumberTypeID);
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

public class clsTelephoneNumbers_Item
{
    private int _entityID;
    private int _telephoneNumberTypeID;
    private string _telephoneNumber;
    private bool _isDefault;


    public clsTelephoneNumbers_Item()
    {
        //Default constructor
    }

    public clsTelephoneNumbers_Item(int entityID, int telephoneNumberTypeID, string telephoneNumber, bool isDefault)
    {
        _entityID = entityID;
        _telephoneNumberTypeID = telephoneNumberTypeID;
        _telephoneNumber = telephoneNumber;
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
    public int telephoneNumberTypeID
    {
        get
        {
            return _telephoneNumberTypeID;
        }

        set
        {
            if (!(_telephoneNumberTypeID == value))
            {
                _telephoneNumberTypeID = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string telephoneNumber
    {
        get
        {
            return _telephoneNumber;
        }

        set
        {
            if (!(_telephoneNumber == value))
            {
                _telephoneNumber = value;

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


