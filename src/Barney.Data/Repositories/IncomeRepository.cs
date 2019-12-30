using Barney.Domain.Models;
using Barney.Domain.Repositories;
using Mx.EntityFramework.Contracts;
using Mx.EntityFramework.Repositories;

namespace Barney.Data.Repositories
{
    public class IncomeRepository : Repository<Income>, IIncomeRepository
    {
        public IncomeRepository(IEntityContext entityContext) : base(entityContext)
        {
        }
    }
}
