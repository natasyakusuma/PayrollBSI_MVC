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
            ViewData["Title"] = "Home Page";
            return View();
        }
    }
}
