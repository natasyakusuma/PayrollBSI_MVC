using System.ComponentModel.DataAnnotations;

namespace PayrollBSI.Web.Models
{
    public class EmpModels
    {
        [Display(Name = "Enter Date")]
        [DataType(DataType.Date)] // This attribute ensures that only date values are accepted
        public DateTime EnterDate { get; set; }
    }
}
