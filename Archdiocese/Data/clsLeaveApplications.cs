
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsLeaveApplications_List : List<clsLeaveApplications_Item>
{
    private string _connectionString = string.Empty;
	private Guid _userCde = Guid.Empty;
	
    public clsLeaveApplications_List(string connectionString, ref Exception pEx, int ID, int parishUserID, int leaveTypeID, DateTime dateFrom, DateTime dateTo, DateTime dateSubmitted)
	{
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "usp_GetLeaveApplications";
			 cmd.Parameters.AddWithValue("@ID", ID);
				 cmd.Parameters.AddWithValue("@parishUserID", parishUserID);
				 cmd.Parameters.AddWithValue("@leaveTypeID", leaveTypeID);
				 cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
				 cmd.Parameters.AddWithValue("@dateTo", dateTo);
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
				clsLeaveApplications_Item tmp = new clsLeaveApplications_Item();
						if(! (data_reader["ID"] == DBNull.Value))  tmp.ID = (int)data_reader["ID"];
				if(! (data_reader["parishUserID"] == DBNull.Value))  tmp.parishUserID = (int)data_reader["parishUserID"];
				if(! (data_reader["leaveTypeID"] == DBNull.Value))  tmp.leaveTypeID = (int)data_reader["leaveTypeID"];
				if(! (data_reader["dateFrom"] == DBNull.Value))  tmp.dateFrom = (DateTime)data_reader["dateFrom"];
				if(! (data_reader["dateTo"] == DBNull.Value))  tmp.dateTo = (DateTime)data_reader["dateTo"];
				if(! (data_reader["dateSubmitted"] == DBNull.Value))  tmp.dateSubmitted = (DateTime)data_reader["dateSubmitted"];
				if(! (data_reader["isDeleted"] == DBNull.Value))  tmp.isDeleted = (bool)data_reader["isDeleted"];
				this.Add(tmp);
			}
		}
    }

	public bool Add_Item(ref Exception pEx, clsLeaveApplications_Item obj)
	{
        SqlConnection conn = new SqlConnection((_connectionString));
		try
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "usp_InsertLeaveApplications";
			cmd.Parameters.AddWithValue("@ID", obj.ID);
				cmd.Parameters.AddWithValue("@parishUserID", obj.parishUserID);
				cmd.Parameters.AddWithValue("@leaveTypeID", obj.leaveTypeID);
				cmd.Parameters.AddWithValue("@dateFrom", obj.dateFrom);
				cmd.Parameters.AddWithValue("@dateTo", obj.dateTo);
				cmd.Parameters.AddWithValue("@dateSubmitted", obj.dateSubmitted);
			if (Save(ref pEx, cmd))
			{
				this.Add(new clsLeaveApplications_Item(ID, parishUserID, leaveTypeID, dateFrom, dateTo, dateSubmitted));
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

	public bool Update_Item(ref Exception pEx, clsLeaveApplications_Item obj)
	{
		SqlConnection conn = new SqlConnection((_connectionString));
		try
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "usp_UpdateLeaveApplications";
			 cmd.Parameters.AddWithValue("@ID", obj.ID);
				 cmd.Parameters.AddWithValue("@parishUserID", obj.parishUserID);
				 cmd.Parameters.AddWithValue("@leaveTypeID", obj.leaveTypeID);
				 cmd.Parameters.AddWithValue("@dateFrom", obj.dateFrom);
				 cmd.Parameters.AddWithValue("@dateTo", obj.dateTo);
				 cmd.Parameters.AddWithValue("@dateSubmitted", obj.dateSubmitted);
			if (Save(ref pEx, cmd))
			{
				foreach (clsLeaveApplications_Item Item in this)
				{
					if (Item.ID == ID)
					{
						Item.ID = ID;
							Item.parishUserID = parishUserID;
							Item.leaveTypeID = leaveTypeID;
							Item.dateFrom = dateFrom;
							Item.dateTo = dateTo;
							Item.dateSubmitted = dateSubmitted;
					}
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
			cmd.CommandText = "usp_DeleteLeaveApplications";
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
			cmd.CommandText = "usp_EnableLeaveApplications";
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
			cmd.CommandText = "usp_DisableLeaveApplications";
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

public class clsLeaveApplications_Item
{
		private int _ID;
		private int _parishUserID;
		private int _leaveTypeID;
		private DateTime _dateFrom;
		private DateTime _dateTo;
		private DateTime _dateSubmitted;
		private bool _isDeleted;
	
	
	public clsLeaveApplications_Item()
	{
		//Default constructor
	}
	
    public clsLeaveApplications_Item(int ID, int parishUserID, int leaveTypeID, DateTime dateFrom, DateTime dateTo, DateTime dateSubmitted)
	{
		_ID = ID;
		_parishUserID = parishUserID;
		_leaveTypeID = leaveTypeID;
		_dateFrom = dateFrom;
		_dateTo = dateTo;
		_dateSubmitted = dateSubmitted;
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
			if(! (_ID == value ))			{				_ID = value;
				
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
			if(! (_parishUserID == value ))			{				_parishUserID = value;
				
			}
		}
	}

	[XmlElement(typeof(int))]
public int leaveTypeID
	{
		get
		{
			return _leaveTypeID;
		}
		set
		{
			if(! (_leaveTypeID == value ))			{				_leaveTypeID = value;
				
			}
		}
	}

	[XmlElement(typeof(DateTime))]
public DateTime dateFrom
	{
		get
		{
			return _dateFrom;
		}
		set
		{
			if(! (_dateFrom == value ))			{				_dateFrom = value;
				
			}
		}
	}

	[XmlElement(typeof(DateTime))]
public DateTime dateTo
	{
		get
		{
			return _dateTo;
		}
		set
		{
			if(! (_dateTo == value ))			{				_dateTo = value;
				
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
			if(! (_dateSubmitted == value ))			{				_dateSubmitted = value;
				
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
			if(! (_isDeleted == value ))			{				_isDeleted = value;
				
			}
		}
	}

	
}


