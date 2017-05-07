
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsIncomes_List : List<clsIncomes_Item>
{
    private string _connectionString = string.Empty;

    public clsIncomes_List(string connectionString)
    {
        _connectionString = connectionString;
    }
    public clsIncomes_List(string connectionString, ref Exception pEx, int ID, int parishUserID, decimal amount, string description, int incomeTypeID, DateTime incomeDate, DateTime dateSubmitted)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetIncomes";
            //cmd.Parameters.AddWithValue("@ID", ID);
            //cmd.Parameters.AddWithValue("@parishUserID", parishUserID);
            //cmd.Parameters.AddWithValue("@amount", amount);
            //if (!(description == string.Empty)) cmd.Parameters.AddWithValue("@description", description);
            //cmd.Parameters.AddWithValue("@incomeTypeID", incomeTypeID);
            //cmd.Parameters.AddWithValue("@incomeDate", incomeDate);
            //cmd.Parameters.AddWithValue("@dateSubmitted", dateSubmitted);
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
                clsIncomes_Item tmp = new clsIncomes_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["parishUserID"] == DBNull.Value)) tmp.parishUserID = (int)data_reader["parishUserID"];
                if (!(data_reader["amount"] == DBNull.Value)) tmp.amount = (decimal)data_reader["amount"];
                if (!(data_reader["description"] == DBNull.Value)) tmp.description = (string)data_reader["description"];
                if (!(data_reader["incomeTypeID"] == DBNull.Value)) tmp.incomeTypeID = (int)data_reader["incomeTypeID"];
                if (!(data_reader["incomeDate"] == DBNull.Value)) tmp.incomeDate = (DateTime)data_reader["incomeDate"];
                if (!(data_reader["dateSubmitted"] == DBNull.Value)) tmp.dateSubmitted = (DateTime)data_reader["dateSubmitted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsIncomes_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertIncomes";
            //cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@parishUserID", obj.parishUserID);
            cmd.Parameters.AddWithValue("@amount", obj.amount);
            cmd.Parameters.AddWithValue("@description", obj.description);
            cmd.Parameters.AddWithValue("@incomeTypeID", obj.incomeTypeID);
            cmd.Parameters.AddWithValue("@incomeDate", obj.incomeDate);
            //cmd.Parameters.AddWithValue("@dateSubmitted", obj.dateSubmitted);
            if (Save(ref pEx, cmd))
            {
                //this.Add(new clsIncomes_Item(ID, parishUserID, amount, description, incomeTypeID, incomeDate, dateSubmitted));
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

    public bool Update_Item(ref Exception pEx, clsIncomes_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateIncomes";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@parishUserID", obj.parishUserID);
            cmd.Parameters.AddWithValue("@amount", obj.amount);
            cmd.Parameters.AddWithValue("@description", obj.description);
            cmd.Parameters.AddWithValue("@incomeTypeID", obj.incomeTypeID);
            cmd.Parameters.AddWithValue("@incomeDate", obj.incomeDate);
            cmd.Parameters.AddWithValue("@dateSubmitted", obj.dateSubmitted);
            if (Save(ref pEx, cmd))
            {
                foreach (clsIncomes_Item Item in this)
                {
                    //if (Item.ID == ID)
                    //{
                    //    Item.ID = ID;
                    //    Item.parishUserID = parishUserID;
                    //    Item.amount = amount;
                    //    Item.description = description;
                    //    Item.incomeTypeID = incomeTypeID;
                    //    Item.incomeDate = incomeDate;
                    //    Item.dateSubmitted = dateSubmitted;
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

    public bool Delete_Item(ref Exception pEx, int ID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteIncomes";
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
            cmd.CommandText = "usp_EnableIncomes";
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
            cmd.CommandText = "usp_DisableIncomes";
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

public class clsIncomes_Item
{
    private int _ID;
    private int _parishUserID;
    private decimal _amount;
    private string _description;
    private int _incomeTypeID;
    private DateTime _incomeDate;
    private DateTime _dateSubmitted;


    public clsIncomes_Item()
    {
        //Default constructor
    }

    public clsIncomes_Item(int ID, int parishUserID, decimal amount, string description, int incomeTypeID, DateTime incomeDate, DateTime dateSubmitted)
    {
        _ID = ID;
        _parishUserID = parishUserID;
        _amount = amount;
        _description = description;
        _incomeTypeID = incomeTypeID;
        _incomeDate = incomeDate;
        _dateSubmitted = dateSubmitted;
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

    [XmlElement(typeof(string))]
    public string description
    {
        get
        {
            return _description;
        }

        set
        {
            if (!(_description == value))
            {
                _description = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int incomeTypeID
    {
        get
        {
            return _incomeTypeID;
        }

        set
        {
            if (!(_incomeTypeID == value))
            {
                _incomeTypeID = value;

            }
        }
    }

    [XmlElement(typeof(DateTime))]
    public DateTime incomeDate
    {
        get
        {
            return _incomeDate;
        }

        set
        {
            if (!(_incomeDate == value))
            {
                _incomeDate = value;

            }
        }
    }

    [XmlElement(typeof(DateTime))]
    public DateTime dateSubmitted
    {
        get
        {
            return _dateSubmitted;
        }

        set
        {
            if (!(_dateSubmitted == value))
            {
                _dateSubmitted = value;

            }
        }
    }


}


