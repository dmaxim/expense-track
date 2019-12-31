

using System;

namespace Barney.Domain.Models
{
    public class NewIncome
    {
        public NewIncome(short classificationId, short employerId, decimal beforeDeductions, decimal afterDeductions,
            DateTimeOffset transactionDate, string expenseOwnerUserId)
        {
            IncomeClassificationId = classificationId;
            EmployerId = employerId;
            BeforeDeductions = beforeDeductions;
            AfterDeductions = afterDeductions;
            TransactionDate = transactionDate;
            ExpenseOwnerUserId = expenseOwnerUserId;
        }

        public short IncomeClassificationId { get; }

        public short EmployerId { get; }

        public decimal BeforeDeductions { get; }

        public decimal AfterDeductions { get; }

        public DateTimeOffset TransactionDate { get; }

        public string ExpenseOwnerUserId { get; }

        
    }
}
