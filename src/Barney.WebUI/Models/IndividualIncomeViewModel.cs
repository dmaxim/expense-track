
using System.Collections.Generic;
using System.Linq;
using Barney.Domain.Models;

namespace Barney.WebUI.Models
{
    public class IndividualIncomeViewModel
    {

        public IndividualIncomeViewModel(IEnumerable<Income> income)
        {
            if (income == null)
            {
                IndividualIncome = new List<IncomeViewModel>();
            }
            else
            {
                IndividualIncome = income.Select(inc => new IncomeViewModel(inc)).ToList();
            }
        }
        public IEnumerable<IncomeViewModel> IndividualIncome { get; }

        public decimal TotalIncomeBeforeDeductions
        {
            get { return IndividualIncome.Sum(income => income.BeforeDeductions); }
        }


        public decimal TotalIncomeAfterDeductions
        {
            get { return IndividualIncome.Sum(income => income.AfterDeductions); }
        }
    }
}
