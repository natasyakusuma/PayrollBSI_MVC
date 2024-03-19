using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BO;

namespace PayrollBSI.BLL.InterfaceBLL
{
	public interface IPayrollDetailsBLL
	{
		void Delete(int id);
		void Insert(PayrollDetailsCreateDTO obj);
		void Update(PayrollDetailsDTO obj);
		IEnumerable<PayrollDetailsDTO> GetAll();
		PayrollDetailsDTO GetById(int id);
		IEnumerable<PayrollDetailsDTO> GetWithEmployeeName(string name);
        IEnumerable<PayrollDetailsDTO> GetByEmployeeID(int id);

    }
}
