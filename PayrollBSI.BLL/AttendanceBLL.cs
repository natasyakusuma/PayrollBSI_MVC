using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.InterfaceBLL;
using PayrollBSI.DAL.InterfaceDAL;
using PayrollBSI.DAL;

namespace PayrollBSI.BLL
{
    public class AttendanceBLL : IAttendanceBLL
    {
        public readonly IAttendance _attendanceDAL;
        public AttendanceBLL()
        {
            _attendanceDAL = new AttendanceDAL();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AttendanceDTO> GetAll()
        {
            List<AttendanceDTO> listAttendanceDto = new List<AttendanceDTO>();
            var attendanceFromDAL = _attendanceDAL.GetAll();
            foreach (var attendance in attendanceFromDAL)
            {
                listAttendanceDto.Add(new AttendanceDTO
                {
                    AttendanceID = attendance.AttendanceID,
                    EmployeeID = attendance.EmployeeID,
                    OvertimeHours = attendance.OvertimeHours,
                    RegularHours = attendance.RegularHours,
                    AttendanceTotal = attendance.AttendanceTotal,
                });
            }
            return listAttendanceDto;
        }

        public AttendanceDTO GetByEmployeeID(int id)
        {
            AttendanceDTO attendanceDTO = new AttendanceDTO();
            var attendanceFromDAL = _attendanceDAL.GetAttendanceByEmployeeID(id);
            if (attendanceFromDAL != null)
            {
                attendanceDTO = new AttendanceDTO
                {
                    AttendanceID = attendanceFromDAL.AttendanceID,
                    EmployeeID = attendanceFromDAL.EmployeeID,
                    OvertimeHours = attendanceFromDAL.OvertimeHours,
                    RegularHours = attendanceFromDAL.RegularHours,
                    AttendanceTotal = attendanceFromDAL.AttendanceTotal,
                };
            }
            else
            {
                throw new Exception("Error GetByEmployeeID AttendanceBLL: Attendance not found");
            }
            return attendanceDTO;
        }


        public AttendanceDTO GetById(int id)
        {
            AttendanceDTO attendanceDTO = new AttendanceDTO();
            var attendanceFromDAL = _attendanceDAL.GetById(id);
            if (attendanceFromDAL != null)
            {
                attendanceDTO = new AttendanceDTO
                {
                    AttendanceID = attendanceFromDAL.AttendanceID,
                    EmployeeID = attendanceFromDAL.EmployeeID,
                    OvertimeHours = attendanceFromDAL.OvertimeHours,
                    RegularHours = attendanceFromDAL.RegularHours,
                    AttendanceTotal = attendanceFromDAL.AttendanceTotal,
                };
            }
            else
            {
                throw new Exception("Error GetById AttendanceBLL: Attendance not found");
            }
            return attendanceDTO;
        }

        public IEnumerable<AttendanceDTO> GetWithEmployeeName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(AttendanceDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Update(AttendanceDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
