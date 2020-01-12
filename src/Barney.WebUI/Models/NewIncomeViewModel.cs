using System;
using System.Collections.Generic;
using System.Linq;
using Barney.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Barney.WebUI.Models
{
    public class NewIncomeViewModel
    {

        public NewIncomeViewModel() { }

        public NewIncomeViewModel(IList<IncomeClassification> incomeClassifications, IList<Employer> employers)
        {
            SetIncomeClassifications(incomeClassifications);
            SetEmployers(employers);
        }

        public short IncomeClassificationId { get; set; }

        public short EmployerId { get; set; }

        public decimal BeforeDeductions { get; set; }

        public decimal AfterDeductions { get; set;  }

        public DateTimeOffset TransactionDate { get; set; }


        public IEnumerable<SelectListItem> IncomeClassifications
        {
            get; private set;

        }

        public IEnumerable<SelectListItem> Employers { get; private set; }

        public void SetIncomeClassifications(IList<IncomeClassification> classifications)
        {
            IncomeClassifications = classifications != null && classifications.Any()
                ? classifications.Select(classification =>
                    new SelectListItem(classification.Name, classification.IncomeClassificationId.ToString())).ToList()
                : new List<SelectListItem>();
        }


        public void SetEmployers(IList<Employer> employers)
        {
            Employers = employers != null && employers.Any()
                ? employers.Select(employer => new SelectListItem(employer.Name, employer.EmployerId.ToString()))
                    .ToList()
                : new List<SelectListItem>();
        }
            
    }
}
