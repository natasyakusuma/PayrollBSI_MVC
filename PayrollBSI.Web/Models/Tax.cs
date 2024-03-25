using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PayrollBSI.Web.Models;

[Table("Tax")]
public partial class Tax
{
    [Key]
    [Column("TaxID")]
    public int TaxId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MinSalary { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MaxSalary { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? TaxRate { get; set; }
}
