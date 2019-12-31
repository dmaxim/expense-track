

using System;

namespace Barney.Domain.Models
{
    /// <summary>
    /// Income class used to retrieve and create records in the database.
    ///
    /// NOTE:  The private setters appear to be required for Entity Framework when doing an insert
    /// </summary>
    public class Income
    {
        private Income() { }

        public Income(NewIncome newIncome, short expenseOwnerId)
        {
            IncomeClassificationId = newIncome.IncomeClassificationId;
            EmployerId = newIncome.EmployerId;
            BeforeDeductions = newIncome.BeforeDeductions;
            AfterDeductions = newIncome.AfterDeductions;
            TransactionDate = newIncome.TransactionDate;
            ExpenseOwnerId = expenseOwnerId;

        }
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

        public int IncomeId { get;  private set; }

        public short IncomeClassificationId { get; private set; }

        public short EmployerId { get; private set;  }

        public decimal BeforeDeductions { get; private set; }

        public decimal AfterDeductions { get; private set; }

        public DateTimeOffset TransactionDate { get; private set; }

        public short ExpenseOwnerId { get; private set; }

        public ExpenseOwner Owner { get; private set; }

        public IncomeClassification Classification { get; private set; }

        public Employer Employer { get; private set; }
    }
}
