
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsPersons_List : List<clsPersons_Item>
{
    private string _connectionString = string.Empty;

    public clsPersons_List(string connectionString)
    {
        _connectionString = connectionString;
    }
    public clsPersons_List(string connectionString, ref Exception pEx, int ID, int titleID, int personTypeID, string firstName, string middleName, string surname, DateTime dateOfBirth, int genderID, DateTime dateBaptised, DateTime dateConfirmed, int maritalStatusID, int parishID)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetPersons_Full";
            
            if (!(ID == 0)) cmd.Parameters.AddWithValue("@ID", ID);
            if (!(titleID == 0)) cmd.Parameters.AddWithValue("@titleID", titleID);
            if (!(personTypeID == 0)) cmd.Parameters.AddWithValue("@personTypeID", personTypeID);
            if (!(firstName == string.Empty)) cmd.Parameters.AddWithValue("@firstName", firstName);
            if (!(middleName == string.Empty)) cmd.Parameters.AddWithValue("@middleName", middleName);
            if (!(surname == string.Empty)) cmd.Parameters.AddWithValue("@surname", surname);
            if (!(dateOfBirth == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            if (!(genderID == 0)) cmd.Parameters.AddWithValue("@genderID", genderID);
            if (!(maritalStatusID == 0)) cmd.Parameters.AddWithValue("@maritalStatusID", maritalStatusID);
            if (!(dateBaptised == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateBaptised", dateBaptised);
            if (!(dateConfirmed == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateConfirmed", dateConfirmed);
            if (!(parishID == 0)) cmd.Parameters.AddWithValue("@parishID", parishID);
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
                clsPersons_Item tmp = new clsPersons_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["titleID"] == DBNull.Value)) tmp.titleID = (int)data_reader["titleID"];
                if (!(data_reader["personTypeID"] == DBNull.Value)) tmp.personTypeID = (int)data_reader["personTypeID"];
                if (!(data_reader["firstName"] == DBNull.Value)) tmp.firstName = (string)data_reader["firstName"];
                if (!(data_reader["middleName"] == DBNull.Value)) tmp.middleName = (string)data_reader["middleName"];
                if (!(data_reader["surname"] == DBNull.Value)) tmp.surname = (string)data_reader["surname"];
                if (!(data_reader["dateOfBirth"] == DBNull.Value)) tmp.dateOfBirth = (DateTime)data_reader["dateOfBirth"];
                if (!(data_reader["genderID"] == DBNull.Value)) tmp.genderID = (int)data_reader["genderID"];
                if (!(data_reader["dateBaptised"] == DBNull.Value)) tmp.dateBaptised = (DateTime)data_reader["dateBaptised"];
                if (!(data_reader["dateConfirmed"] == DBNull.Value)) tmp.dateConfirmed = (DateTime)data_reader["dateConfirmed"];
                if (!(data_reader["maritalStatusID"] == DBNull.Value)) tmp.maritalStatusID = (int)data_reader["maritalStatusID"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsPersons_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertPersons";
            //cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@titleID", obj.titleID);
            cmd.Parameters.AddWithValue("@personTypeID", obj.personTypeID);
            cmd.Parameters.AddWithValue("@firstName", obj.firstName);
            //cmd.Parameters.AddWithValue("@middleName", obj.middleName);
            if (!(obj.middleName == string.Empty)) cmd.Parameters.AddWithValue("@middleName", obj.middleName);
            cmd.Parameters.AddWithValue("@surname", obj.surname);
            cmd.Parameters.AddWithValue("@dateOfBirth", obj.dateOfBirth);
            cmd.Parameters.AddWithValue("@genderID", obj.genderID);
            //cmd.Parameters.AddWithValue("@dateBaptised", obj.dateBaptised);
            if (!(obj.dateBaptised == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateBaptised", obj.dateBaptised);
            //cmd.Parameters.AddWithValue("@dateConfirmed", obj.dateConfirmed);
            if (!(obj.dateConfirmed == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateConfirmed", obj.dateConfirmed);
            cmd.Parameters.AddWithValue("@maritalStatusID", obj.maritalStatusID);
            if (Save(ref pEx, cmd))
            {
                this.Add(new clsPersons_Item(obj.ID, obj.titleID, obj.personTypeID, obj.firstName, obj.middleName, obj.surname, obj.dateOfBirth, obj.genderID, obj.dateBaptised, obj.dateConfirmed, obj.maritalStatusID));
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

    public int Add_Item_ReturnID(ref Exception pEx, clsPersons_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int ID = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertPersons";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@titleID", obj.titleID);
            cmd.Parameters.AddWithValue("@personTypeID", obj.personTypeID);
            cmd.Parameters.AddWithValue("@firstName", obj.firstName);
            if (!(obj.middleName == string.Empty)) cmd.Parameters.AddWithValue("@middleName", obj.middleName);
            cmd.Parameters.AddWithValue("@surname", obj.surname);
            cmd.Parameters.AddWithValue("@dateOfBirth", obj.dateOfBirth);
            cmd.Parameters.AddWithValue("@genderID", obj.genderID);
            if (!(obj.dateBaptised == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateBaptised", obj.dateBaptised);
            if (!(obj.dateConfirmed == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateConfirmed", obj.dateConfirmed);
            cmd.Parameters.AddWithValue("@maritalStatusID", obj.maritalStatusID);
            ID = Save_Read(ref pEx, cmd);
            if (ID != 0)
            {
                conn.Close();
                return ID;
            }
            else
            {
                conn.Close();
                return ID;
            }
        }
        catch (Exception ex)
        {
            pEx = ex;
            conn.Close();
            return ID;
        }
    }
    public bool Update_Item(ref Exception pEx, clsPersons_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdatePersons";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@titleID", obj.titleID);
            cmd.Parameters.AddWithValue("@personTypeID", obj.personTypeID);
            cmd.Parameters.AddWithValue("@firstName", obj.firstName);
            //cmd.Parameters.AddWithValue("@middleName", obj.middleName);
            if (!(obj.middleName == string.Empty)) cmd.Parameters.AddWithValue("@middleName", obj.middleName);
            cmd.Parameters.AddWithValue("@surname", obj.surname);
            cmd.Parameters.AddWithValue("@dateOfBirth", obj.dateOfBirth);
            cmd.Parameters.AddWithValue("@genderID", obj.genderID);
            //cmd.Parameters.AddWithValue("@dateBaptised", obj.dateBaptised);
            if (!(obj.dateBaptised == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateBaptised", obj.dateBaptised);
            //cmd.Parameters.AddWithValue("@dateConfirmed", obj.dateConfirmed);
            if (!(obj.dateConfirmed == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateConfirmed", obj.dateConfirmed);
            cmd.Parameters.AddWithValue("@maritalStatusID", obj.maritalStatusID);
            if (Save(ref pEx, cmd))
            {
                foreach (clsPersons_Item Item in this)
                {
                    if (Item.ID == obj.ID)
                    {
                        Item.ID = obj.ID;
                        Item.titleID = obj.titleID;
                        Item.personTypeID = obj.personTypeID;
                        Item.firstName = obj.firstName;
                        Item.middleName = obj.middleName;
                        Item.surname = obj.surname;
                        Item.dateOfBirth = obj.dateOfBirth;
                        Item.genderID = obj.genderID;
                        Item.dateBaptised = obj.dateBaptised;
                        Item.dateConfirmed = obj.dateConfirmed;
                        Item.maritalStatusID = obj.maritalStatusID;
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

    public bool Delete_Item(ref Exception pEx, int ID)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeletePersons";
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
            cmd.CommandText = "usp_EnablePersons";
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
            cmd.CommandText = "usp_DisablePersons";
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

    private int Save_Read(ref Exception pEx, SqlCommand cmd)
    {
        int ID = 0;
        try
        {
            var retVal = cmd.ExecuteScalar().ToString();
            ID = Convert.ToInt32(retVal);
            return ID;
        }
        catch (Exception ex)
        {
            pEx = ex;
            return ID;
        }
    }
}

public class clsPersons_Item
{
    private int _ID;
    private int _titleID;
    private int _personTypeID;
    private string _firstName;
    private string _middleName;
    private string _surname;
    private DateTime _dateOfBirth;
    private int _genderID;
    private DateTime _dateBaptised;
    private DateTime _dateConfirmed;
    private int _maritalStatusID;
    private bool _isDeleted;


    public clsPersons_Item()
    {
        //Default constructor
    }

    public clsPersons_Item(int ID, int titleID, int personTypeID, string firstName, string middleName, string surname, DateTime dateOfBirth, int genderID, DateTime dateBaptised, DateTime dateConfirmed, int maritalStatusID)
    {
        _ID = ID;
        _titleID = titleID;
        _personTypeID = personTypeID;
        _firstName = firstName;
        _middleName = middleName;
        _surname = surname;
        _dateOfBirth = dateOfBirth;
        _genderID = genderID;
        _dateBaptised = dateBaptised;
        _dateConfirmed = dateConfirmed;
        _maritalStatusID = maritalStatusID;
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

    [XmlElement(typeof(int))]
    public int titleID
    {
        get
        {
            return _titleID;
        }

        set
        {
            if (!(_titleID == value))
            {
                _titleID = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int personTypeID
    {
        get
        {
            return _personTypeID;
        }

        set
        {
            if (!(_personTypeID == value))
            {
                _personTypeID = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string firstName
    {
        get
        {
            return _firstName;
        }

        set
        {
            if (!(_firstName == value))
            {
                _firstName = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string middleName
    {
        get
        {
            return _middleName;
        }

        set
        {
            if (!(_middleName == value))
            {
                _middleName = value;

            }
        }
    }

    [XmlElement(typeof(string))]
    public string surname
    {
        get
        {
            return _surname;
        }

        set
        {
            if (!(_surname == value))
            {
                _surname = value;

            }
        }
    }

    [XmlElement(typeof(DateTime))]
    public DateTime dateOfBirth
    {
        get
        {
            return _dateOfBirth;
        }

        set
        {
            if (!(_dateOfBirth == value))
            {
                _dateOfBirth = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int genderID
    {
        get
        {
            return _genderID;
        }

        set
        {
            if (!(_genderID == value))
            {
                _genderID = value;

            }
        }
    }

    [XmlElement(typeof(DateTime))]
    public DateTime dateBaptised
    {
        get
        {
            return _dateBaptised;
        }

        set
        {
            if (!(_dateBaptised == value))
            {
                _dateBaptised = value;

            }
        }
    }

    [XmlElement(typeof(DateTime))]
    public DateTime dateConfirmed
    {
        get
        {
            return _dateConfirmed;
        }

        set
        {
            if (!(_dateConfirmed == value))
            {
                _dateConfirmed = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int maritalStatusID
    {
        get
        {
            return _maritalStatusID;
        }

        set
        {
            if (!(_maritalStatusID == value))
            {
                _maritalStatusID = value;

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
