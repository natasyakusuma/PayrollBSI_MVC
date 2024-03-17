using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.BO
{
	public class AttendanceBO
	{
		public int AttendanceID { get; set; }
		public int EmployeeID { get; set; }
		public decimal OvertimeHours { get; set; }
		public decimal RegularHours { get; set; }
		public int AttendanceTotal { get; set; }

		public IEnumerable<EmployeeBO> Employees { get; set; }
	}

}
