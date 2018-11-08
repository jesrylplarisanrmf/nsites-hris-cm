using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NSites_CM.Models.HRISs
{
    public class LeaveEntry
    {
        #region "PROPERTIES"
        public string LeaveEntryId
        {
            get;
            set;
        }
        public string EmployeeNo
        {
            get;
            set;
        }
        public string LeaveTypeCode
        {
            get;
            set;
        }
        public string WithPay
        {
            get;
            set;
        }
        public string ReferenceNo
        {
            get;
            set;
        }
        public DateTime StartDate
        {
            get;
            set;
        }
        public DateTime EndDate
        {
            get;
            set;
        }
        public string Time
        {
            get;
            set;
        }
        public string Explanation
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
        public DateTime DateFiled
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

        public DataTable getLeaveEntries(string pEmploymentTypeId, DateTime pFromDate, DateTime pToDate, string pSearchString, string pDepartmentId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLeaveEntries('" + pEmploymentTypeId + "', '" +
                                string.Format("{0:yyyy-MM-dd}", pFromDate) + "','" +
                                string.Format("{0:yyyy-MM-dd}", pToDate) + "','" +
                                pSearchString + "','" +
                                pDepartmentId + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getLeaveEntry(string pLeaveEntryId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLeaveEntry('" + pLeaveEntryId + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getLeaveEntryStatus(string pLeaveEntryId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetLeaveEntryStatus('" + pLeaveEntryId + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public bool insertLeaveEntry(LeaveEntry loLeaveEntry, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spInsertLeaveEntry('" + loLeaveEntry.EmployeeNo + "', '" +
                                                                           loLeaveEntry.LeaveTypeCode + "','" +
                                                                           loLeaveEntry.WithPay + "','" +
                                                                           loLeaveEntry.ReferenceNo + "','" +
                                                                           String.Format("{0:yyyy-MM-dd}", loLeaveEntry.StartDate) + "','" +
                                                                           String.Format("{0:yyyy-MM-dd}", loLeaveEntry.EndDate) + "','" +
                                                                           loLeaveEntry.Time + "','" +
                                                                           loLeaveEntry.Explanation + "','" +
                                                                           loLeaveEntry.Remarks + "','" +
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

        public bool updateLeaveEntry(LeaveEntry loLeaveEntry, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateLeaveEntry('" + loLeaveEntry.LeaveEntryId + "','" +
                                                                           loLeaveEntry.EmployeeNo + "', '" +
                                                                           loLeaveEntry.LeaveTypeCode + "','" +
                                                                           loLeaveEntry.WithPay + "','" +
                                                                           loLeaveEntry.ReferenceNo + "','" +
                                                                           String.Format("{0:yyyy-MM-dd}", loLeaveEntry.StartDate) + "','" +
                                                                           String.Format("{0:yyyy-MM-dd}", loLeaveEntry.EndDate) + "','" +
                                                                           loLeaveEntry.Time + "','" +
                                                                           loLeaveEntry.Explanation + "','" +
                                                                           loLeaveEntry.Remarks + "','" +
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

        public bool removeLeaveEntry(string pLeaveEntryId, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveLeaveEntry('" + pLeaveEntryId + "', '" + pUserId + "')", _conn);
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

        public bool approveLeaveEntry(string pLeaveEntryId, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spApproveLeaveEntry('" + pLeaveEntryId + "', '" + pUserId + "')", _conn);
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
                catch(Exception e)
                {
                    _success = false;
                }
                return _success;
            }
        }

        public bool approveLeaveEntryByDate(string pLeaveEntryId, DateTime pDate, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spApproveLeaveEntryByDate('" + pLeaveEntryId + "', '" + pDate.ToString("yyyy-MM-dd") + "', '" + pUserId + "')", _conn);
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

        public bool cancelLeaveEntry(string pLeaveEntryId, string pCancelReason, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spCancelLeaveEntry('" + pLeaveEntryId + "', '" + pCancelReason + "', '" + pUserId + "')", _conn);
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
                catch(Exception e)
                {
                    _success = false;
                }
                return _success;
            }
        }
    }
}