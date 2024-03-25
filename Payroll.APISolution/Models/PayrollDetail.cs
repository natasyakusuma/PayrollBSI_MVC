using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Payroll.APISolution.Models;

public partial class PayrollDetail
{
    [Key]
    [Column("PayrollDetailID")]
    public int PayrollDetailId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    public DateOnly PayrollDate { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalAllowances { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalDeductions { get; set; }

    [Column(TypeName = "money")]
    public decimal GrossPay { get; set; }

    [Column(TypeName = "money")]
    public decimal NetPayNoTax { get; set; }

    [Column(TypeName = "money")]
    public decimal NetPayWithTax { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("PayrollDetails")]
    public virtual Employee Employee { get; set; } = null!;
}
