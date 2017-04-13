
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsParishPersonPledges_List : List<clsParishPersonPledges_Item>
{
    private string _connectionString = string.Empty;

    public clsParishPersonPledges_List(string connectionString)
    {
        _connectionString = connectionString;
    }

    public clsParishPersonPledges_List(string connectionString, ref Exception pEx, int personID, int parishID, decimal amount, int pledgeYear, int pledgeTypeID, bool isActive)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetParishPersonPledges";
            cmd.Parameters.AddWithValue("@personID", personID);
            cmd.Parameters.AddWithValue("@parishID", parishID);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@pledgeYear", pledgeYear);
            cmd.Parameters.AddWithValue("@pledgeTypeID", pledgeTypeID);
            cmd.Parameters.AddWithValue("@isActive", isActive);
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
                clsParishPersonPledges_Item tmp = new clsParishPersonPledges_Item();
                if (!(data_reader["personID"] == DBNull.Value)) tmp.personID = (int)data_reader["personID"];
                if (!(data_reader["parishID"] == DBNull.Value)) tmp.parishID = (int)data_reader["parishID"];
                if (!(data_reader["amount"] == DBNull.Value)) tmp.amount = (decimal)data_reader["amount"];
                if (!(data_reader["pledgeYear"] == DBNull.Value)) tmp.pledgeYear = (int)data_reader["pledgeYear"];
                if (!(data_reader["pledgeTypeID"] == DBNull.Value)) tmp.pledgeTypeID = (int)data_reader["pledgeTypeID"];
                if (!(data_reader["isActive"] == DBNull.Value)) tmp.isActive = (bool)data_reader["isActive"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsParishPersonPledges_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertParishPersonPledges";
            cmd.Parameters.AddWithValue("@personID", obj.personID);
            cmd.Parameters.AddWithValue("@parishID", obj.parishID);
            cmd.Parameters.AddWithValue("@amount", obj.amount);
            cmd.Parameters.AddWithValue("@pledgeYear", obj.pledgeYear);
            cmd.Parameters.AddWithValue("@pledgeTypeID", obj.pledgeTypeID);
            cmd.Parameters.AddWithValue("@isActive", obj.isActive);
            if (Save(ref pEx, cmd))
            {
                this.Add(new clsParishPersonPledges_Item(obj.personID, obj.parishID, obj.amount, obj.pledgeYear, obj.pledgeTypeID, obj.isActive));
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

    public bool Update_Item(ref Exception pEx, clsParishPersonPledges_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateParishPersonPledges";
            cmd.Parameters.AddWithValue("@personID", obj.personID);
            cmd.Parameters.AddWithValue("@parishID", obj.parishID);
            cmd.Parameters.AddWithValue("@amount", obj.amount);
            cmd.Parameters.AddWithValue("@pledgeYear", obj.pledgeYear);
            cmd.Parameters.AddWithValue("@pledgeTypeID", obj.pledgeTypeID);
            cmd.Parameters.AddWithValue("@isActive", obj.isActive);
            if (Save(ref pEx, cmd))
            {
                //foreach (clsParishPersonPledges_Item Item in this)
                //{
                //    if (Item.pledgeYear == pledgeYear)
                //    {
                //        Item.personID = personID;
                //        Item.parishID = parishID;
                //        Item.amount = amount;
                //        Item.pledgeYear = pledgeYear;
                //        Item.isActive = isActive;
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

    public bool Delete_Item(ref Exception pEx, Guid pledgeYear)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteParishPersonPledges";
            cmd.Parameters.AddWithValue("@pledgeYear", pledgeYear);
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

    public bool Enable_Item(ref Exception pEx, Guid pledgeYear)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EnableParishPersonPledges";
            cmd.Parameters.AddWithValue("@pledgeYear", pledgeYear);
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

    public bool Disable_Item(ref Exception pEx, Guid pledgeYear)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DisableParishPersonPledges";
            cmd.Parameters.AddWithValue("@pledgeYear", pledgeYear);
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

public class clsParishPersonPledges_Item
{
    private int _personID;
    private int _parishID;
    private decimal _amount;
    private int _pledgeYear;
    private int _pledgeTypeID;
    private bool _isActive;


    public clsParishPersonPledges_Item()
    {
        //Default constructor
    }

    public clsParishPersonPledges_Item(int personID, int parishID, decimal amount, int pledgeYear, int pledgeTypeID, bool isActive)
    {
        _personID = personID;
        _parishID = parishID;
        _amount = amount;
        _pledgeYear = pledgeYear;
        _pledgeTypeID = pledgeTypeID;
        _isActive = isActive;
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
    public int pledgeYear
    {
        get
        {
            return _pledgeYear;
        }

        set
        {
            if (!(_pledgeYear == value))
            {
                _pledgeYear = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int pledgeTypeID
    {
        get
        {
            return _pledgeTypeID;
        }

        set
        {
            if (!(_pledgeTypeID == value))
            {
                _pledgeTypeID = value;

            }
        }
    }

    [XmlElement(typeof(bool))]
    public bool isActive
    {
        get
        {
            return _isActive;
        }

        set
        {
            if (!(_isActive == value))
            {
                _isActive = value;

            }
        }
    }
}


