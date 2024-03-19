using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PayrollBSI.BO;
using PayrollBSI.DAL.InterfaceDAL;

namespace PayrollBSI.DAL
{
    public class AttendanceDAL : IAttendance
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AttendanceBO> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT AttendanceID, EmployeeID, OvertimeHours, RegularHours, AttendanceTotal
                        FROM Attendance";
                try
                {
                    var result = conn.Query<AttendanceBO>(strSql);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error GetAllAttendance DAL: " + ex.Message);
                }
            }
        }


        public AttendanceBO GetAttendanceByEmployeeID(int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT AttendanceID, EmployeeID, OvertimeHours, RegularHours, AttendanceTotal
                        FROM Attendance
                        WHERE EmployeeID = @EmployeeID";
                try
                {
                    var result = conn.QueryFirstOrDefault<AttendanceBO>(strSql, new { EmployeeID = employeeID });
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error GetAttendanceByEmployeeID DAL: " + ex.Message);
                }
            }
        }

        public AttendanceBO GetAttendanceByEmployeeName(string employeeName)
        {
            throw new NotImplementedException();
        }

        public AttendanceBO GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT AttendanceID, EmployeeID, OvertimeHours, RegularHours, AttendanceTotal
                        FROM Attendance
                        WHERE AttendanceID = @AttendanceID";
                try
                {
                    var result = conn.QueryFirstOrDefault<AttendanceBO>(strSql, new { AttendanceID = id });
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error GetAttendanceByID DAL: " + ex.Message);
                }
            }
        }

        public void Insert(AttendanceBO obj)
        {
            throw new NotImplementedException();
        }

        public void Update(AttendanceBO obj)
        {
            throw new NotImplementedException();
        }

        public AttendanceBO GetAttendanceWithEmployeeName(string employeeName)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT a.AttendanceID, a.EmployeeID, a.OvertimeHours, a.RegularHours, a.AttendanceTotal,
                                    e.FirstName AS EmployeeFirstName, e.LastName AS EmployeeLastName
                               FROM Attendance a
                               JOIN Employee e ON a.EmployeeID = e.EmployeeID
                               WHERE e.FirstName + ' ' + e.LastName = @EmployeeName";
                var param = new { EmployeeName = employeeName };
                try
                {
                    var result = conn.QueryFirstOrDefault<AttendanceBO>(strSql, param);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error GetAttendanceWithEmployeeName DAL: " + ex.Message);
                }
            }
        }
    }
}
