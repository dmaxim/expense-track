

using System;

namespace Barney.Domain.Models
{
    public class Expense
    {
        private Expense() { }


        public Expense(int expenseId, byte classificationId, string description, short ownerId,
            DateTimeOffset incurredDate)
        {
            ExpenseId = expenseId;
            ExpenseClassificationId = classificationId;
            Description = description;
            ExpenseOwnerId = ownerId;
            IncurredDate = incurredDate;
        }
        public int ExpenseId { get; }

        public byte ExpenseClassificationId { get; }

        public string Description { get; }

        public short ExpenseOwnerId { get; }

        public DateTimeOffset IncurredDate { get;  }
    }
}
