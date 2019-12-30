using System.Collections.Generic;
using Barney.Business.Managers.Interfaces;
using Barney.Domain.Models;
using Barney.Domain.Repositories;

namespace Barney.Business.Managers
{
    public class IncomeManager : IIncomeManager
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeManager(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }
        public ICollection<Income> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Income Insert(NewIncome newIncome)
        {
            throw new System.NotImplementedException();
        }

        public Income Get(int incomeId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Income income)
        {
            throw new System.NotImplementedException();
        }
    }
}
