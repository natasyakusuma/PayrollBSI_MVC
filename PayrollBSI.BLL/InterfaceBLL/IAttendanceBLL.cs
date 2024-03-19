using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollBSI.BLL.DTO;

namespace PayrollBSI.BLL.InterfaceBLL
{
    public interface IAttendanceBLL
    {
        void Delete(int id);
        IEnumerable<AttendanceDTO> GetAll();
        AttendanceDTO GetById(int id);
        IEnumerable<AttendanceDTO> GetWithEmployeeName(string name);
		AttendanceDTO GetByEmployeeID(int id);
        void Insert(AttendanceDTO obj);
        void Update(AttendanceDTO obj);


    }
}
