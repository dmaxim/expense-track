using System;
using System.Collections.Generic;
using System.Linq;
using Barney.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Barney.WebUI.Models
{
    public class NewExpenseViewModel
    {
        public NewExpenseViewModel()
        {
            
        }

        public NewExpenseViewModel(IList<ExpenseClassification> expenseClassifications)
        {
            SetExpenseClassifications(expenseClassifications);
        }
        public byte ExpenseClassificationId { get; set; }

        public string Description { get; set; }

        public string ExpenseOwnerUserId { get; set; }

        public DateTimeOffset IncurredDate { get; set; }
        
        public decimal Amount { get; set; }

        public IEnumerable<SelectListItem> ExpenseClassifications { get; private set; }

        public void SetExpenseClassifications(IList<ExpenseClassification> classifications)
        {
            ExpenseClassifications = classifications != null && classifications.Any()
                ? classifications.Select(classification =>
                    new SelectListItem(classification.Name, classification.ExpenseClassificationId.ToString())).ToList()
                : new List<SelectListItem>();
        }
        
    }
}