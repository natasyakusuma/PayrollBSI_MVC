using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;

namespace PayrollBSI.BLL.InterfaceBLL
{
	public interface IRoleBLL
	{
		void Delete(int id);
		void Insert(RoleDTO obj);
		void Update(RoleDTO obj);
		IEnumerable<RoleDTO> GetAll();
		RoleDTO GetById(int id);
	}
}
