
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsCollectionTypes_List : List<clsCollectionTypes_Item>
{
    private string _connectionString = string.Empty;    

    public clsCollectionTypes_List(string connectionString)
    {
        _connectionString = connectionString;
    }
    public clsCollectionTypes_List(string connectionString, ref Exception pEx, int ID, string collectionTypeDescription)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetCollectionTypes";
            if (!(ID == 0)) cmd.Parameters.AddWithValue("@ID", ID);
            if (!(collectionTypeDescription == string.Empty)) cmd.Parameters.AddWithValue("@collectionTypeDescription", collectionTypeDescription);
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
                clsCollectionTypes_Item tmp = new clsCollectionTypes_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["collectionTypeDescription"] == DBNull.Value)) tmp.collectionTypeDescription = (string)data_reader["collectionTypeDescription"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsCollectionTypes_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertCollectionTypes";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@collectionTypeDescription", obj.collectionTypeDescription);
            if (Save(ref pEx, cmd))
            {
                this.Add(new clsCollectionTypes_Item(obj.ID, obj.collectionTypeDescription));
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

    public bool Update_Item(ref Exception pEx, clsCollectionTypes_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateCollectionTypes";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@collectionTypeDescription", obj.collectionTypeDescription);
            if (Save(ref pEx, cmd))
            {
                foreach (clsCollectionTypes_Item Item in this)
                {
                    if (Item.ID == obj.ID)
                    {
                        Item.ID = obj.ID;
                        Item.collectionTypeDescription = obj.collectionTypeDescription;
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

    public bool Enable_Item(ref Exception pEx, int ID, bool enable)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = enable ? "usp_EnableCollectionTypes" : "usp_DisableCollectionTypes";
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

public class clsCollectionTypes_Item
{
    private int _ID;
    private string _collectionTypeDescription;
    private bool _isDeleted;


    public clsCollectionTypes_Item()
    {
        //Default constructor
    }

    public clsCollectionTypes_Item(int ID, string collectionTypeDescription)
    {
        _ID = ID;
        _collectionTypeDescription = collectionTypeDescription;
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
    public string collectionTypeDescription
    {
        get
        {
            return _collectionTypeDescription;
        }

        set
        {
            if (!(_collectionTypeDescription == value))
            {
                _collectionTypeDescription = value;
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


