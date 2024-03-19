using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollBSI.BLL.DTO;

namespace PayrollBSI.Web
{
	public class ViewModelsCreatePayroll
	{
		public IEnumerable<SelectListItem> Employee { get; set; }
		// Other properties as needed

		public IEnumerable<SelectListItem> Attendance { get; set; }

		// Properties to store selected values
		public PayrollDetailsCreateDTO CreateDTO { get; set; }



	}

}
