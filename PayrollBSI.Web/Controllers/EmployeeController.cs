using Microsoft.AspNetCore.Mvc;
using PayrollBSI.BLL.DTO;
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
            if (HttpContext.Session.GetString("Employee") == null)
            {
                return RedirectToAction("Login", "Employee");
            }
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

        public IActionResult Login()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                var username = loginDTO.Username;
                var password = loginDTO.Password;
                var employee = _employeeBLL.Login(username, password);

                //save session 
                var employeeDtoSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(employee);
                HttpContext.Session.SetString("Employee", employeeDtoSerialized);

                TempData["Message"] = @"<div class='alert alert-success'><strong>Success!&nbsp;</strong>Login success</div>";
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                TempData["Message"] = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
                return View();
            }
        }

    }


}
