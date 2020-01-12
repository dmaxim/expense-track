using System;
using System.Collections.Generic;
using System.Linq;
using Barney.Domain.Models;

namespace Barney.WebUI.Models
{
    public class IndividualExpenseViewModel
    {
        public IndividualExpenseViewModel(IEnumerable<Expense> expenses)
        {
            if (expenses == null)
            {
                IndividualExpenses = new List<ExpenseViewModel>();
            }
            else
            {
                IndividualExpenses = expenses.Select(expense => new ExpenseViewModel(expense)).ToList();
            }
            
        }
        
        public IEnumerable<ExpenseViewModel> IndividualExpenses { get; }


        public decimal TotalExpenses
        {
            get { return IndividualExpenses.Sum(expense => expense.Amount); }
        }
    }
}