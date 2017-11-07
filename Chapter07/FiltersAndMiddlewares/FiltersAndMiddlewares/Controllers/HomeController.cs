using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FiltersAndMiddlewares.Models;
using FiltersAndMiddlewares.Filters;

namespace FiltersAndMiddlewares.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ServiceFilter(typeof(SomeFilter))]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [TypeFilter(typeof(SomeFilter))]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
