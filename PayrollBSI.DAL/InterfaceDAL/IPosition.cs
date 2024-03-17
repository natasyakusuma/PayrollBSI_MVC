using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BO;

namespace PayrollBSI.DAL.InterfaceDAL
{
	public interface IPosition : ICrud<PositionBO>
	{
		IEnumerable<PositionBO> GetAllActivePositions();
	}
}
