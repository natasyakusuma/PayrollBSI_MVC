using System.Collections.Generic;

namespace PayrollBSI.BO
{
	public class EmployeeBO
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
		public  int AttendanceID { get; set; }
		public decimal OvertimeHours { get; set; }
		public decimal RegularHours { get; set; }
		public int AttendanceTotal { get; set; }
		public PositionBO? Position { get; set; }
		public RolesBO? Roles { get; set; }
		public AttendanceBO? Attendances { get; set; }
	}
}
