using System.Collections.Generic;
using System.Threading.Tasks;
using Barney.Domain.Models;

namespace Barney.Business.Managers.Interfaces
{
    public interface IExpenseManager
    {
        Task<ICollection<Expense>> GetAllAsync();

        Task<ICollection<Expense>> GetIndividualExpensesAsync(string ownerUserId);

        Task<Expense> InsertAsync(NewExpense newExpense);
        
        Task<IList<ExpenseClassification>> GetExpenseClassificationsAsync();

    }
}