using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;

namespace PayrollBSI.BLL.InterfaceBLL
{
	public interface IEmployeeBLL
	{
		void Delete(int id);
		void Insert(EmployeeDTO obj);
		void Update(EmployeeDTO obj);
		IEnumerable<EmployeeDTO> GetAll();
		PositionDTO GetById(int id);
		IEnumerable<EmployeeDTO> GetWithRoleNameAndPositionName();
		IEnumerable<EmployeeDTO> GetByRoleNameAndPositionName(int id);

		EmployeeDTO Login(string username, string password);
	}
}
