using Microsoft.AspNetCore.Mvc;
using LifetimesExample.Services;
using LifetimesExample.Interfaces;

namespace LifetimesExample.Controllers
{
    public class ExampleController : Controller
    {
        private readonly ExampleService _exampleService;
        private readonly IExampleTransient _transientExample;
        private readonly IExampleScoped _scopedExample;
        private readonly IExampleSingleton _singletonExample;
        private readonly IExampleSingletonInstance _singletonInstanceExample;

        public ExampleController(ExampleService ExampleService,
            IExampleTransient transientExample,
            IExampleScoped scopedExample,
            IExampleSingleton singletonExample,
            IExampleSingletonInstance singletonInstanceExample)
        {
            _exampleService = ExampleService;
            _transientExample = transientExample;
            _scopedExample = scopedExample;
            _singletonExample = singletonExample;
            _singletonInstanceExample = singletonInstanceExample;
        }

        public IActionResult Index()
        {
            // viewbag contains controller-requested services
            ViewBag.Transient = _transientExample;
            ViewBag.Scoped = _scopedExample;
            ViewBag.Singleton = _singletonExample;
            ViewBag.SingletonInstance = _singletonInstanceExample;

            // Example service has its own requested services
            ViewBag.Service = _exampleService;

            return View();
        }
    }
}