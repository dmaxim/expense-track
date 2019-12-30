using Barney.Domain.Models;
using Barney.Domain.Repositories;
using Mx.EntityFramework.Contracts;
using Mx.EntityFramework.Repositories;

namespace Barney.Data.Repositories
{
    public class EmployerRepository : Repository<Employer>, IEmployerRepository
    {
        public EmployerRepository(IEntityContext entityContext) : base(entityContext)
        {
        }
    }
}
