

namespace Barney.Domain.Models
{
    public class IncomeClassification
    {
        private IncomeClassification() { }

        public IncomeClassification(short incomeClassificationId, string name, string description)
        {
            IncomeClassificationId = incomeClassificationId;
            Name = name;
            Description = description;
        }

        public short IncomeClassificationId { get;  }

        public string Name { get;  }

        public string Description { get;  }
    }
}
