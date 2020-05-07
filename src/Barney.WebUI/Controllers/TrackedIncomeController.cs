using System;
using System.Threading.Tasks;
using Barney.Business.Managers.Interfaces;
using Barney.Domain.Models;
using Barney.WebUI.Infrastructure;
using Barney.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Barney.WebUI.Controllers
{
    public class TrackedIncomeController : Controller
    {
        private readonly IIncomeManager _incomeManager;
        private readonly ILogger<TrackedIncomeController> _logger;

        public TrackedIncomeController(IIncomeManager incomeManager, ILogger<TrackedIncomeController> logger)
        {
            _incomeManager = incomeManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            _logger.LogInformation("This should not be logged");
            _logger.LogError("This should be logged");
            var individualIncome = await _incomeManager.GetIndividualIncomeAsync(HttpContext.Request.CurrentUserName()).ConfigureAwait(false);

            return View(new IndividualIncomeViewModel(individualIncome));
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var employers = await _incomeManager.GetEmployersAsync().ConfigureAwait(false);
            var incomeClassifications = await _incomeManager.GetIncomeClassificationsAsync().ConfigureAwait(false);

            return View(new NewIncomeViewModel(incomeClassifications, employers));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewIncomeViewModel newIncomeViewModel)
        {
            if (ModelState.IsValid)
            {
                var newIncome = new NewIncome(newIncomeViewModel.IncomeClassificationId, newIncomeViewModel.EmployerId,
                    newIncomeViewModel.BeforeDeductions,
                    newIncomeViewModel.AfterDeductions, newIncomeViewModel.TransactionDate, HttpContext.Request.CurrentUserName());

                await _incomeManager.InsertAsync(newIncome).ConfigureAwait(false);
                return RedirectToAction("Index");
            }
            else
            {
                var employers = await _incomeManager.GetEmployersAsync().ConfigureAwait(false);
                var incomeClassifications = await _incomeManager.GetIncomeClassificationsAsync().ConfigureAwait(false);

                newIncomeViewModel.SetEmployers(employers);
                newIncomeViewModel.SetIncomeClassifications(incomeClassifications);
                return View(newIncomeViewModel);
            }
            
        }
    }
}