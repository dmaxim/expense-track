using Barney.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Mx.Library.ExceptionHandling;

namespace Barney.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const int DefaultErrorStatus = 500;
        private const string DefaultErrorMessage = "An unexpected exception occured";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            _logger.Log(LogLevel.Error, "Navigated to index page after clean up");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var currentException = exceptionHandlerFeature?.Error;


            var message = currentException is MxException ? currentException.Message : DefaultErrorMessage;


            return View("StatusMessages/Error", new ErrorViewModel(DefaultErrorStatus, message));
        }
    }
}
