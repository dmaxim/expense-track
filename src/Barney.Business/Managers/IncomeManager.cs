using System.Collections.Generic;
using System.Threading.Tasks;
using Barney.Business.Managers.Interfaces;
using Barney.Domain.Models;
using Barney.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Mx.Library.ExceptionHandling;

namespace Barney.Business.Managers
{
    public class IncomeManager : IIncomeManager
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly IIncomeClassificationRepository _incomeClassificationRepository;
        private readonly IExpenseOwnerRepository _expenseOwnerRepository;


        public IncomeManager(IIncomeRepository incomeRepository, IEmployerRepository employerRepository, IIncomeClassificationRepository incomeClassificationRepository, 
            IExpenseOwnerRepository expenseOwnerRepository)
        {
            _incomeRepository = incomeRepository;
            _employerRepository = employerRepository;
            _incomeClassificationRepository = incomeClassificationRepository;
            _expenseOwnerRepository = expenseOwnerRepository;
        }
        public Task<ICollection<Income>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Income> InsertAsync(NewIncome newIncome)
        {

            var expenseOwner = await _expenseOwnerRepository.GetAll()
                .FirstOrDefaultAsync(owner => owner.OwnerUserId == newIncome.ExpenseOwnerUserId).ConfigureAwait(false);

            if (expenseOwner == null)
            {
                throw new MxNotFoundException($"Expense Owner with id {newIncome.ExpenseOwnerUserId} does not exist");
            }

            var income = new Income(newIncome, expenseOwner.ExpenseOwnerId);
            
            _incomeRepository.Insert(income);
            await _incomeRepository.SaveChangesAsync().ConfigureAwait(false);

            return income;


        }

        public Task<Income> GetAsync(int incomeId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Income income)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Employer>> GetEmployersAsync()
        {
            return await _employerRepository.GetAll().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IList<IncomeClassification>> GetIncomeClassificationsAsync()
        {
            return await _incomeClassificationRepository.GetAll().ToListAsync().ConfigureAwait(false);
        }
    }
}
