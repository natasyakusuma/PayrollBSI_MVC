using Microsoft.AspNetCore.Mvc;
using PayrollBSI.BLL;
using PayrollBSI.BLL.DTO;
using PayrollBSI.BLL.InterfaceBLL;


namespace PayrollBSI.Web.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionBLL _positionBLL;

        public PositionController(IPositionBLL positionBLL)
        {
            _positionBLL = positionBLL;
        }

		public IActionResult Index()
		{
			try
			{
				var positions = _positionBLL.GetAllActivePositions(); // Mengambil hanya posisi yang aktif
				return View(positions);
			}
			catch (Exception ex)
			{
				ViewBag.ErrorMessage = "Error occurred while retrieving positions: " + ex.Message;
				return View();
			}
		}




		[HttpPost]
		public IActionResult Delete(int id)
		{
			try
			{
				_positionBLL.Delete(id); 
				TempData["Message"] = @"<div class='alert alert-success'><strong>Success!&nbsp;</strong>Position has been deleted</div>";
			}
			catch (Exception ex)
			{
				TempData["Message"] = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
			}

			return RedirectToAction("Index");
		}






		public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PositionDTO positionDTO)
        {
            try
            {
                _positionBLL.Insert(positionDTO);
                TempData["Message"] = @"<div class='alert alert-success'><strong>Success!&nbsp;</strong>Position has been created</div>";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error occurred while creating position: " + ex.Message;
                return View();
            }
        }



		public IActionResult Edit(int id)
		{
			var model = _positionBLL.GetById(id);
			return PartialView("_Edit", model);
		}


		[HttpPost]
		public IActionResult Edit(PositionDTO positionDTO)
		{
			try
			{
				_positionBLL.Update(positionDTO);
				TempData["Message"] = @"<div class='alert alert-success'><strong>Success!&nbsp;</strong>Position has been updated</div>";
			}
			catch (Exception ex)
			{
				TempData["Message"] = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
			}

			return RedirectToAction("Index");
		}
	}
}
