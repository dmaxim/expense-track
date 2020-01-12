using System;

namespace Barney.Domain.Models
{
    public class NewExpense
    {
        public NewExpense(byte classificationId, string description, string expenseOwnerUserId, DateTimeOffset incurredDate, decimal amount)
        {
            ExpenseClassificationId = classificationId;
            Description = description;
            IncurredDate = incurredDate;
            ExpenseOwnerUserId = expenseOwnerUserId;
            Amount = amount;
        }
        
        public byte ExpenseClassificationId { get; }

        public string Description { get; }

        public string ExpenseOwnerUserId { get; }

        public DateTimeOffset IncurredDate { get;  }
        
        public decimal Amount { get; }
    }
}