using System.Diagnostics;
using Barney.WebUI.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Barney.WebUI.Models;

namespace Barney.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogger _testLogger;

        public HomeController(ILogger<HomeController> logger, ILoggerFactory loggerFactory)
        {
            _logger = logger;

            _testLogger = loggerFactory.CreateLogger("Test");

        }

        public IActionResult Index()
        {
            _logger.Log(LogLevel.Error, "Navigated to index page");
            _testLogger.Log(LogLevel.Error, "navigated and logged with other logger");
         //  CustomLog4NetLogger.Debug("Manual debug message");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
