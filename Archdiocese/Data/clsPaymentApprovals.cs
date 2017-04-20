using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsPaymentApprovals_List : List<clsPaymentApprovals_Item>
{
    private string _connectionString = string.Empty;

    public clsPaymentApprovals_List(string connectionString)
    {
        _connectionString = connectionString;
    }

    public clsPaymentApprovals_List(string connectionString, ref Exception pEx, int ID, int paymentRequestID, int approverParishUserID, bool approvalStatus, string reason, DateTime approvalDateTime)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetPaymentApprovals";
            if (!(ID == 0)) cmd.Parameters.AddWithValue("@ID", ID);
            if (!(paymentRequestID == 0)) cmd.Parameters.AddWithValue("@paymentRequestID", paymentRequestID);
            if (!(approverParishUserID == 0)) cmd.Parameters.AddWithValue("@approverParishUserID", approverParishUserID);
            //if (!(reason == string.Empty)) cmd.Parameters.AddWithValue("@approvalStatus", approvalStatus);
            if (!(reason == string.Empty)) cmd.Parameters.AddWithValue("@reason", reason);
            cmd.Parameters.AddWithValue("@approvalDateTime", approvalDateTime);
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
                clsPaymentApprovals_Item tmp = new clsPaymentApprovals_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["paymentRequestID"] == DBNull.Value)) tmp.paymentRequestID = (int)data_reader["paymentRequestID"];
                if (!(data_reader["approverParishUserID"] == DBNull.Value)) tmp.approverParishUserID = (int)data_reader["approverParishUserID"];
                if (!(data_reader["approvalStatus"] == DBNull.Value)) tmp.approvalStatus = (bool)data_reader["approvalStatus"];
                if (!(data_reader["reason"] == DBNull.Value)) tmp.reason = (string)data_reader["reason"];
                if (!(data_reader["approvalDateTime"] == DBNull.Value)) tmp.approvalDateTime = (DateTime)data_reader["approvalDateTime"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsPaymentApprovals_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertPaymentApprovals";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@paymentRequestID", obj.paymentRequestID);
            cmd.Parameters.AddWithValue("@approverParishUserID", obj.approverParishUserID);
            cmd.Parameters.AddWithValue("@approvalStatus", obj.approvalStatus);
            cmd.Parameters.AddWithValue("@reason", obj.reason);
            //cmd.Parameters.AddWithValue("@approvalDateTime", obj.approvalDateTime);
            if (Save(ref pEx, cmd))
            {
                //this.Add(new clsPaymentApprovals_Item(ID, paymentRequestID, approverParishUserID, approvalStatus, reason, approvalDateTime));
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

    public bool Update_Item(ref Exception pEx, clsPaymentApprovals_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdatePaymentApprovals";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@paymentRequestID", obj.paymentRequestID);
            cmd.Parameters.AddWithValue("@approverParishUserID", obj.approverParishUserID);
            cmd.Parameters.AddWithValue("@approvalStatus", obj.approvalStatus);
            cmd.Parameters.AddWithValue("@reason", obj.reason);
            cmd.Parameters.AddWithValue("@approvalDateTime", obj.approvalDateTime);
            if (Save(ref pEx, cmd))
            {
                //foreach (clsPaymentApprovals_Item Item in this)
                //{
                //    if (Item.ID == ID)
                //    {
                //        Item.ID = ID;
                //        Item.paymentRequestID = paymentRequestID;
                //        Item.approverParishUserID = approverParishUserID;
                //        Item.approvalStatus = approvalStatus;
                //        Item.reason = reason;
                //        Item.approvalDateTime = approvalDateTime;
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

    public bool Delete_Item(ref Exception pEx, Guid ID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeletePaymentApprovals";
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
            cmd.CommandText = "usp_EnablePaymentApprovals";
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
            cmd.CommandText = "usp_DisablePaymentApprovals";
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

public class clsPaymentApprovals_Item
{
    private int _ID;
    private int _paymentRequestID;
    private int _approverParishUserID;
    private bool _approvalStatus;
    private string _reason;
    private DateTime _approvalDateTime;


    public clsPaymentApprovals_Item()
    {
        //Default constructor
    }

    public clsPaymentApprovals_Item(int ID, int paymentRequestID, int approverParishUserID, bool approvalStatus, string reason, DateTime approvalDateTime)
    {
        _ID = ID;
        _paymentRequestID = paymentRequestID;
        _approverParishUserID = approverParishUserID;
        _approvalStatus = approvalStatus;
        _reason = reason;
        _approvalDateTime = approvalDateTime;
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
    public int paymentRequestID
    {
        get
        {
            return _paymentRequestID;
        }

        set
        {
            if (!(_paymentRequestID == value))
            {
                _paymentRequestID = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int approverParishUserID
    {
        get
        {
            return _approverParishUserID;
        }

        set
        {
            if (!(_approverParishUserID == value))
            {
                _approverParishUserID = value;

            }
        }
    }

    [XmlElement(typeof(bool))]
    public bool approvalStatus
    {
        get
        {
            return _approvalStatus;
        }

        set
        {
            if (!(_approvalStatus == value))
            {
                _approvalStatus = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string reason
    {
        get
        {
            return _reason;
        }

        set
        {
            if (!(_reason == value))
            {
                _reason = value;

            }
        }
    }

    [XmlElement(typeof(DateTime))]
    public DateTime approvalDateTime
    {
        get
        {
            return _approvalDateTime;
        }

        set
        {
            if (!(_approvalDateTime == value))
            {
                _approvalDateTime = value;

            }
        }
    }
}


