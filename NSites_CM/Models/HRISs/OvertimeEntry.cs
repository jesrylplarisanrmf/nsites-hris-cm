using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NSites_CM.Models.HRISs
{
    public class OvertimeEntry
    {
        #region "PROPERTIES"
        public string OvertimeEntryId
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
        public DateTime TimeIn
        {
            get;
            set;
        }
        public DateTime TimeOut
        {
            get;
            set;
        }
        public DateTime Overtime
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
        #endregion "END OF PROPERTIES"

        #region "Methods"
        public DataTable getOvertimeEntryEmployeeList(string pEmploymentTypeId, DateTime pFromDate, DateTime pToDate,
                                    string pSearchString, string pDepartmentId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetOvertimeEntryEmployeeList('" + pEmploymentTypeId + "', '" +
                                string.Format("{0:yyyy-MM-dd}", pFromDate) + "','" +
                                string.Format("{0:yyyy-MM-dd}", pToDate) + "','" +
                                pSearchString + "','" +
                                pDepartmentId + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getOvertimeEntries(string pEmploymentNo, DateTime pFromDate, DateTime pToDate)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetOvertimeEntries('" + pEmploymentNo + "', '" +
                                string.Format("{0:yyyy-MM-dd}", pFromDate) + "','" +
                                string.Format("{0:yyyy-MM-dd}", pToDate) + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getOvertimeEntryStatus(string pOvertimeEntryId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetOvertimeEntryStatus('" + pOvertimeEntryId + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getOvertimeEntry(string pOvertimeEntryId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetOvertimeEntry('" + pOvertimeEntryId + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public bool insertOvertimeEntry(OvertimeEntry pOvertimeEntry, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call  spInsertOvertimeEntry('" + pOvertimeEntry.Date.ToString("yyyy-MM-dd") + "', '" + 
                                                     pOvertimeEntry.EmployeeNo + "', '" +
                                                     pOvertimeEntry.TimeIn.ToString("H:mm") + "', '" + pOvertimeEntry.TimeOut.ToString("H:mm") + "', '" +
                                                     pOvertimeEntry.Overtime.ToString("H:mm") + "', '" + pOvertimeEntry.Remarks + "', '" +
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

        public bool approveOvertimeEntry(string pOvertimeEntryId, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spApproveOvertimeEntry('" + pOvertimeEntryId + "', '" + pUserId + "')", _conn);
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

        public bool cancelOvertimeEntry(string pOvertimeEntryId, string pCancelReason, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spCancelOvertimeEntry('" + pOvertimeEntryId + "', '" + pCancelReason + "', '" + pUserId + "')", _conn);
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

        public bool removeOvertimeEntry(string pOvertimeEntryId, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call  spRemoveOvertimeEntry('" + pOvertimeEntryId + "', '" + pUserId + "')", _conn);
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