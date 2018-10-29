using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NSites_CM.Models.HRISs
{
    public class DailyTimeRecord
    {
        #region "PROPERTIES"
        public string DailyTimeRecordId
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        public string EmployeeNo
        {
            get;
            set;
        }
        public string TimeIn
        {
            get;
            set;
        }
        public string BreakOut
        {
            get;
            set;
        }
        public string BreakIn
        {
            get;
            set;
        }
        public string TimeOut
        {
            get;
            set;
        }
        public string OvertimeIn
        {
            get;
            set;
        }
        public string OvertimeOut
        {
            get;
            set;
        }
        public decimal WorkingDay
        {
            get;
            set;
        }
        public decimal DaysWorkCount
        {
            get;
            set;
        }
        public string Late
        {
            get;
            set;
        }
        public string Undertime
        {
            get;
            set;
        }
        public string Overtime
        {
            get;
            set;
        }
        public string HoursWork
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
        #endregion "END PROPERTIES"

        public DataTable getEmployeeListByType(string pEmploymentTypeId, string pSearchString, string pDepartmentId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetEmployeeListByType('" + pEmploymentTypeId + "','" + pSearchString + "','" + pDepartmentId + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getDailyTimeRecordDates(string pEmployeeNo, DateTime pFromDate, DateTime pToDate)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetDailyTimeRecordDates('" + pEmployeeNo + "','" +
                string.Format("{0:yyyy-MM-dd}", pFromDate) + "','" +
                string.Format("{0:yyyy-MM-dd}", pToDate) + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getDailyTimeRecordByDate(string pEmployeeNo, DateTime pFromDate, DateTime pToDate)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetDailyTimeRecordByDate('" + pEmployeeNo + "', '" +
                string.Format("{0:yyyy-MM-dd}", pFromDate) + "','" +
                string.Format("{0:yyyy-MM-dd}", pToDate) + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public bool insertTimeIn(string pDailyTimeRecordId, string pTimeIn, string pUsername, string pHostname)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spInsertTimeIn('" + pDailyTimeRecordId + "','" + pTimeIn + "', '" + pUsername + "', '" + pHostname + "')", _conn);
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

        public bool insertBreakOut(string pDailyTimeRecordId, string pBreakOut, string pUsername, string pHostname)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spInsertBreakOut('" + pDailyTimeRecordId + "', '" + pBreakOut + "', '" + pUsername + "', '" + pHostname + "')", _conn);
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

        public bool insertBreakIn(string pDailyTimeRecordId, string pBreakIn, string pUsername, string pHostname)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spInsertBreakIn('" + pDailyTimeRecordId + "','" + pBreakIn + "', '" + pUsername + "', '" + pHostname + "')", _conn);
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

        public bool insertTimeOut(string pDailyTimeRecordId, string pTimeOut, string pUsername, string pHostname)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spInsertBreakOut('" + pDailyTimeRecordId + "', '" + pTimeOut + "', '" + pUsername + "', '" + pHostname + "')", _conn);
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

        public bool insertLate1(string pDailyTimeRecordId, string pLate1, string pUsername, string pHostname)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spInsertLate1('" + pDailyTimeRecordId + "','" + pLate1 + "', '" + pUsername + "', '" + pHostname + "')", _conn);
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

        public bool insertLate2(string pDailyTimeRecordId, string pLate2, string pUsername, string pHostname)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spInsertLate2('" + pDailyTimeRecordId + "','" + pLate2 + "', '" + pUsername + "', '" + pHostname + "')", _conn);
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

        public bool insertUndertime1(string pDailyTimeRecordId, string pUndertime1, string pUsername, string pHostname)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spInsertUndertime1('" + pDailyTimeRecordId + "','" + pUndertime1 + "', '" + pUsername + "', '" + pHostname + "')", _conn);
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

        public bool insertUndertime2(string pDailyTimeRecordId, string pUndertime2, string pUsername, string pHostname)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spInsertUndertime2('" + pDailyTimeRecordId + "','" + pUndertime2 + "', '" + pUsername + "', '" + pHostname + "')", _conn);
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

        public bool updateDailyTimeRecord(DailyTimeRecord pDailyTimeRecord)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateDailyTimeRecord('" + pDailyTimeRecord.DailyTimeRecordId + "', '" +
                                                                           pDailyTimeRecord.TimeIn + "','" +
                                                                           pDailyTimeRecord.BreakOut + "','" +
                                                                           pDailyTimeRecord.BreakIn + "','" +
                                                                           pDailyTimeRecord.TimeOut + "','" +
                                                                           pDailyTimeRecord.OvertimeIn + "','" +
                                                                           pDailyTimeRecord.OvertimeOut + "','" +
                                                                           pDailyTimeRecord.Late + "','" +
                                                                           pDailyTimeRecord.Undertime + "','" +
                                                                           pDailyTimeRecord.Overtime + "','" +
                                                                           pDailyTimeRecord.HoursWork.Replace("#", "") + "','" +
                                                                           pDailyTimeRecord.Remarks + "')", _conn);
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
                    return _success;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable updateDTRShiftSchedule(string pEmployeeNo, DateTime pFromDate, DateTime pToDate, string pShiftSchedule)
        {

            DataTable _dt = new DataTable();
            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spUpdateDTRShiftSchedule('" + pEmployeeNo + "', '" +
                                                    string.Format("{0:yyyy-MM-dd}", pFromDate) + "','" +
                                                    string.Format("{0:yyyy-MM-dd}", pToDate) + "','" +
                                                    pShiftSchedule + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }
    }
}