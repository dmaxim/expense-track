

using System;

namespace Barney.Domain.Models
{
    public class Income
    {
        private Income() { }

        public Income(int incomeId, short classificationId, short employerId, decimal beforeDeductions,
            decimal afterDeductions,DateTimeOffset transactionDate, short expenseOwnerId)
        {
            IncomeId = incomeId;
            IncomeClassificationId = classificationId;
            EmployerId = employerId;
            BeforeDeductions = beforeDeductions;
            AfterDeductions = afterDeductions;
            TransactionDate = transactionDate;
            ExpenseOwnerId = expenseOwnerId;
        }

        public int IncomeId { get; }

        public short IncomeClassificationId { get; }

        public short EmployerId { get;  }

        public decimal BeforeDeductions { get; }

        public decimal AfterDeductions { get; }

        public DateTimeOffset TransactionDate { get; }

        public short ExpenseOwnerId { get; }
    }
}
