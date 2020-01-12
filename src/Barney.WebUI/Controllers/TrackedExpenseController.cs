using System.Threading.Tasks;
using Barney.Business.Managers.Interfaces;
using Barney.Domain.Models;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewExpenseViewModel newExpenseViewModel)
        {
            if (ModelState.IsValid)
            {
                var newExpense = new NewExpense(newExpenseViewModel.ExpenseClassificationId, newExpenseViewModel.Description,
                    HttpContext.Request.CurrentUserName(), newExpenseViewModel.IncurredDate, newExpenseViewModel.Amount);

                await _expenseManager.InsertAsync(newExpense);
                return RedirectToAction("Index");
            }
            else
            {
                var expenseClassifications =
                    await _expenseManager.GetExpenseClassificationsAsync().ConfigureAwait(false);
                newExpenseViewModel.SetExpenseClassifications(expenseClassifications);

                return View(newExpenseViewModel);
            }
        }
    }
}