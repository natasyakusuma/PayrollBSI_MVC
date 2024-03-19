using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PayrollBSI.BO;
using PayrollBSI.DAL.InterfaceDAL;

namespace PayrollBSI.DAL
{
    public class PayrollDetailsDAL : IPayrollDetails
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PayrollDetailsBO> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @" SELECT 
                                PD.PayrollDetailID,
                                PD.EmployeeID,
                                PD.PayrollDate,
                                PD.TotalAllowances,
                                PD.TotalDeductions,
                                PD.GrossPay,
                                PD.NetPayNoTax,
                                PD.NetPayWithTax,
                                CONCAT(E.FirstName, ' ', E.LastName) AS EmployeeName
                            FROM 
                                PayrollDetails PD
                            INNER JOIN 
                                Employee E ON PD.EmployeeID = E.EmployeeID";

                try
                {
                    conn.Open();
                    var result = conn.Query<PayrollDetailsBO>(strSql);
                    return result;
                }
                catch (SqlException ex)
                {
                    // Handle SQL exceptions
                    throw new Exception("SQL Error occurred while fetching PayrollDetails: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    throw new Exception("Error occurred while fetching PayrollDetails: " + ex.Message);
                }
            }
        }

        public PayrollDetailsBO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PayrollDetailsBO> GetWithEmployeeName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(PayrollDetailsCreateBO obj)
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "InsertPayrollDetails";
                var param = new
                {
					EmployeeID = obj.EmployeeID,
					AttendanceID = obj.AttendanceID
				};
                try
                {
                    int result = conn.Execute(strSql, param, commandType: CommandType.StoredProcedure);
                    if (result == 0)
                    {
                        throw new Exception("Insert PayrollDetails failed.");
                    };
                }
				catch (SqlException ex)
                {
					throw new Exception("SQL Error occurred while inserting PayrollDetails: " + ex.Message);
				}
				catch (Exception ex)
                {
					throw new Exception("Error occurred while inserting PayrollDetails: " + ex.Message);
                }
            }
        }

        public void Update(PayrollDetailsBO obj)
        {
            throw new NotImplementedException();
        }

  

        public IEnumerable<PayrollDetailsBO> GetByEmployeeID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
