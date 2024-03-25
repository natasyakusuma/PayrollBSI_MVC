using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Payroll.APISolution.Models;

[Table("Position")]
public partial class Position
{
    [Key]
    [Column("PositionID")]
    public int PositionId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string PositionName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal AllowanceMeal { get; set; }

    [Column(TypeName = "money")]
    public decimal AllowanceTransport { get; set; }

    [Column(TypeName = "money")]
    public decimal DeductionPension { get; set; }

    [Column(TypeName = "money")]
    public decimal DeductionInsurance { get; set; }

    [Column(TypeName = "money")]
    public decimal PayrateOvertime { get; set; }

    [Column(TypeName = "money")]
    public decimal PayrateRegular { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    [InverseProperty("Position")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
