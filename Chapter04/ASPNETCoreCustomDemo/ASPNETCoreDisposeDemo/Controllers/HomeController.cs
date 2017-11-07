using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreDisposeDemo.Services;

namespace ASPNETCoreDisposeDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Sentences(ProgrammerSentenceSvc svc, 
                                       EngineerSentenceSvc svc2)
        {
            Random rnd = new Random();
            ViewData["ProgSentence"] =  svc.programmersSentences[rnd.Next(6)];
            ViewData["EngSentence"] = svc2.engineersSentences[rnd.Next(6)];
            return View();
        }

        [Route("SentencesDI")]
        public IActionResult SentencesDI()
        {
            return View();
        }

    }
}
