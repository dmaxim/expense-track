using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barney.Business.Managers.Interfaces;
using Barney.Domain.Models;
using Barney.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Mx.Library.ExceptionHandling;

namespace Barney.Business.Managers
{
    public class ExpenseManager : IExpenseManager
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenseClassificationRepository _expenseClassificationRepository;
        private readonly IExpenseOwnerRepository _expenseOwnerRepository;
        
        public ExpenseManager(IExpenseRepository expenseRepository, IExpenseClassificationRepository expenseClassificationRepository, IExpenseOwnerRepository expenseOwnerRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseClassificationRepository = expenseClassificationRepository;
            _expenseOwnerRepository = expenseOwnerRepository;
        }
        public Task<ICollection<Expense>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Expense>> GetIndividualExpensesAsync(string ownerUserId)
        {
            return await _expenseRepository.GetAll()
                .Include(expense => expense.Classification)
                .Where(expense => expense.Owner.OwnerUserId == ownerUserId)
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<Expense> InsertAsync(NewExpense newExpense)
        {
            var expenseOwner = await _expenseOwnerRepository.GetAll()
                .FirstOrDefaultAsync(owner => owner.OwnerUserId == newExpense.ExpenseOwnerUserId).ConfigureAwait(false);

            if (expenseOwner == null)
            {
                throw new MxNotFoundException($"Expense Owner with id {newExpense.ExpenseOwnerUserId} does not exist");
            }

            var expense = new Expense(newExpense, expenseOwner.ExpenseOwnerId);
            
            _expenseRepository.Insert(expense);
            await _expenseRepository.SaveChangesAsync().ConfigureAwait(false);

            return expense;
        }

        public async Task<IList<ExpenseClassification>> GetExpenseClassificationsAsync()
        {
            return await _expenseClassificationRepository.GetAll().ToListAsync().ConfigureAwait(false);
        }
    }
}