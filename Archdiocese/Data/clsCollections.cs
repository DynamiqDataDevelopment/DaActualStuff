
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsCollections_List : List<clsCollections_Item>
{
    private string _connectionString = string.Empty;

    public clsCollections_List(string connectionString)
    {
        _connectionString = connectionString;
    }

    public clsCollections_List(string connectionString, ref Exception pEx, int ID, int parishUserID, int personID, int parishID, decimal amount, int collectionTypeID, DateTime collectionDateTime)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetCollections";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@parishUserID", parishUserID);
            cmd.Parameters.AddWithValue("@personID", personID);
            cmd.Parameters.AddWithValue("@parishID", parishID);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@collectionTypeID", collectionTypeID);
            cmd.Parameters.AddWithValue("@collectionDateTime", collectionDateTime);
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
                clsCollections_Item tmp = new clsCollections_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["parishUserID"] == DBNull.Value)) tmp.parishUserID = (int)data_reader["parishUserID"];
                if (!(data_reader["personID"] == DBNull.Value)) tmp.personID = (int)data_reader["personID"];
                if (!(data_reader["parishID"] == DBNull.Value)) tmp.parishID = (int)data_reader["parishID"];
                if (!(data_reader["amount"] == DBNull.Value)) tmp.amount = (decimal)data_reader["amount"];
                if (!(data_reader["collectionTypeID"] == DBNull.Value)) tmp.collectionTypeID = (int)data_reader["collectionTypeID"];
                if (!(data_reader["collectionDateTime"] == DBNull.Value)) tmp.collectionDateTime = (DateTime)data_reader["collectionDateTime"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsCollections_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertCollections";
            //cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@parishUserID", obj.parishUserID);
            cmd.Parameters.AddWithValue("@personID", obj.personID);
            cmd.Parameters.AddWithValue("@parishID", obj.parishID);
            cmd.Parameters.AddWithValue("@amount", obj.amount);
            cmd.Parameters.AddWithValue("@collectionTypeID", obj.collectionTypeID);
            cmd.Parameters.AddWithValue("@collectionDateTime", obj.collectionDateTime);
            if (Save(ref pEx, cmd))
            {
                //this.Add(new clsCollections_Item(ID, parishUserID, personID, parishID, amount, collectionTypeID, collectionDateTime));
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

    public bool Update_Item(ref Exception pEx, clsCollections_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateCollections";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@parishUserID", obj.parishUserID);
            cmd.Parameters.AddWithValue("@personID", obj.personID);
            cmd.Parameters.AddWithValue("@parishID", obj.parishID);
            cmd.Parameters.AddWithValue("@amount", obj.amount);
            cmd.Parameters.AddWithValue("@collectionTypeID", obj.collectionTypeID);
            cmd.Parameters.AddWithValue("@collectionDateTime", obj.collectionDateTime);
            if (Save(ref pEx, cmd))
            {
                //foreach (clsCollections_Item Item in this)
                //{
                //    if (Item.ID == ID)
                //    {
                //        Item.ID = ID;
                //        Item.parishUserID = parishUserID;
                //        Item.personID = personID;
                //        Item.parishID = parishID;
                //        Item.amount = amount;
                //        Item.collectionTypeID = collectionTypeID;
                //        Item.collectionDateTime = collectionDateTime;
                //    }
                //}
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
            cmd.CommandText = "usp_DeleteCollections";
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
            cmd.CommandText = "usp_EnableCollections";
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
            cmd.CommandText = "usp_DisableCollections";
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

public class clsCollections_Item
{
    private int _ID;
    private int _parishUserID;
    private int _personID;
    private int _parishID;
    private decimal _amount;
    private int _collectionTypeID;
    private DateTime _collectionDateTime;
    private bool _isDeleted;


    public clsCollections_Item()
    {
        //Default constructor
    }

    public clsCollections_Item(int ID, int parishUserID, int personID, int parishID, decimal amount, int collectionTypeID, DateTime collectionDateTime)
    {
        _ID = ID;
        _parishUserID = parishUserID;
        _personID = personID;
        _parishID = parishID;
        _amount = amount;
        _collectionTypeID = collectionTypeID;
        _collectionDateTime = collectionDateTime;
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

    [XmlElement(typeof(int))]
    public int parishUserID
    {
        get
        {
            return _parishUserID;
        }

        set
        {
            if (!(_parishUserID == value))
            {
                _parishUserID = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int personID
    {
        get
        {
            return _personID;
        }

        set
        {
            if (!(_personID == value))
            {
                _personID = value;

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

            }
        }
    }

    [XmlElement(typeof(decimal))]
    public decimal amount
    {
        get
        {
            return _amount;
        }

        set
        {
            if (!(_amount == value))
            {
                _amount = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int collectionTypeID
    {
        get
        {
            return _collectionTypeID;
        }

        set
        {
            if (!(_collectionTypeID == value))
            {
                _collectionTypeID = value;

            }
        }
    }

    [XmlElement(typeof(DateTime))]
    public DateTime collectionDateTime
    {
        get
        {
            return _collectionDateTime;
        }

        set
        {
            if (!(_collectionDateTime == value))
            {
                _collectionDateTime = value;

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


