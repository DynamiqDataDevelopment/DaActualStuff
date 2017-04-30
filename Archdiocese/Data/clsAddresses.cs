
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsAddresses_List : List<clsAddresses_Item>
{
    private string _connectionString = string.Empty;
    public clsAddresses_List(string connectionString)
    {
        _connectionString = connectionString;
    }
    public clsAddresses_List(string connectionString, ref Exception pEx, int entityID, int addressTypeID, string addressLine1, string addressLine2, string addressLine3, string suburb, string city, string postalCode)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetAddresses";
            cmd.Parameters.AddWithValue("@entityID", entityID);
            cmd.Parameters.AddWithValue("@addressTypeID", addressTypeID);
            if (!(addressLine1 == string.Empty)) cmd.Parameters.AddWithValue("@addressLine1", addressLine1);
            if (!(addressLine2 == string.Empty)) cmd.Parameters.AddWithValue("@addressLine2", addressLine2);
            if (!(addressLine3 == string.Empty)) cmd.Parameters.AddWithValue("@addressLine3", addressLine3);
            if (!(suburb == string.Empty)) cmd.Parameters.AddWithValue("@suburb", suburb);
            if (!(city == string.Empty)) cmd.Parameters.AddWithValue("@city", city);
            if (!(city == string.Empty)) cmd.Parameters.AddWithValue("@postalCode", postalCode);
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
                clsAddresses_Item tmp = new clsAddresses_Item();
                if (!(data_reader["entityID"] == DBNull.Value)) tmp.entityID = (int)data_reader["entityID"];
                if (!(data_reader["addressTypeID"] == DBNull.Value)) tmp.addressTypeID = (int)data_reader["addressTypeID"];
                if (!(data_reader["addressLine1"] == DBNull.Value)) tmp.addressLine1 = (string)data_reader["addressLine1"];
                if (!(data_reader["addressLine2"] == DBNull.Value)) tmp.addressLine2 = (string)data_reader["addressLine2"];
                if (!(data_reader["addressLine3"] == DBNull.Value)) tmp.addressLine3 = (string)data_reader["addressLine3"];
                if (!(data_reader["suburb"] == DBNull.Value)) tmp.suburb = (string)data_reader["suburb"];
                if (!(data_reader["city"] == DBNull.Value)) tmp.city = (string)data_reader["city"];
                if (!(data_reader["postalCode"] == DBNull.Value)) tmp.postalCode = (string)data_reader["postalCode"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsAddresses_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertAddresses";
            cmd.Parameters.AddWithValue("@entityID", obj.entityID);
            cmd.Parameters.AddWithValue("@addressTypeID", obj.addressTypeID);
            cmd.Parameters.AddWithValue("@addressLine1", obj.addressLine1);
            if (!(obj.addressLine2 == string.Empty)) cmd.Parameters.AddWithValue("@addressLine2", obj.addressLine2);
            if (!(obj.addressLine3 == string.Empty)) cmd.Parameters.AddWithValue("@addressLine3", obj.addressLine3);
            cmd.Parameters.AddWithValue("@suburb", obj.suburb);
            cmd.Parameters.AddWithValue("@city", obj.city);
            cmd.Parameters.AddWithValue("@postalCode", obj.postalCode);
            if (Save(ref pEx, cmd))
            {
                //this.Add(new clsAddresses_Item(entityID, addressTypeID, addressLine1, addressLine2, addressLine3, suburb, city));
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

    public bool Update_Item(ref Exception pEx, clsAddresses_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateAddresses";
            cmd.Parameters.AddWithValue("@entityID", obj.entityID);
            cmd.Parameters.AddWithValue("@addressTypeID", obj.addressTypeID);
            cmd.Parameters.AddWithValue("@addressLine1", obj.addressLine1);
            if (!(obj.addressLine2 == string.Empty)) cmd.Parameters.AddWithValue("@addressLine2", obj.addressLine2);
            if (!(obj.addressLine3 == string.Empty)) cmd.Parameters.AddWithValue("@addressLine3", obj.addressLine3);
            cmd.Parameters.AddWithValue("@suburb", obj.suburb);
            cmd.Parameters.AddWithValue("@city", obj.city);
            cmd.Parameters.AddWithValue("@postalCode", obj.postalCode);
            if (Save(ref pEx, cmd))
            {
                foreach (clsAddresses_Item Item in this)
                {
                    //if (Item.addressTypeID == addressTypeID)
                    //{
                    //	Item.entityID = entityID;
                    //		Item.addressTypeID = addressTypeID;
                    //		Item.addressLine1 = addressLine1;
                    //		Item.addressLine2 = addressLine2;
                    //		Item.addressLine3 = addressLine3;
                    //		Item.suburb = suburb;
                    //		Item.city = city;
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

    public bool Delete_Item(ref Exception pEx, int addressTypeID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteAddresses";
            cmd.Parameters.AddWithValue("@addressTypeID", addressTypeID);
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

    public bool Enable_Item(ref Exception pEx, int addressTypeID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EnableAddresses";
            cmd.Parameters.AddWithValue("@addressTypeID", addressTypeID);
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

    public bool Disable_Item(ref Exception pEx, int addressTypeID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DisableAddresses";
            cmd.Parameters.AddWithValue("@addressTypeID", addressTypeID);
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

public class clsAddresses_Item
{
    private int _entityID;
    private int _addressTypeID;
    private string _addressLine1;
    private string _addressLine2;
    private string _addressLine3;
    private string _suburb;
    private string _city;
    private string _postalCode;


    public clsAddresses_Item()
    {
        //Default constructor
    }

    public clsAddresses_Item(int entityID, int addressTypeID, string addressLine1, string addressLine2, string addressLine3, string suburb, string city)
    {
        _entityID = entityID;
        _addressTypeID = addressTypeID;
        _addressLine1 = addressLine1;
        _addressLine2 = addressLine2;
        _addressLine3 = addressLine3;
        _suburb = suburb;
        _city = city;
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
    public int addressTypeID
    {
        get
        {
            return _addressTypeID;
        }

        set
        {
            if (!(_addressTypeID == value))
            {
                _addressTypeID = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string addressLine1
    {
        get
        {
            return _addressLine1;
        }

        set
        {
            if (!(_addressLine1 == value))
            {
                _addressLine1 = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string addressLine2
    {
        get
        {
            return _addressLine2;
        }

        set
        {
            if (!(_addressLine2 == value))
            {
                _addressLine2 = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string addressLine3
    {
        get
        {
            return _addressLine3;
        }

        set
        {
            if (!(_addressLine3 == value))
            {
                _addressLine3 = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string suburb
    {
        get
        {
            return _suburb;
        }

        set
        {
            if (!(_suburb == value))
            {
                _suburb = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string city
    {
        get
        {
            return _city;
        }

        set
        {
            if (!(_city == value))
            {
                _city = value;

            }
        }
    }

    public string postalCode
    {
        get
        {
            return _postalCode;
        }

        set
        {
            if (!(_postalCode == value))
            {
                _postalCode = value;

            }
        }
    }


}


