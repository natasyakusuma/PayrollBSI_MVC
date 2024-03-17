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
	public class PositionDAL : IPosition
	{
		private string GetConnectionString()
		{
			return Helper.GetConnectionString();
		}
		public void Delete(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "DeletePosition"; // Nama prosedur tersimpan
				var param = new { PositionID = id }; // Parameter yang diperlukan oleh prosedur
				try
				{
					conn.Execute(strSql, param, commandType: CommandType.StoredProcedure); // Menjalankan prosedur tersimpan
				}
				catch (Exception ex)
				{
					throw new Exception("Error DeletePosition DAL: " + ex.Message);
				}
			}
		}


		public IEnumerable<PositionBO> GetAll()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "SELECT * FROM Position";
				try
				{
					var result = conn.Query<PositionBO>(strSql);
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception("Error GetAllPosition DAL: " + ex.Message);
				}
			}
		}


		public PositionBO GetById(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "SELECT * FROM Position WHERE PositionID = @PositionID";
				var param = new { PositionID = id };
				try
				{
					var result = conn.Query<PositionBO>(strSql, param).SingleOrDefault();
					if (result == null)
					{
						throw new Exception($"Position with ID {id} not found.");
					}
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception("Error GetPositionById DAL: " + ex.Message);
				}
			}
		}


		public void Insert(PositionBO obj)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strsql = @"INSERT INTO Position(PositionName, AllowanceMeal, AllowanceTransport, DeductionPension, DeductionInsurance, PayrateOvertime, PayrateRegular, IsActive, IsDeleted) 
                    VALUES(@PositionName, @AllowanceMeal, @AllowanceTransport, @DeductionPension, @DeductionInsurance, @PayrateOvertime, @PayrateRegular, 1, 0)";
				var param = new
				{
					PositionName = obj.PositionName,
					AllowanceMeal = obj.AllowanceMeal,
					AllowanceTransport = obj.AllowanceTransport,
					DeductionPension = obj.DeductionPension,
					DeductionInsurance = obj.DeductionInsurance,
					PayrateOvertime = obj.PayrateOvertime,
					PayrateRegular = obj.PayrateRegular
				};
				try
				{
					int result = conn.Execute(strsql, param);
					if (result != 1)
					{
						throw new ArgumentException("Insert failed");
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


        public void Update(PositionBO obj)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strsql = "UPDATE Position SET PositionName = @PositionName, AllowanceMeal = @AllowanceMeal, AllowanceTransport = @AllowanceTransport, DeductionPension = @DeductionPension, DeductionInsurance = @DeductionInsurance, PayrateOvertime = @PayrateOvertime, PayrateRegular = @PayrateRegular WHERE PositionID = @PositionID";
				var param = new
				{
					PositionID = obj.PositionID,
					PositionName = obj.PositionName,
					AllowanceMeal = obj.AllowanceMeal,
					AllowanceTransport = obj.AllowanceTransport,
					DeductionPension = obj.DeductionPension,
					DeductionInsurance = obj.DeductionInsurance,
					PayrateOvertime = obj.PayrateOvertime,
					PayrateRegular = obj.PayrateRegular
				};

				try
				{
					int result = conn.Execute(strsql, param);
					if (result != 1)
					{
						throw new ArgumentException("Error UpdatePosition DAL: " + result);
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



		public IEnumerable<PositionBO> GetAllActivePositions()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "SELECT * FROM Position WHERE IsActive = 1 AND IsDeleted = 0";
				try
				{
					var result = conn.Query<PositionBO>(strSql);
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception("Error GetAllActivePositions DAL: " + ex.Message);
				}
			}
		}
	}
}


