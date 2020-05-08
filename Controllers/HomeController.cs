using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SquareRootWeb.Models;

namespace SquareRootWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string firstNumber, string secondNumber)
        {

            var numOne = firstNumber;
            var numTwo = secondNumber;

            int numberOne;
            int numberTwo;
            while ((!int.TryParse(numOne, out numberOne)) || (!int.TryParse(numTwo, out numberTwo)))
            {
                // Console.WriteLine("This is not a number!");
                numOne = firstNumber;
                numTwo = secondNumber;
            }
            double sqr1 = Math.Sqrt(numberOne);
            double sqr2 = Math.Sqrt(numberTwo);

            ViewBag.Number1 = numberOne;
            ViewBag.Number2 = numberTwo;
            ViewBag.Result1 = sqr1;
            ViewBag.Result2 = sqr2;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
