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
	public class EmployeeDAL : IEmployee
	{
		private string GetConnectionString()
		{
			return Helper.GetConnectionString();
		}
		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EmployeeBO> GetAll()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "SELECT * FROM Employee";
				try
				{
					var result = conn.Query<EmployeeBO>(strSql);
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception("Error GetAllEmployee DAL: " + ex.Message);
				}
			}
		}

		public EmployeeBO GetById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EmployeeBO> GetByRoleNameAndPositionName(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EmployeeBO> GetWithRoleNameAndPositionName()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(GetConnectionString()))
				{
					conn.Open(); // Open the connection

					// Define the stored procedure name
					string storedProcedureName = "dbo.GetEmployeesDetail";

					// Execute the stored procedure and store the result
					var result = conn.Query<EmployeeBO>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

					return result; // Return the result
				}
			}
			catch (Exception ex)
			{
				// Handle any exceptions
				throw new Exception("Error GetWithRoleNameAndPositionName DAL: " + ex.Message);
			}
		}


		public void Insert(EmployeeBO obj)
		{
			throw new NotImplementedException();
		}

		public void Update(EmployeeBO obj)
		{
			throw new NotImplementedException();
		}

		public EmployeeBO Login(string username, string password)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "SELECT * FROM Employee WHERE Username = @Username AND Password = @Password";
				var param = new { Username = username, Password = password };
				try
				{
					var result = conn.QueryFirstOrDefault<EmployeeBO>(strSql, param);
					if (result == null)
					{
						throw new Exception("Invalid username or password");
					}
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception("Error occurred while logging in: " + ex.Message);
				}
			}
		}
	}
}



