
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsLeaveApprovals_List : List<clsLeaveApprovals_Item>
{
    private string _connectionString = string.Empty;
	private Guid _userCde = Guid.Empty;
	
    public clsLeaveApprovals_List(string connectionString, ref Exception pEx, int ID, int leaveApplicationID, DateTime dateApproved)
	{
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "usp_GetLeaveApprovals";
			 cmd.Parameters.AddWithValue("@ID", ID);
				 cmd.Parameters.AddWithValue("@leaveApplicationID", leaveApplicationID);
				 cmd.Parameters.AddWithValue("@dateApproved", dateApproved);			
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
				clsLeaveApprovals_Item tmp = new clsLeaveApprovals_Item();
						if(! (data_reader["ID"] == DBNull.Value))  tmp.ID = (int)data_reader["ID"];
				if(! (data_reader["leaveApplicationID"] == DBNull.Value))  tmp.leaveApplicationID = (int)data_reader["leaveApplicationID"];
				if(! (data_reader["dateApproved"] == DBNull.Value))  tmp.dateApproved = (DateTime)data_reader["dateApproved"];
				this.Add(tmp);
			}
		}
    }

	public bool Add_Item(ref Exception pEx, clsLeaveApprovals_Item obj)
	{
        SqlConnection conn = new SqlConnection((_connectionString));
		try
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "usp_InsertLeaveApprovals";
			cmd.Parameters.AddWithValue("@ID", obj.ID);
				cmd.Parameters.AddWithValue("@leaveApplicationID", obj.leaveApplicationID);
				cmd.Parameters.AddWithValue("@dateApproved", obj.dateApproved);
			if (Save(ref pEx, cmd))
			{
				this.Add(new clsLeaveApprovals_Item(ID, leaveApplicationID, dateApproved));
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

	public bool Update_Item(ref Exception pEx, clsLeaveApprovals_Item obj)
	{
		SqlConnection conn = new SqlConnection((_connectionString));
		try
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "usp_UpdateLeaveApprovals";
			 cmd.Parameters.AddWithValue("@ID", obj.ID);
				 cmd.Parameters.AddWithValue("@leaveApplicationID", obj.leaveApplicationID);
				 cmd.Parameters.AddWithValue("@dateApproved", obj.dateApproved);
			if (Save(ref pEx, cmd))
			{
				foreach (clsLeaveApprovals_Item Item in this)
				{
					if (Item.ID == ID)
					{
						Item.ID = ID;
							Item.leaveApplicationID = leaveApplicationID;
							Item.dateApproved = dateApproved;
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
			cmd.CommandText = "usp_DeleteLeaveApprovals";
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
			cmd.CommandText = "usp_EnableLeaveApprovals";
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
			cmd.CommandText = "usp_DisableLeaveApprovals";
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

public class clsLeaveApprovals_Item
{
		private int _ID;
		private int _leaveApplicationID;
		private DateTime _dateApproved;
	
	
	public clsLeaveApprovals_Item()
	{
		//Default constructor
	}
	
    public clsLeaveApprovals_Item(int ID, int leaveApplicationID, DateTime dateApproved)
	{
		_ID = ID;
		_leaveApplicationID = leaveApplicationID;
		_dateApproved = dateApproved;
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
public int leaveApplicationID
	{
		get
		{
			return _leaveApplicationID;
		}
		set
		{
			if(! (_leaveApplicationID == value ))			{				_leaveApplicationID = value;
				
			}
		}
	}

	[XmlElement(typeof(DateTime))]
public DateTime dateApproved
	{
		get
		{
			return _dateApproved;
		}
		set
		{
			if(! (_dateApproved == value ))			{				_dateApproved = value;
				
			}
		}
	}

	
}


