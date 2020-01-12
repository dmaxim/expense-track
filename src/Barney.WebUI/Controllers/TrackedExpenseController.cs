using System.Threading.Tasks;
using Barney.Business.Managers.Interfaces;
using Barney.WebUI.Infrastructure;
using Barney.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barney.WebUI.Controllers
{
    public class TrackedExpenseController : Controller
    {
        private readonly IExpenseManager _expenseManager;

        public TrackedExpenseController(IExpenseManager expenseManager)
        {
            _expenseManager = expenseManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var individualExpenses = await _expenseManager
                .GetIndividualExpensesAsync(HttpContext.Request.CurrentUserName()).ConfigureAwait(false);

            return View(new IndividualExpenseViewModel(individualExpenses));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var expenseClassifications = await _expenseManager.GetExpenseClassificationsAsync().ConfigureAwait(false);
            return View(new NewExpenseViewModel(expenseClassifications));
        }
        
    }
}