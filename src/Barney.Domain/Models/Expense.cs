

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
        
        public int ExpenseId { get; private set; }

        public byte ExpenseClassificationId { get; private set; }

        public string Description { get; private set; }

        public short ExpenseOwnerId { get; private set; }

        public decimal Amount { get; private set; }
        public DateTimeOffset IncurredDate { get; private set; }
        
        public ExpenseClassification ExpenseClassification { get; private set; }
        
        public ExpenseOwner ExpenseOwner { get; private set; }
    }
}
