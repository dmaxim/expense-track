

namespace Barney.Domain.Models
{
    public class Employer
    {
        private Employer() { }

        public Employer(short employerId, string name, string description)
        {
            EmployerId = employerId;
            Name = name;
            Description = description;
        }
        
        public short EmployerId { get; }

        public string Name { get; }

        public string Description { get;  }
    }
}
