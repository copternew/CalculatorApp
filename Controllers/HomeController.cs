using Microsoft.AspNetCore.Mvc;
namespace CalculatorApp.Controllers;

public class HomeController : Controller
{
    private static List<string> calculationHistory = new List<string>();
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

}