using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.InterfaceBLL;
using PayrollBSI.BO;
using PayrollBSI.DAL;
using PayrollBSI.DAL.InterfaceDAL;

namespace PayrollBSI.BLL
{
	public class PayrollDetailsBLL : IPayrollDetailsBLL
	{
		public readonly IPayrollDetails _payrollDetailsDAL;
		public PayrollDetailsBLL()
		{
			_payrollDetailsDAL = new PayrollDetailsDAL();
		}
		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PayrollDetailsDTO> GetAll()
		{
			List<PayrollDetailsDTO> listPayrollDetailsDto = new List<PayrollDetailsDTO>();
			var payrollDetailsFromDAL = _payrollDetailsDAL.GetAll();
			foreach (var payrollDetails in payrollDetailsFromDAL)
			{
				listPayrollDetailsDto.Add(new PayrollDetailsDTO
				{
					PayrollDetailID = payrollDetails.PayrollDetailID,
					EmployeeID = payrollDetails.EmployeeID,
					EmployeeName = payrollDetails.EmployeeName,
					PayrollDate = payrollDetails.PayrollDate,
					TotalAllowances = payrollDetails.TotalAllowances,
					TotalDeductions = payrollDetails.TotalDeductions,
					GrossPay = payrollDetails.GrossPay,
					NetPayNoTax = payrollDetails.NetPayNoTax,
					NetPayWithTax = payrollDetails.NetPayWithTax,

				});

			}
			return listPayrollDetailsDto;
		}



		public PayrollDetailsDTO GetById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PayrollDetailsDTO> GetWithEmployeeName(string name)
		{
			throw new NotImplementedException();
		}

		public void Insert(PayrollDetailsCreateDTO obj)
		{
			try
			{
				var payrollDetailsCreateBO = new PayrollDetailsCreateBO
				{
					EmployeeID = obj.EmployeeID,
					AttendanceID = obj.AttendanceID
				};
				_payrollDetailsDAL.Insert(payrollDetailsCreateBO);

			}
			catch (Exception ex)
			{
				throw new Exception("Error occurred while inserting PayrollDetails: " + ex.Message);
			}
		}

		public void Update(PayrollDetailsDTO obj)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PayrollDetailsDTO> GetByEmployeeID(int id)
		{
			throw new NotImplementedException();
		}
	}
}
