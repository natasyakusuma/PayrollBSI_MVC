using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BO;

namespace PayrollBSI.DAL.InterfaceDAL
{
	public interface IEmployee : ICrud<EmployeeBO>
	{
		IEnumerable<EmployeeBO> GetWithRoleNameAndPositionName();
		IEnumerable <EmployeeBO> GetByRoleNameAndPositionName(int id);

		EmployeeBO Login(string username, string password);



	}
}
