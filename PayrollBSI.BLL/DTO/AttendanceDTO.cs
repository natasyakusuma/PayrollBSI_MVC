using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.BLL.DTO
{
    public  class AttendanceDTO
    {

        public int AttendanceID { get; set; }
        public int EmployeeID { get; set; }
        public decimal? OvertimeHours { get; set; }
        public decimal RegularHours { get; set; }
        public int AttendanceTotal { get; set; }

        public EmployeeDTO? Employees { get; set; }
    }
}
