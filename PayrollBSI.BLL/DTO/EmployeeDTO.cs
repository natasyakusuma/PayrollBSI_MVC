using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.BLL.DTO
{
	public class EmployeeDTO
	{
		public int EmployeeID { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public int RoleID { get; set; }
		public string? RoleName { get; set; }
		public int PositionID { get; set; }
		public string? PositionName { get; set; }
		public string? Username { get; set; }
		public string? Password { get; set; }
		public int IsDeleted { get; set; }
		public int AttendanceID { get; set; }
		public decimal OvertimeHours { get; set; }
		public decimal RegularHours { get; set; }
		public int AttendanceTotal { get; set; }

		public AttendanceDTO? Attendance { get; set; }
		public PositionDTO? Position { get; set; }

		public RoleDTO? Roles { get; set; }

	}
}
