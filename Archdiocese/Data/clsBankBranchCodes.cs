
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsBankBranchCodes_List : List<clsBankBranchCodes_Item>
{
    private string _connectionString = string.Empty;

    public clsBankBranchCodes_List(string connectionString)
    {
        _connectionString = connectionString;
    }

    public clsBankBranchCodes_List(string connectionString, ref Exception pEx, int ID, string code, string description)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetBankBranchCodes";
            if (!(ID == 0)) cmd.Parameters.AddWithValue("@ID", ID);
            if (!(code == string.Empty)) cmd.Parameters.AddWithValue("@code", code);
            if (!(description == string.Empty)) cmd.Parameters.AddWithValue("@description", description);
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
                clsBankBranchCodes_Item tmp = new clsBankBranchCodes_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["code"] == DBNull.Value)) tmp.code = (string)data_reader["code"];
                if (!(data_reader["description"] == DBNull.Value)) tmp.description = (string)data_reader["description"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsBankBranchCodes_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertBankBranchCodes";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@code", obj.code);
            cmd.Parameters.AddWithValue("@description", obj.description);
            if (Save(ref pEx, cmd))
            {
                this.Add(new clsBankBranchCodes_Item(obj.ID, obj.code, obj.description));
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

    public bool Update_Item(ref Exception pEx, clsBankBranchCodes_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateBankBranchCodes";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@code", obj.code);
            cmd.Parameters.AddWithValue("@description", obj.description);
            if (Save(ref pEx, cmd))
            {
                foreach (clsBankBranchCodes_Item Item in this)
                {
                    //if (Item.ID == ID)
                    //{
                    //    Item.ID = ID;
                    //    Item.code = code;
                    //    Item.description = description;
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
            cmd.CommandText = "usp_DeleteBankBranchCodes";
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
            cmd.CommandText = "usp_EnableBankBranchCodes";
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
            cmd.CommandText = "usp_DisableBankBranchCodes";
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

public class clsBankBranchCodes_Item
{
    private int _ID;
    private string _code;
    private string _description;
    private bool _isDeleted;


    public clsBankBranchCodes_Item()
    {
        //Default constructor
    }

    public clsBankBranchCodes_Item(int ID, string code, string description)
    {
        _ID = ID;
        _code = code;
        _description = description;
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
    public string code
    {
        get
        {
            return _code;
        }

        set
        {
            if (!(_code == value))
            {
                _code = value;

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


