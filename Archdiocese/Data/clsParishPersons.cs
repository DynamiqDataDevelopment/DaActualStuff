
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsParishPersons_List : List<clsParishPersons_Item>
{
    private string _connectionString = string.Empty;

    public clsParishPersons_List(string connectionString)
    {
        _connectionString = connectionString;
    }
    public clsParishPersons_List(string connectionString, ref Exception pEx, int parishID)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetParishPersons";
            //if (!(addressLine1 == string.Empty)) cmd.Parameters.AddWithValue("@addressLine1", addressLine1);
            //cmd.Parameters.AddWithValue("@personID", personID);
            cmd.Parameters.AddWithValue("@parishID", parishID);
            //cmd.Parameters.AddWithValue("@joinedDate", joinedDate);
            //cmd.Parameters.AddWithValue("@leftDate", leftDate);
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
                clsParishPersons_Item tmp = new clsParishPersons_Item();
                if (!(data_reader["personID"] == DBNull.Value)) tmp.personID = (int)data_reader["personID"];
                if (!(data_reader["parishID"] == DBNull.Value)) tmp.parishID = (int)data_reader["parishID"];
                if (!(data_reader["joinedDate"] == DBNull.Value)) tmp.joinedDate = (DateTime)data_reader["joinedDate"];
                if (!(data_reader["leftDate"] == DBNull.Value)) tmp.leftDate = (DateTime)data_reader["leftDate"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsParishPersons_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertParishPersons";
            cmd.Parameters.AddWithValue("@personID", obj.personID);
            cmd.Parameters.AddWithValue("@parishID", obj.parishID);
            cmd.Parameters.AddWithValue("@joinedDate", obj.joinedDate);
            //cmd.Parameters.AddWithValue("@leftDate", obj.leftDate);
            if (Save(ref pEx, cmd))
            {
                //this.Add(new clsParishPersons_Item(personID, parishID, joinedDate, leftDate));
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

    public bool Update_Item(ref Exception pEx, clsParishPersons_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateParishPersons";
            cmd.Parameters.AddWithValue("@personID", obj.personID);
            cmd.Parameters.AddWithValue("@parishID", obj.parishID);
            cmd.Parameters.AddWithValue("@joinedDate", obj.joinedDate);
            //cmd.Parameters.AddWithValue("@leftDate", obj.leftDate);
            if (Save(ref pEx, cmd))
            {
                foreach (clsParishPersons_Item Item in this)
                {
                    //if (Item.parishID == parishID)
                    //{
                    //    Item.personID = personID;
                    //    Item.parishID = parishID;
                    //    Item.joinedDate = joinedDate;
                    //    Item.leftDate = leftDate;
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

    public bool Delete_Item(ref Exception pEx, int parishID, int personID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteParishPersons";
            cmd.Parameters.AddWithValue("@parishID", parishID);
            cmd.Parameters.AddWithValue("@personID", parishID);
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
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_EnableParishPersons";
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
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DisableParishPersons";
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

public class clsParishPersons_Item
{
    private int _personID;
    private int _parishID;
    private DateTime _joinedDate;
    private DateTime _leftDate;


    public clsParishPersons_Item()
    {
        //Default constructor
    }

    public clsParishPersons_Item(int personID, int parishID, DateTime joinedDate, DateTime leftDate)
    {
        _personID = personID;
        _parishID = parishID;
        _joinedDate = joinedDate;
        _leftDate = leftDate;
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


