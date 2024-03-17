using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BO;

namespace PayrollBSI.DAL.InterfaceDAL
{
	public interface IAttendance : ICrud<AttendanceBO>
	{
		AttendanceBO GetAttendanceByEmployeeID(int employeeID);
		AttendanceBO GetAttendanceByEmployeeName(string employeeName);
		AttendanceBO GetAttendanceWithEmployeeName(string employeeName);
	}
}
