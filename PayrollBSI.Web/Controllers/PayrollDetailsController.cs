using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using PayrollBSI.BLL.InterfaceBLL;
using PayrollBSI.Web;
using PayrollBSI.Web.Models;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL;
using PayrollBSI.BO;

public class PayrollDetailsController : Controller
{
	private readonly IPayrollDetailsBLL _payrollDetailsBLL;
	private readonly IEmployeeBLL _employeeBLL;
	private readonly IAttendanceBLL _attendanceBLL;

	public PayrollDetailsController(IPayrollDetailsBLL payrollDetailsBLL, IEmployeeBLL employeeBLL, IAttendanceBLL attendanceBLL)
	{
		_payrollDetailsBLL = payrollDetailsBLL;
		_employeeBLL = employeeBLL;
		_attendanceBLL = attendanceBLL; // Inject IAttendanceBLL
	}

	// Other actions...

	// GET: PayrollDetails/Index/{employeeId}
	public IActionResult Index()
	{
		var model = _payrollDetailsBLL.GetAll();
		return View(model);
	}

	public IActionResult Create()
	{
		var employees = _employeeBLL.GetAll();
		var attendance = _attendanceBLL.GetAll();
		var createDTO = new PayrollDetailsCreateDTO();
		createDTO = null;
		var model = new ViewModelsCreatePayroll
		{
			CreateDTO = createDTO,
			Employee = employees.Select(e => new SelectListItem
			{
				Value = e.EmployeeID.ToString(),
				Text = $"{e.FirstName} {e.LastName}"
			}),
			Attendance = attendance.Select(a => new SelectListItem
			{
				Value = a.AttendanceID.ToString(),
				Text = a.AttendanceID.ToString() // Adjust as needed to display the appropriate information
			})

		};
		return View(model);
	}


	[HttpPost]
	public IActionResult Create(int EmployeeID, int AttendanceID)
	{
		try
		{
			var model = new PayrollDetailsCreateDTO
			{
				EmployeeID = EmployeeID,
				AttendanceID = AttendanceID
			};
			// Call your BLL Insert method for PositionDTO
			_payrollDetailsBLL.Insert(model);

		

			TempData["Message"] = @"<div class='alert alert-success'><strong>Success!&nbsp;</strong>Data has been inserted successfully</div>";
			return RedirectToAction("Index");
		}
		catch (Exception ex)
		{
			ViewBag.ErrorMessage = "Error occurred while inserting data: " + ex.Message;
			return View();
		}
	}


}


