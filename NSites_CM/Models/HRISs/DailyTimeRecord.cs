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
        public object GlobalVariables { get; private set; }

        public DataTable getEmployeeListByType(string pEmploymentType, string pSearchString, string pDepartmentCode)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetEmployeeListByType('" + pEmploymentType + "','" + pSearchString + "','" + pDepartmentCode + "')", _conn);
                _da.Fill(_dt);

                return _dt;
            }
        }

        public DataTable getDailyTimeRecordDates(string pEmployeeNo, DateTime pFromDate, DateTime pToDate)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                MySqlDataAdapter _da = new MySqlDataAdapter("call spGetDailyTimeRecordDates('" + pEmployeeNo + "','" +
                string.Format("{0:yyyy-MM-dd}", pFromDate) + "','" +
                string.Format("{0:yyyy-MM-dd}", pToDate) + "')", _conn);
                _da.Fill(_dt);

                return _dt;
            }
        }
    }
}