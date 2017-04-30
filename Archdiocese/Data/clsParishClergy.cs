
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsParishClergy_List : List<clsParishClergy_Item>
{
    private string _connectionString = string.Empty;

    public clsParishClergy_List(string connectionString)
    {
        _connectionString = connectionString;
    }

    public clsParishClergy_List(string connectionString, ref Exception pEx, int clergyID, int parishID, DateTime joinedDate, DateTime leftDate)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetParishClergy";
            cmd.Parameters.AddWithValue("@clergyID", clergyID);
            cmd.Parameters.AddWithValue("@parishID", parishID);
            cmd.Parameters.AddWithValue("@joinedDate", joinedDate);
            cmd.Parameters.AddWithValue("@leftDate", leftDate);
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
                clsParishClergy_Item tmp = new clsParishClergy_Item();
                if (!(data_reader["clergyID"] == DBNull.Value)) tmp.clergyID = (int)data_reader["clergyID"];
                if (!(data_reader["parishID"] == DBNull.Value)) tmp.parishID = (int)data_reader["parishID"];
                if (!(data_reader["joinedDate"] == DBNull.Value)) tmp.joinedDate = (DateTime)data_reader["joinedDate"];
                if (!(data_reader["leftDate"] == DBNull.Value)) tmp.leftDate = (DateTime)data_reader["leftDate"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsParishClergy_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertParishClergy";
            cmd.Parameters.AddWithValue("@clergyID", obj.clergyID);
            cmd.Parameters.AddWithValue("@parishID", obj.parishID);
            cmd.Parameters.AddWithValue("@joinedDate", obj.joinedDate);
            if (!(obj.leftDate == DateTime.MinValue)) cmd.Parameters.AddWithValue("@leftDate", obj.leftDate);
            if (Save(ref pEx, cmd))
            {
                //this.Add(new clsParishClergy_Item(clergyID, parishID, joinedDate, leftDate));
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

    public bool Update_Item(ref Exception pEx, clsParishClergy_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateParishClergy";
            cmd.Parameters.AddWithValue("@clergyID", obj.clergyID);
            cmd.Parameters.AddWithValue("@parishID", obj.parishID);
            cmd.Parameters.AddWithValue("@joinedDate", obj.joinedDate);
            if (!(obj.leftDate == DateTime.MinValue)) cmd.Parameters.AddWithValue("@leftDate", obj.leftDate);
            if (Save(ref pEx, cmd))
            {
                //foreach (clsParishClergy_Item Item in this)
                //{
                //    if (Item.parishID == parishID)
                //    {
                //        Item.clergyID = clergyID;
                //        Item.parishID = parishID;
                //        Item.joinedDate = joinedDate;
                //        Item.leftDate = leftDate;
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

    public bool Delete_Item(ref Exception pEx, int parishID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteParishClergy";
            cmd.Parameters.AddWithValue("@parishID", parishID);
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

    public bool Enable_Item(ref Exception pEx, int parishID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EnableParishClergy";
            cmd.Parameters.AddWithValue("@parishID", parishID);
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

    public bool Disable_Item(ref Exception pEx, int parishID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DisableParishClergy";
            cmd.Parameters.AddWithValue("@parishID", parishID);
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

public class clsParishClergy_Item
{
    private int _clergyID;
    private int _parishID;
    private DateTime _joinedDate;
    private DateTime _leftDate;


    public clsParishClergy_Item()
    {
        //Default constructor
    }

    public clsParishClergy_Item(int clergyID, int parishID, DateTime joinedDate, DateTime leftDate)
    {
        _clergyID = clergyID;
        _parishID = parishID;
        _joinedDate = joinedDate;
        _leftDate = leftDate;
    }

    [XmlElement(typeof(int))]
    public int clergyID
    {
        get
        {
            return _clergyID;
        }

        set
        {
            if (!(_clergyID == value))
            {
                _clergyID = value;

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

    [XmlElement(typeof(DateTime))]
    public DateTime joinedDate
    {
        get
        {
            return _joinedDate;
        }

        set
        {
            if (!(_joinedDate == value))
            {
                _joinedDate = value;

            }
        }
    }

    [XmlElement(typeof(DateTime))]
    public DateTime leftDate
    {
        get
        {
            return _leftDate;
        }

        set
        {
            if (!(_leftDate == value))
            {
                _leftDate = value;

            }
        }
    }


}


