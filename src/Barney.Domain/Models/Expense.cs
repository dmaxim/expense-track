

using System;

namespace Barney.Domain.Models
{
    public class Expense
    {
        private Expense() { }


        public Expense(int expenseId, byte classificationId, string description, short ownerId,
            DateTimeOffset incurredDate, decimal amount)
        {
            ExpenseId = expenseId;
            ExpenseClassificationId = classificationId;
            Description = description;
            ExpenseOwnerId = ownerId;
            IncurredDate = incurredDate;
            Amount = amount;
        }

        public Expense(NewExpense newExpense, short expenseOwnerId)
        {
            ExpenseClassificationId = newExpense.ExpenseClassificationId;
            Description = newExpense.Description;
            IncurredDate = newExpense.IncurredDate;
            ExpenseOwnerId = expenseOwnerId;
            Amount = newExpense.Amount;
        }
        
        public int ExpenseId { get; }

        public byte ExpenseClassificationId { get; }

        public string Description { get; }

        public short ExpenseOwnerId { get; }

        public decimal Amount { get; }
        public DateTimeOffset IncurredDate { get;  }
        
        public ExpenseClassification Classification { get; }
        
        public ExpenseOwner Owner { get; }
    }
}
