using CalculatorAA.Models;
using Microsoft.AspNetCore.Mvc;
using CalculatorLib; // Make sure this using statement is present

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
                try
                {
                    double calculatedResult = ExpressionEvaluator.EvaluateExpression(model.Expression);
                    model.Result = calculatedResult; // Update the Result property
                    ViewBag.CalculatedResult = calculatedResult; // Store the calculated result in ViewBag
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("Expression", ex.Message);
                }
            }

            return View("Index", model); // Return the view with potential error messages
        }
    }
}
