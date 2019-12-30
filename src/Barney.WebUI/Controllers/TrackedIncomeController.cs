using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Barney.WebUI.Controllers
{
    [Route("income")]
    public class TrackedIncomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}