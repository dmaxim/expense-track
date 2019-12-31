using System.Collections.Generic;
using System.Threading.Tasks;
using Barney.Business.Managers.Interfaces;
using Barney.Domain.Models;
using Barney.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Barney.Business.Managers
{
    public class IncomeManager : IIncomeManager
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly IIncomeClassificationRepository _incomeClassificationRepository;


        public IncomeManager(IIncomeRepository incomeRepository, IEmployerRepository employerRepository, IIncomeClassificationRepository incomeClassificationRepository)
        {
            _incomeRepository = incomeRepository;
            _employerRepository = employerRepository;
            _incomeClassificationRepository = incomeClassificationRepository;
        }
        public Task<ICollection<Income>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Income> InsertAsync(NewIncome newIncome)
        {
            var income = new Income(newIncome);
            
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
