
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsExpenseTypesLevel1_List : List<clsExpenseTypesLevel1_Item>
{
    private string _connectionString = string.Empty;
    

    public clsExpenseTypesLevel1_List(string connectionString, ref Exception pEx, int ID, string description, string accountNumber)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetExpenseTypesLevel1";
            cmd.Parameters.AddWithValue("@ID", ID);
            if (!(description == string.Empty)) cmd.Parameters.AddWithValue("@description", description);
            if (!(accountNumber == string.Empty)) cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
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
                clsExpenseTypesLevel1_Item tmp = new clsExpenseTypesLevel1_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["description"] == DBNull.Value)) tmp.description = (string)data_reader["description"];
                if (!(data_reader["accountNumber"] == DBNull.Value)) tmp.accountNumber = (string)data_reader["accountNumber"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsExpenseTypesLevel1_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertExpenseTypesLevel1";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@description", obj.description);
            cmd.Parameters.AddWithValue("@accountNumber", obj.accountNumber);
            if (Save(ref pEx, cmd))
            {
                //this.Add(new clsExpenseTypesLevel1_Item(ID, description, accountNumber));
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

    public bool Update_Item(ref Exception pEx, clsExpenseTypesLevel1_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateExpenseTypesLevel1";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@description", obj.description);
            cmd.Parameters.AddWithValue("@accountNumber", obj.accountNumber);
            if (Save(ref pEx, cmd))
            {
                foreach (clsExpenseTypesLevel1_Item Item in this)
                {
                    //if (Item.ID == ID)
                    //{
                    //    Item.ID = ID;
                    //    Item.description = description;
                    //    Item.accountNumber = accountNumber;
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
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteExpenseTypesLevel1";
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
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EnableExpenseTypesLevel1";
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
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DisableExpenseTypesLevel1";
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

public class clsExpenseTypesLevel1_Item
{
    private int _ID;
    private string _description;
    private string _accountNumber;
    private bool _isDeleted;


    public clsExpenseTypesLevel1_Item()
    {
        //Default constructor
    }

    public clsExpenseTypesLevel1_Item(int ID, string description, string accountNumber)
    {
        _ID = ID;
        _description = description;
        _accountNumber = accountNumber;
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

    [XmlElement(typeof(string))]
    public string accountNumber
    {
        get
        {
            return _accountNumber;
        }

        set
        {
            if (!(_accountNumber == value))
            {
                _accountNumber = value;

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


