using Microsoft.AspNetCore.Mvc;
using PayrollBSI.BLL.InterfaceBLL;

namespace PayrollBSI.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBLL _employeeBLL;

        public EmployeeController(IEmployeeBLL employeeBLL)
        {
            _employeeBLL = employeeBLL;
        }

        public IActionResult Index()
        {
            try
            {
                var employeesDto = _employeeBLL.GetWithRoleNameAndPositionName(); // Get employees DTO
                return View(employeesDto);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error occurred while retrieving positions: " + ex.Message;
                return View();
            }
        }
    }
}
