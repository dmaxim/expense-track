
using System.Collections.Generic;
using System.Threading.Tasks;
using Barney.Domain.Models;

namespace Barney.Business.Managers.Interfaces
{
    public interface IIncomeManager
    {
        Task<ICollection<Income>> GetAllAsync();

        Task<ICollection<Income>> GetIndividualIncomeAsync(string ownerUserId);

        Task<Income> InsertAsync(NewIncome newIncome);


        Task<Income> GetAsync(int incomeId);

        void Update(Income income);

        Task<IList<Employer>> GetEmployersAsync();

        Task<IList<IncomeClassification>> GetIncomeClassificationsAsync();
    }
}
