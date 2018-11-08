using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NSites_CM.Models.HRISs
{
    public class COAEntry
    {
        #region "Properties"
        public string COAEntryId
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
        public string Type
        {
            get;
            set;
        }
        public string ReferenceNo
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
        public string Purpose
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
        public DataTable getCOAEntries(string pEmploymentTypeId, DateTime pFromDate, DateTime pToDate, string pSearchString, string pDepartmentId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetCOAEntries('" + pEmploymentTypeId + "', '" +
                                string.Format("{0:yyyy-MM-dd}", pFromDate) + "','" +
                                string.Format("{0:yyyy-MM-dd}", pToDate) + "','" +
                                pSearchString + "','" +
                                pDepartmentId + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getCOAEntryStatus(string pCOAEntryId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetCOAEntryStatus('" + pCOAEntryId + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public DataTable getCOAEntry(string pCOAEntryId)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetCOAEntry('" + pCOAEntryId + "')", _conn);
                _da.Fill(_dt);
                _conn.Close();

                return _dt;
            }
        }

        public bool insertCOAEntry(COAEntry pCOAEntry, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spInsertCOAEntry('" + pCOAEntry.Date.ToString("yyyy-MM-dd") + "', '" +
                                                                           pCOAEntry.EmployeeNo + "', '" +
                                                                           pCOAEntry.Type + "', '" +
                                                                           pCOAEntry.ReferenceNo + "', '" +
                                                                           pCOAEntry.TimeIn + "', '" +
                                                                           pCOAEntry.BreakOut + "', '" +
                                                                           pCOAEntry.BreakIn + "', '" +
                                                                           pCOAEntry.TimeOut + "', '" +
                                                                           pCOAEntry.Purpose + "', '" +
                                                                           pCOAEntry.Remarks + "', '" +
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
                catch(Exception e)
                {
                    _success = false;
                }
                return _success;
            }
        }

        public bool updateCOAEntry(COAEntry pCOAEntry, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spUpdateCOAEntry('" + pCOAEntry.COAEntryId + "', '" + 
                                                                           pCOAEntry.Date.ToString("yyyy-MM-dd") + "', '" +
                                                                           pCOAEntry.EmployeeNo + "', '" +
                                                                           pCOAEntry.Type + "', '" +
                                                                           pCOAEntry.ReferenceNo + "', '" +
                                                                           pCOAEntry.TimeIn + "', '" +
                                                                           pCOAEntry.BreakOut + "', '" +
                                                                           pCOAEntry.BreakIn + "', '" +
                                                                           pCOAEntry.TimeOut + "', '" +
                                                                           pCOAEntry.Purpose + "', '" +
                                                                           pCOAEntry.Remarks + "', '" +
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
                catch(Exception e)
                {
                    _success = false;
                }
                return _success;
            }
        }

        public bool removeCOAEntry(string pCOAEntryId, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spRemoveCOAEntry('" + pCOAEntryId + "', '" + pUserId + "')", _conn);

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

        public bool approveCOAEntry(string pCOAEntryId, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spApproveCOAEntry('" + pCOAEntryId + "', '" + pUserId + "')", _conn);

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

         

        public bool cancelCOAEntry(string pCOAEntryId, string pCancelReason, string pUserId)
        {
            bool _success = false;

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                _conn.Open();
                MySqlCommand _cmd = new MySqlCommand("call spCancelCOAEntry('" + pCOAEntryId + "', '" + pCancelReason + "', '" + pUserId + "')", _conn);

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
        #endregion
    }
}