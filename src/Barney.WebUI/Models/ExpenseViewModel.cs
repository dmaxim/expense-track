using System;
using Barney.Domain.Models;

namespace Barney.WebUI.Models
{
    public class ExpenseViewModel
    {
        public ExpenseViewModel(Expense expense)
        {
            ExpenseId = expense.ExpenseId;
            IncurredDate = expense.IncurredDate;
            Description = expense.Description;
            ExpenseOwnerId = expense.ExpenseOwnerId;
            Classification = expense.Classification?.Name;
            Amount = expense.Amount;
        }
        
        
        public int ExpenseId { get; }
        
        public DateTimeOffset IncurredDate { get; }
        
        public string Description { get; }

        public short ExpenseOwnerId { get; }
        
        public string Classification { get; }
        
        public decimal Amount { get; }
    }
}