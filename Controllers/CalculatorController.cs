// Controllers/CalculatorController.cs
using Microsoft.AspNetCore.Mvc;

public class CalculatorController : Controller
{
    private static List<string> calculationHistory = new List<string>();
    public IActionResult Calculator()
    {
        ViewBag.CalculationHistory = calculationHistory;
        return View();
    }

    [HttpPost]
    public IActionResult Calculate(CalculatorModel model)
    {
        if (!ModelState.IsValid)
        {
            foreach (var modelStateEntry in ModelState.Values)
            {
                foreach (var error in modelStateEntry.Errors)
                {
                    string errorMessage = error.ErrorMessage;
                    ViewBag.Error = errorMessage;
                }
            }

            ViewBag.CalculationHistory = calculationHistory;
            return View("Calculator", model);
        }


        decimal result ;

        switch (model.Operator)
        {
            case "+":
                result = model.X + model.Y;
                break;
            case "-":
                result = model.X - model.Y;
                break;
            case "*":
                result = model.X * model.Y;
                break;
            case "/":
                if (model.Y != 0)
                {
                    result = model.X / model.Y;
                }
                else
                {
                    ViewBag.CalculationHistory = calculationHistory;
                    ViewBag.Error = "Cannot divide by zero";
                    return View("Calculator", model);
                }
                break;
            default:
                ViewBag.Error = "Invalid operator";
                return View("Calculator", model);
        }


        string calculation = $"{model.X} {model.Operator} {model.Y} = {result}";
        calculationHistory.Add(calculation);
        ViewBag.Result = result;
        ViewBag.CalculationHistory = calculationHistory;
        return View("Calculator", model);
    }
}
