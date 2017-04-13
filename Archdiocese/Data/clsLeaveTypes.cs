
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsLeaveTypes_List : List<clsLeaveTypes_Item>
{
    private string _connectionString = string.Empty;
	private Guid _userCde = Guid.Empty;
	
    public clsLeaveTypes_List(string connectionString, ref Exception pEx, int ID, string description)
	{
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "usp_GetLeaveTypes";
			 cmd.Parameters.AddWithValue("@ID", ID);
				if(!( description == string.Empty)) cmd.Parameters.AddWithValue("@description", description);			
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
				clsLeaveTypes_Item tmp = new clsLeaveTypes_Item();
						if(! (data_reader["ID"] == DBNull.Value))  tmp.ID = (int)data_reader["ID"];
				if(! (data_reader["description"] == DBNull.Value))  tmp.description = (string)data_reader["description"];
				if(! (data_reader["isDeleted"] == DBNull.Value))  tmp.isDeleted = (bool)data_reader["isDeleted"];
				this.Add(tmp);
			}
		}
    }

	public bool Add_Item(ref Exception pEx, clsLeaveTypes_Item obj)
	{
        SqlConnection conn = new SqlConnection((_connectionString));
		try
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "usp_InsertLeaveTypes";
			cmd.Parameters.AddWithValue("@ID", obj.ID);
				cmd.Parameters.AddWithValue("@description", obj.description);
			if (Save(ref pEx, cmd))
			{
				this.Add(new clsLeaveTypes_Item(ID, description));
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

	public bool Update_Item(ref Exception pEx, clsLeaveTypes_Item obj)
	{
		SqlConnection conn = new SqlConnection((_connectionString));
		try
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "usp_UpdateLeaveTypes";
			 cmd.Parameters.AddWithValue("@ID", obj.ID);
				 cmd.Parameters.AddWithValue("@description", obj.description);
			if (Save(ref pEx, cmd))
			{
				foreach (clsLeaveTypes_Item Item in this)
				{
					if (Item.ID == ID)
					{
						Item.ID = ID;
							Item.description = description;
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
			cmd.CommandText = "usp_DeleteLeaveTypes";
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
			cmd.CommandText = "usp_EnableLeaveTypes";
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
			cmd.CommandText = "usp_DisableLeaveTypes";
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

public class clsLeaveTypes_Item
{
		private int _ID;
		private string _description;
		private bool _isDeleted;
	
	
	public clsLeaveTypes_Item()
	{
		//Default constructor
	}
	
    public clsLeaveTypes_Item(int ID, string description)
	{
		_ID = ID;
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
			if(! (_ID == value ))			{				_ID = value;
				
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
			if(! (_description == value ))			{				_description = value;
				
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


