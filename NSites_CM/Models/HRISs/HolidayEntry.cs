using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NSites_CM.Models.HRISs
{
    public class HolidayEntry
    {
        #region "Properties"
        public string HolidayEntryId
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        public string HolidayCode
        {
            get;
            set;
        }
        public string Approve
        {
            get;
            set;
        }
        public string ApprovedBy
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
        #endregion

        #region "Methods"
        public DataTable getHolidayEntries()
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetHolidayEntries()", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getHolidayEntry(string pHolidayEntryId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetHolidayEntry('"+ pHolidayEntryId + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getHolidayEntryStatus(string pHolidayEntryId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetHolidayEntryStatus('"+ pHolidayEntryId + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public bool insertHolidayEntry(HolidayEntry pHolidayEntry, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spInsertHolidayEntry('" + pHolidayEntry.Date.ToString("yyyy-MM-dd") + "', '" +
                                                      pHolidayEntry.HolidayCode + "', '" +
                                                      pHolidayEntry.Remarks + "', '" +
                                                      pUserId + "')", _conn);
                try
                {
                    int _RowsAffected = _cmd.ExecuteNonQuery();
                    _conn.Close();
                    if (_RowsAffected > 0)
                    {
                        _success = true;
                    }
                    else
                    {
                        _success = false;
                    }
                }
                catch
                {
                    _success = false;
                }
                return _success;
            }
        }

        public bool updateHolidayEntry(HolidayEntry pHolidayEntry, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateHolidayEntry('"+ pHolidayEntry.HolidayEntryId + "', '" + 
                                                      pHolidayEntry.Date.ToString("yyyy-MM-dd") + "', '" +
                                                      pHolidayEntry.HolidayCode + "', '" +
                                                      pHolidayEntry.Remarks + "', '" +
                                                      pUserId + "')", _conn);
                try
                {
                    int _RowsAffected = _cmd.ExecuteNonQuery();
                    _conn.Close();
                    if (_RowsAffected > 0)
                    {
                        _success = true;
                    }
                    else
                    {
                        _success = false;
                    }
                }
                catch
                {
                    _success = false;
                }
                return _success;
            }
        }

        public bool approveHolidayEntry(string pHolidayEntryId, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spApproveHolidayEntry('" + pHolidayEntryId + "', '" + pUserId + "')", _conn);
                try
                {
                    int _RowsAffected = _cmd.ExecuteNonQuery();
                    _conn.Close();
                    if (_RowsAffected > 0)
                    {
                        _success = true;
                    }
                    else
                    {
                        _success = false;
                    }
                }
                catch
                {
                    _success = false;
                }
                return _success;
            }
        }

        public bool cancelHolidayEntry(string pHolidayEntryId, string pCancelReason, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spCancelHolidayEntry('" + pHolidayEntryId + "', '"+ pCancelReason + "', '" + pUserId + "')", _conn);
                try
                {
                    int _RowsAffected = _cmd.ExecuteNonQuery();
                    _conn.Close();
                    if (_RowsAffected > 0)
                    {
                        _success = true;
                    }
                    else
                    {
                        _success = false;
                    }
                }
                catch
                {
                    _success = false;
                }
                return _success;
            }
        }

        public bool removeHolidayEntry(string pHolidayEntryId, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveHolidayEntry('"+ pHolidayEntryId + "', '" + pUserId + "')", _conn);
                try
                {
                    int _RowsAffected = _cmd.ExecuteNonQuery();
                    _conn.Close();
                    if (_RowsAffected > 0)
                    {
                        _success = true;
                    }
                    else
                    {
                        _success = false;
                    }
                }
                catch
                {
                    _success = false;
                }
                return _success;
            }
        }
        #endregion
    }
}