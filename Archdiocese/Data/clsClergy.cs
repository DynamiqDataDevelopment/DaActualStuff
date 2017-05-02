
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Xml.Serialization;

public class clsClergy_List : List<clsClergy_Item>
{
    private string _connectionString = string.Empty;

    public clsClergy_List(string connectionString)
    {
        _connectionString = connectionString;
    }

    public clsClergy_List(string connectionString, ref Exception pEx, int ID, int clergyTitleID, int clergyTypeID, string firstName, string middleName, string surname, DateTime dateOfBirth, int genderID, DateTime dateBaptised, DateTime dateConfirmed, DateTime dateOrdained)
    {
        _connectionString = connectionString;
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetClergy";
            if (!(ID == 0)) cmd.Parameters.AddWithValue("@ID", ID);
            if (!(clergyTitleID == 0)) cmd.Parameters.AddWithValue("@clergyTitleID", clergyTitleID);
            if (!(clergyTypeID == 0)) cmd.Parameters.AddWithValue("@clergyTypeID", clergyTypeID);
            if (!(firstName == string.Empty)) cmd.Parameters.AddWithValue("@firstName", firstName);
            if (!(middleName == string.Empty)) cmd.Parameters.AddWithValue("@middleName", middleName);
            if (!(surname == string.Empty)) cmd.Parameters.AddWithValue("@surname", surname);
            if (!(dateOfBirth == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            if (!(genderID == 0)) cmd.Parameters.AddWithValue("@genderID", genderID);
            if (!(dateBaptised == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateBaptised", dateBaptised);
            if (!(dateConfirmed == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateConfirmed", dateConfirmed);
            if (!(dateOrdained == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateOrdained", dateOrdained);
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
                clsClergy_Item tmp = new clsClergy_Item();
                if (!(data_reader["ID"] == DBNull.Value)) tmp.ID = (int)data_reader["ID"];
                if (!(data_reader["clergyTitleID"] == DBNull.Value)) tmp.clergyTitleID = (int)data_reader["clergyTitleID"];
                if (!(data_reader["clergyTypeID"] == DBNull.Value)) tmp.clergyTypeID = (int)data_reader["clergyTypeID"];
                if (!(data_reader["firstName"] == DBNull.Value)) tmp.firstName = (string)data_reader["firstName"];
                if (!(data_reader["middleName"] == DBNull.Value)) tmp.middleName = (string)data_reader["middleName"];
                if (!(data_reader["surname"] == DBNull.Value)) tmp.surname = (string)data_reader["surname"];
                if (!(data_reader["dateOfBirth"] == DBNull.Value)) tmp.dateOfBirth = (DateTime)data_reader["dateOfBirth"];
                if (!(data_reader["genderID"] == DBNull.Value)) tmp.genderID = (int)data_reader["genderID"];
                if (!(data_reader["dateBaptised"] == DBNull.Value)) tmp.dateBaptised = (DateTime)data_reader["dateBaptised"];
                if (!(data_reader["dateConfirmed"] == DBNull.Value)) tmp.dateConfirmed = (DateTime)data_reader["dateConfirmed"];
                if (!(data_reader["dateOrdained"] == DBNull.Value)) tmp.dateOrdained = (DateTime)data_reader["dateOrdained"];
                if (!(data_reader["isDeleted"] == DBNull.Value)) tmp.isDeleted = (bool)data_reader["isDeleted"];
                this.Add(tmp);
            }
        }
    }

    public bool Add_Item(ref Exception pEx, clsClergy_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertClergy";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@clergyTitleID", obj.clergyTitleID);
            cmd.Parameters.AddWithValue("@clergyTypeID", obj.clergyTypeID);
            cmd.Parameters.AddWithValue("@firstName", obj.firstName);
            cmd.Parameters.AddWithValue("@middleName", obj.middleName);
            cmd.Parameters.AddWithValue("@surname", obj.surname);
            cmd.Parameters.AddWithValue("@dateOfBirth", obj.dateOfBirth);
            cmd.Parameters.AddWithValue("@genderID", obj.genderID);
            cmd.Parameters.AddWithValue("@dateBaptised", obj.dateBaptised);
            cmd.Parameters.AddWithValue("@dateConfirmed", obj.dateConfirmed);
            cmd.Parameters.AddWithValue("@dateOrdained", obj.dateOrdained);
            if (Save(ref pEx, cmd))
            {
                //this.Add(new clsClergy_Item(ID, clergyTitleID, clergyTypeID, firstName, middleName, surname, dateOfBirth, genderID, dateBaptised, dateConfirmed, dateOrdained));
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

    public int Add_Item_ReturnID(ref Exception pEx, clsClergy_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        int ID = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertClergy";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@clergyTitleID", obj.clergyTitleID);
            cmd.Parameters.AddWithValue("@clergyTypeID", obj.clergyTypeID);
            cmd.Parameters.AddWithValue("@firstName", obj.firstName);
            if (!(obj.middleName == string.Empty)) cmd.Parameters.AddWithValue("@middleName", obj.middleName);
            cmd.Parameters.AddWithValue("@surname", obj.surname);
            cmd.Parameters.AddWithValue("@dateOfBirth", obj.dateOfBirth);
            cmd.Parameters.AddWithValue("@genderID", obj.genderID);
            if (!(obj.dateBaptised == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateBaptised", obj.dateBaptised);
            if (!(obj.dateConfirmed == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateConfirmed", obj.dateConfirmed);
            if (!(obj.dateOrdained == DateTime.MinValue)) cmd.Parameters.AddWithValue("@dateOrdained", obj.dateOrdained);
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

    public bool Update_Item(ref Exception pEx, clsClergy_Item obj)
    {
        SqlConnection conn = new SqlConnection((_connectionString));
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_UpdateClergy";
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@clergyTitleID", obj.clergyTitleID);
            cmd.Parameters.AddWithValue("@clergyTypeID", obj.clergyTypeID);
            cmd.Parameters.AddWithValue("@firstName", obj.firstName);
            cmd.Parameters.AddWithValue("@middleName", obj.middleName);
            cmd.Parameters.AddWithValue("@surname", obj.surname);
            cmd.Parameters.AddWithValue("@dateOfBirth", obj.dateOfBirth);
            cmd.Parameters.AddWithValue("@genderID", obj.genderID);
            cmd.Parameters.AddWithValue("@dateBaptised", obj.dateBaptised);
            cmd.Parameters.AddWithValue("@dateConfirmed", obj.dateConfirmed);
            cmd.Parameters.AddWithValue("@dateOrdained", obj.dateOrdained);
            if (Save(ref pEx, cmd))
            {
                //foreach (clsClergy_Item Item in this)
                //{
                //    if (Item.ID == ID)
                //    {
                //        Item.ID = ID;
                //        Item.clergyTitleID = clergyTitleID;
                //        Item.clergyTypeID = clergyTypeID;
                //        Item.firstName = firstName;
                //        Item.middleName = middleName;
                //        Item.surname = surname;
                //        Item.dateOfBirth = dateOfBirth;
                //        Item.genderID = genderID;
                //        Item.dateBaptised = dateBaptised;
                //        Item.dateConfirmed = dateConfirmed;
                //        Item.dateOrdained = dateOrdained;
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
        
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteClergy";
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
            cmd.CommandText = "usp_EnableClergy";
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
            cmd.CommandText = "usp_DisableClergy";
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

public class clsClergy_Item
{
    private int _ID;
    private int _clergyTitleID;
    private int _clergyTypeID;
    private string _firstName;
    private string _middleName;
    private string _surname;
    private DateTime _dateOfBirth;
    private int _genderID;
    private DateTime _dateBaptised;
    private DateTime _dateConfirmed;
    private DateTime _dateOrdained;
    private bool _isDeleted;


    public clsClergy_Item()
    {
        //Default constructor
    }

    public clsClergy_Item(int ID, int clergyTitleID, int clergyTypeID, string firstName, string middleName, string surname, DateTime dateOfBirth, int genderID, DateTime dateBaptised, DateTime dateConfirmed, DateTime dateOrdained)
    {
        _ID = ID;
        _clergyTitleID = clergyTitleID;
        _clergyTypeID = clergyTypeID;
        _firstName = firstName;
        _middleName = middleName;
        _surname = surname;
        _dateOfBirth = dateOfBirth;
        _genderID = genderID;
        _dateBaptised = dateBaptised;
        _dateConfirmed = dateConfirmed;
        _dateOrdained = dateOrdained;
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
    public int clergyTitleID
    {
        get
        {
            return _clergyTitleID;
        }

        set
        {
            if (!(_clergyTitleID == value))
            {
                _clergyTitleID = value;

            }
        }
    }

    [XmlElement(typeof(int))]
    public int clergyTypeID
    {
        get
        {
            return _clergyTypeID;
        }

        set
        {
            if (!(_clergyTypeID == value))
            {
                _clergyTypeID = value;

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

    [XmlElement(typeof(DateTime))]
    public DateTime dateOrdained
    {
        get
        {
            return _dateOrdained;
        }

        set
        {
            if (!(_dateOrdained == value))
            {
                _dateOrdained = value;

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


