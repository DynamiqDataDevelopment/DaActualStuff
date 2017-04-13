
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsTelephoneNumberTypes_List : List<clsTelephoneNumberTypes_Item>
{
    private string _connectionString = string.Empty;
	private Guid _userCde = Guid.Empty;
	
    public clsTelephoneNumberTypes_List(string connectionString, ref Exception pEx, int ID, string description)
	{
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "usp_GetTelephoneNumberTypes";
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
				clsTelephoneNumberTypes_Item tmp = new clsTelephoneNumberTypes_Item();
						if(! (data_reader["ID"] == DBNull.Value))  tmp.ID = (int)data_reader["ID"];
				if(! (data_reader["description"] == DBNull.Value))  tmp.description = (string)data_reader["description"];
				if(! (data_reader["isDeleted"] == DBNull.Value))  tmp.isDeleted = (bool)data_reader["isDeleted"];
				this.Add(tmp);
			}
		}
    }

	public bool Add_Item(ref Exception pEx, int ID, string description)
	{
        SqlConnection conn = new SqlConnection((_connectionString));
		try
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "usp_InsertTelephoneNumberTypes";
			cmd.Parameters.AddWithValue("@ID", ID);
				cmd.Parameters.AddWithValue("@description", description);
			if (Save(ref pEx, cmd))
			{
				this.Add(new clsTelephoneNumberTypes_Item(ID, description));
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

	public bool Update_Item(ref Exception pEx, int ID, string description)
	{
		SqlConnection conn = new SqlConnection((_connectionString));
		try
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "usp_UpdateTelephoneNumberTypes";
			 cmd.Parameters.AddWithValue("@ID", ID);
				 cmd.Parameters.AddWithValue("@description", description);
			if (Save(ref pEx, cmd))
			{
				foreach (clsTelephoneNumberTypes_Item Item in this)
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
			cmd.CommandText = "usp_DeleteTelephoneNumberTypes";
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

public class clsTelephoneNumberTypes_Item
{
		private int _ID;
		private string _description;
		private bool _isDeleted;
	
	
	public clsTelephoneNumberTypes_Item()
	{
		//Default constructor
	}
	
    public clsTelephoneNumberTypes_Item(int ID, string description)
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


