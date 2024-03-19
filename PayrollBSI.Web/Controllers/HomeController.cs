using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PayrollBSI.Web.Models;

namespace PayrollBSI.Web.Controllers
{
    public class HomeController : Controller
    {
        //Home/Index
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Employee") == null)
            {
                return RedirectToAction("Login", "Employee");
            }

            return View();

        }
    }
}
