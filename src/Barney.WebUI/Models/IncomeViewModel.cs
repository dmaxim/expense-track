

using System;
using Barney.Domain.Models;

namespace Barney.WebUI.Models
{
    public class IncomeViewModel
    {
        public IncomeViewModel(Income income)
        {
            IncomeId = income.IncomeId;
            IncomeDate = income.TransactionDate;
            BeforeDeductions = income.BeforeDeductions;
            AfterDeductions = income.AfterDeductions;
            EmployerName = income.Employer?.Name;
            Classification = income.Classification?.Name;
        }


        public int IncomeId { get;  }

        public DateTimeOffset IncomeDate { get; }

        public decimal BeforeDeductions { get; }

        public decimal AfterDeductions { get;  }

        public string EmployerName { get;  }

        public string Classification { get;  }
    }
}
