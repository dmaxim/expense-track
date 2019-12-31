using System;
using System.Net;
using System.Threading.Tasks;
using Barney.Business.Managers.Interfaces;
using Barney.Domain.Models;
using Barney.WebUI.Infrastructure;
using Barney.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barney.WebUI.Controllers
{
    [Route("income")]
    public class TrackedIncomeController : Controller
    {
        private readonly IIncomeManager _incomeManager;

        public TrackedIncomeController(IIncomeManager incomeManager)
        {
            _incomeManager = incomeManager;
        }

        public IActionResult Index()
        {
            return View();
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
                    newIncomeViewModel.AfterDeductions, DateTimeOffset.Now, HttpContext.Request.CurrentUserName());

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