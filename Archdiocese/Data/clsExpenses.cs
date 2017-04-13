
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsExpenses_List : List<clsExpenses_Item>
{
    private string _connectionString = string.Empty;

    public clsExpenses_List(string connectionString)
    {
        _connectionString = connectionString;
    }
    public clsExpenses_List(string connectionString, ref Exception pEx, int ID, int parishUserID, Single amount, string description, int expenseTypeID, DateTime expenseDate, DateTime dateSubmitted)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetExpenses";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@parishUserID", parishUserID);
            cmd.Parameters.AddWithValue("@amount", amount);
            if (!(description == string.Empty)) cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@expenseTypeID", expenseTypeID);
            cmd.Parameters.AddWithValue("@expenseDate", expenseDate);
            cmd.Parameters.AddWithValue("@dateSubmitted", dateSubmitted);
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
                clsExpenses_Item tmp = new clsExpenses_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["parishUserID"] == DBNull.Value)) tmp.parishUserID = (int)data_reader["parishUserID"];
                if (!(data_reader["amount"] == DBNull.Value)) tmp.amount = (Single)data_reader["amount"];
                if (!(data_reader["description"] == DBNull.Value)) tmp.description = (string)data_reader["description"];
                if (!(data_reader["expenseTypeID"] == DBNull.Value)) tmp.expenseTypeID = (int)data_reader["expenseTypeID"];
                if (!(data_reader["expenseDate"] == DBNull.Value)) tmp.expenseDate = (DateTime)data_reader["expenseDate"];
                if (!(data_reader["dateSubmitted"] == DBNull.Value)) tmp.dateSubmitted = (DateTime)data_reader["dateSubmitted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsExpenses_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertExpenses";
            //cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@parishUserID", obj.parishUserID);
            cmd.Parameters.AddWithValue("@amount", obj.amount);
            cmd.Parameters.AddWithValue("@description", obj.description);
            cmd.Parameters.AddWithValue("@expenseTypeID", obj.expenseTypeID);
            cmd.Parameters.AddWithValue("@expenseDate", obj.expenseDate);
            //cmd.Parameters.AddWithValue("@dateSubmitted", obj.dateSubmitted);
            if (Save(ref pEx, cmd))
            {
                //this.Add(new clsExpenses_Item(ID, parishUserID, amount, description, expenseTypeID, expenseDate, dateSubmitted));
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

    public bool Update_Item(ref Exception pEx, clsExpenses_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateExpenses";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@parishUserID", obj.parishUserID);
            cmd.Parameters.AddWithValue("@amount", obj.amount);
            cmd.Parameters.AddWithValue("@description", obj.description);
            cmd.Parameters.AddWithValue("@expenseTypeID", obj.expenseTypeID);
            cmd.Parameters.AddWithValue("@expenseDate", obj.expenseDate);
            cmd.Parameters.AddWithValue("@dateSubmitted", obj.dateSubmitted);
            if (Save(ref pEx, cmd))
            {
                foreach (clsExpenses_Item Item in this)
                {
                    //if (Item.ID == ID)
                    //{
                    //	Item.ID = ID;
                    //		Item.parishUserID = parishUserID;
                    //		Item.amount = amount;
                    //		Item.description = description;
                    //		Item.expenseTypeID = expenseTypeID;
                    //		Item.expenseDate = expenseDate;
                    //		Item.dateSubmitted = dateSubmitted;
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

    public bool Delete_Item(ref Exception pEx, Guid ID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteExpenses";
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

    public bool Enable_Item(ref Exception pEx, Guid ID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EnableExpenses";
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

    public bool Disable_Item(ref Exception pEx, Guid ID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DisableExpenses";
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

public class clsExpenses_Item
{
    private int _ID;
    private int _parishUserID;
    private Single _amount;
    private string _description;
    private int _expenseTypeID;
    private DateTime _expenseDate;
    private DateTime _dateSubmitted;


    public clsExpenses_Item()
    {
        //Default constructor
    }

    public clsExpenses_Item(int ID, int parishUserID, Single amount, string description, int expenseTypeID, DateTime expenseDate, DateTime dateSubmitted)
    {
        _ID = ID;
        _parishUserID = parishUserID;
        _amount = amount;
        _description = description;
        _expenseTypeID = expenseTypeID;
        _expenseDate = expenseDate;
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

    [XmlElement(typeof(Single))]
    public Single amount
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
    public int expenseTypeID
    {
        get
        {
            return _expenseTypeID;
        }

        set
        {
            if (!(_expenseTypeID == value))
            {
                _expenseTypeID = value;

            }
        }
    }

    [XmlElement(typeof(DateTime))]
    public DateTime expenseDate
    {
        get
        {
            return _expenseDate;
        }

        set
        {
            if (!(_expenseDate == value))
            {
                _expenseDate = value;

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


