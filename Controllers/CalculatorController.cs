using CalculatorAA.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAA.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            CalculatorModel model = new CalculatorModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Calculate(CalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                model.Calculate();
                ViewBag.CalculatedResult = model.Result; // Store the calculated result in ViewBag

            }


            return Json(new { result = ViewBag.CalculatedResult });

        }
    }
}
