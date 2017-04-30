
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsPaymentRequestsNew_List : List<clsPaymentRequestsNew_Item>
{
    private string _connectionString = string.Empty;

    public clsPaymentRequestsNew_List(string connectionString)
    {
        _connectionString = connectionString;
    }

    public clsPaymentRequestsNew_List(string connectionString, ref Exception pEx, int ID, string fromAccountNumber, string recipientName, string toAccountNumber, int branchCodeID, int parishUserID, int requesterPersonID, DateTime requestDateTime, DateTime actionDate)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetPaymentRequests_WithoutApprovals";
            if (!(ID == 0)) cmd.Parameters.AddWithValue("@ID", ID);
            if (!(fromAccountNumber == string.Empty)) cmd.Parameters.AddWithValue("@fromAccountNumber", fromAccountNumber);
            if (!(recipientName == string.Empty)) cmd.Parameters.AddWithValue("@recipientName", recipientName);
            if (!(toAccountNumber == string.Empty)) cmd.Parameters.AddWithValue("@toAccountNumber", toAccountNumber);
            if (!(branchCodeID == 0)) cmd.Parameters.AddWithValue("@branchCodeID", branchCodeID);
            if (!(parishUserID == 0)) cmd.Parameters.AddWithValue("@parishUserID", parishUserID);
            if (!(requesterPersonID == 0)) cmd.Parameters.AddWithValue("@requesterPersonID", requesterPersonID);
            if (!(requestDateTime == DateTime.MinValue)) cmd.Parameters.AddWithValue("@requestDateTime", requestDateTime);
            if (!(actionDate == DateTime.MinValue)) cmd.Parameters.AddWithValue("@actionDate", actionDate);
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
                clsPaymentRequestsNew_Item tmp = new clsPaymentRequestsNew_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["fromAccountNumber"] == DBNull.Value)) tmp.fromAccountNumber = (string)data_reader["fromAccountNumber"];
                if (!(data_reader["recipientName"] == DBNull.Value)) tmp.recipientName = (string)data_reader["recipientName"];
                if (!(data_reader["toAccountNumber"] == DBNull.Value)) tmp.toAccountNumber = (string)data_reader["toAccountNumber"];
                if (!(data_reader["branchCodeID"] == DBNull.Value)) tmp.branchCodeID = (int)data_reader["branchCodeID"];
                if (!(data_reader["bankBranchCode"] == DBNull.Value)) tmp.bankBranchCode = (string)data_reader["bankBranchCode"];
                if (!(data_reader["parishUserID"] == DBNull.Value)) tmp.parishUserID = (int)data_reader["parishUserID"];
                if (!(data_reader["captureUsername"] == DBNull.Value)) tmp.captureUsername = (string)data_reader["captureUsername"];
                if (!(data_reader["parishName"] == DBNull.Value)) tmp.parishName = (string)data_reader["parishName"];
                if (!(data_reader["requesterPersonID"] == DBNull.Value)) tmp.requesterPersonID = (int)data_reader["requesterPersonID"];
                if (!(data_reader["requester"] == DBNull.Value)) tmp.requester = (string)data_reader["requester"];

                if (!(data_reader["requestDateTime"] == DBNull.Value)) tmp.requestDateTime = (DateTime)data_reader["requestDateTime"];
                if (!(data_reader["actionDate"] == DBNull.Value)) tmp.actionDate = (DateTime)data_reader["actionDate"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsPaymentRequestsNew_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertPaymentRequests";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@fromAccountNumber", obj.fromAccountNumber);
            cmd.Parameters.AddWithValue("@recipientName", obj.recipientName);
            cmd.Parameters.AddWithValue("@toAccountNumber", obj.toAccountNumber);
            cmd.Parameters.AddWithValue("@branchCodeID", obj.branchCodeID);
            cmd.Parameters.AddWithValue("@parishUserID", obj.parishUserID);
            cmd.Parameters.AddWithValue("@requesterPersonID", obj.requesterPersonID);
            cmd.Parameters.AddWithValue("@requestDateTime", obj.requestDateTime);
            cmd.Parameters.AddWithValue("@actionDate", obj.actionDate);
            if (Save(ref pEx, cmd))
            {
                //this.Add(new clsPaymentRequestsNew_Item(ID, fromAccountNumber, recipientName, toAccountNumber, branchCodeID, parishUserID, requesterPersonID, requestDateTime, actionDate));
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

    public bool Update_Item(ref Exception pEx, clsPaymentRequestsNew_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdatePaymentRequests";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@fromAccountNumber", obj.fromAccountNumber);
            cmd.Parameters.AddWithValue("@recipientName", obj.recipientName);
            cmd.Parameters.AddWithValue("@toAccountNumber", obj.toAccountNumber);
            cmd.Parameters.AddWithValue("@branchCodeID", obj.branchCodeID);
            cmd.Parameters.AddWithValue("@parishUserID", obj.parishUserID);
            cmd.Parameters.AddWithValue("@requesterPersonID", obj.requesterPersonID);
            cmd.Parameters.AddWithValue("@requestDateTime", obj.requestDateTime);
            cmd.Parameters.AddWithValue("@actionDate", obj.actionDate);
            if (Save(ref pEx, cmd))
            {
                //foreach (clsPaymentRequestsNew_Item Item in this)
                //{
                //    if (Item.ID == ID)
                //    {
                //        Item.ID = ID;
                //        Item.fromAccountNumber = fromAccountNumber;
                //        Item.recipientName = recipientName;
                //        Item.toAccountNumber = toAccountNumber;
                //        Item.branchCodeID = branchCodeID;
                //        Item.parishUserID = parishUserID;
                //        Item.requesterPersonID = requesterPersonID;
                //        Item.requestDateTime = requestDateTime;
                //        Item.actionDate = actionDate;
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
        int index = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeletePaymentRequests";
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
            cmd.CommandText = "usp_EnablePaymentRequests";
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
            cmd.CommandText = "usp_DisablePaymentRequests";
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

public class clsPaymentRequestsNew_Item
{
    private int _ID;
    private string _fromAccountNumber;
    private string _recipientName;
    private string _toAccountNumber;
    private int _branchCodeID;
    private string _bankBranchCode;
    private int _parishUserID;
    private string _captureUsername;
    private string _parishName;
    private int _requesterPersonID;
    private string _requester;
    private DateTime _requestDateTime;
    private DateTime _actionDate;
    private bool _isDeleted;


    public clsPaymentRequestsNew_Item()
    {
        //Default constructor
    }

    public clsPaymentRequestsNew_Item(int ID, string fromAccountNumber, string recipientName, string toAccountNumber, int branchCodeID, int parishUserID, int requesterPersonID, DateTime requestDateTime, DateTime actionDate)
    {
        _ID = ID;
        _fromAccountNumber = fromAccountNumber;
        _recipientName = recipientName;
        _toAccountNumber = toAccountNumber;
        _branchCodeID = branchCodeID;
        _parishUserID = parishUserID;
        _requesterPersonID = requesterPersonID;
        _requestDateTime = requestDateTime;
        _actionDate = actionDate;
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
    public string fromAccountNumber
    {
        get
        {
            return _fromAccountNumber;
        }

        set
        {
            if (!(_fromAccountNumber == value))
            {
                _fromAccountNumber = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string recipientName
    {
        get
        {
            return _recipientName;
        }

        set
        {
            if (!(_recipientName == value))
            {
                _recipientName = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string toAccountNumber
    {
        get
        {
            return _toAccountNumber;
        }

        set
        {
            if (!(_toAccountNumber == value))
            {
                _toAccountNumber = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int branchCodeID
    {
        get
        {
            return _branchCodeID;
        }

        set
        {
            if (!(_branchCodeID == value))
            {
                _branchCodeID = value;

            }
        }
    }
    [XmlElement(typeof(string))]
    public string bankBranchCode
    {
        get
        {
            return _bankBranchCode;
        }

        set
        {
            if (!(_bankBranchCode == value))
            {
                _bankBranchCode = value;

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

    [XmlElement(typeof(string))]
    public string captureUsername
    {
        get
        {
            return _captureUsername;
        }

        set
        {
            if (!(_captureUsername == value))
            {
                _captureUsername = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string parishName
    {
        get
        {
            return _parishName;
        }

        set
        {
            if (!(_parishName == value))
            {
                _parishName = value;

            }
        }
    }
    [XmlElement(typeof(int))]
    public int requesterPersonID
    {
        get
        {
            return _requesterPersonID;
        }

        set
        {
            if (!(_requesterPersonID == value))
            {
                _requesterPersonID = value;

            }
        }
    }
    [XmlElement(typeof(string))]
    public string requester
    {
        get
        {
            return _requester;
        }

        set
        {
            if (!(_requester == value))
            {
                _requester = value;

            }
        }
    }
    [XmlElement(typeof(DateTime))]
    public DateTime requestDateTime
    {
        get
        {
            return _requestDateTime;
        }

        set
        {
            if (!(_requestDateTime == value))
            {
                _requestDateTime = value;

            }
        }
    }

    [XmlElement(typeof(DateTime))]
    public DateTime actionDate
    {
        get
        {
            return _actionDate;
        }

        set
        {
            if (!(_actionDate == value))
            {
                _actionDate = value;

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


