using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.BLL.DTO
{
    public class TaxDTO
    {
        public int TaxID { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal TaxRate { get; set; }
    }
}
