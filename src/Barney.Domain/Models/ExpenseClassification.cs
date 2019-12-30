

namespace Barney.Domain.Models
{
    public class ExpenseClassification
    {
        private ExpenseClassification()
        {
        }


        public ExpenseClassification(byte expenseClassificationId, string name)
        {
            ExpenseClassificationId = expenseClassificationId;
            Name = name;
        }

    public byte ExpenseClassificationId { get; }

        public string Name { get;  }
    }
}
