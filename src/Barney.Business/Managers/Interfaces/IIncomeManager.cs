
using System.Collections.Generic;
using Barney.Domain.Models;

namespace Barney.Business.Managers.Interfaces
{
    public interface IIncomeManager
    {
        ICollection<Income> GetAll();

        Income Insert(NewIncome newIncome);


        Income Get(int incomeId);

        void Update(Income income);
    }
}
