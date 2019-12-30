

namespace Barney.Domain.Models
{
    public class ExpenseOwner
    {

        private ExpenseOwner() { }

        public ExpenseOwner(short expenseOwnerId, string ownerUserId, string firstName, string lastName)
        {
            ExpenseOwnerId = expenseOwnerId;
            OwnerUserId = ownerUserId;
            FirstName = firstName;
            LastName = lastName;
        }

        public short ExpenseOwnerId { get;  }

        public string OwnerUserId { get;  }

        public string FirstName { get;  }

        public string LastName { get; }
    }
}
