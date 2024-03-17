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
	public class RolesDAL : IRoles
	{
		private string GetConnectionString()
		{
			return Helper.GetConnectionString();
		}
		public void Delete(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "DELETE FROM Roles WHERE RoleID = @RoleID";
				var param = new { RoleID = id };
				try
				{
					conn.Execute(strSql, param);
				}
				catch (Exception ex)
				{
					throw new Exception("Error DeleteRoles DAL: " + ex.Message);
				}
			}
		}

		public IEnumerable<RolesBO> GetAll()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "SELECT * FROM Roles";
				var result = conn.Query<RolesBO>(strSql);
				return result;

			}
		}

		public RolesBO GetById(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "SELECT * FROM Roles WHERE RoleID = @RoleID";
				var param = new { RoleID = id };
				try
				{
					var result = conn.Query<RolesBO>(strSql, param).SingleOrDefault();
					if (result == null)
					{
						throw new Exception($"Role with ID {id} not found.");
					}
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception("Error GetRoleById DAL: " + ex.Message);
				}
			}
		}


		public void Insert(RolesBO obj)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "INSERT INTO Roles (RoleName) VALUES (@RoleName)";
				var param = new { RoleName = obj.RoleName };
				try
				{
					int result = conn.Execute(strSql, param);
					if (result != 1)
					{
						throw new Exception("Insert Role failed");
					}
				}
				catch (SqlException sqlEx)
				{
					throw new ArgumentException($"{sqlEx.Message} - {sqlEx.Number}");
				}
				catch (Exception ex)
				{
					throw new ArgumentException(ex.Message);
				}
			}
		}

		public void Update(RolesBO obj)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "UPDATE Roles SET RoleName = @RoleName WHERE RoleID = @RoleID";
				var param = new { RoleName = obj.RoleName, RoleID = obj.RoleID };
				try
				{
					int result = conn.Execute(strSql, param);
					if (result != 1)
					{
						throw new Exception("Update Role failed");
					}
				}
				catch (SqlException sqlEx)
				{
					throw new ArgumentException($"{sqlEx.Message} - {sqlEx.Number}");
				}
				catch (Exception ex)
				{
					throw new ArgumentException(ex.Message);
				}
			}
		}
	}
}
