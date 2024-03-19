﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBSI.BO
{
    public class PayrollDetailsBO
    {

        public int PayrollDetailID { get; set; }
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime PayrollDate { get; set; }
        public decimal TotalAllowances { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal GrossPay { get; set; }
        public decimal NetPayNoTax { get; set; }
        public decimal NetPayWithTax { get; set; }

        public TaxBO? Tax { get; set; }
        public EmployeeBO? Employees { get; set; }



    }
}
