using Barney.Domain.Models;
using Barney.Domain.Repositories;
using Mx.EntityFramework.Contracts;
using Mx.EntityFramework.Repositories;


namespace Barney.Data.Repositories
{
    public class IncomeClassificationRepository : Repository<IncomeClassification>, IIncomeClassificationRepository
    {
        public IncomeClassificationRepository(IEntityContext entityContext) : base(entityContext)
        {
        }
    }
}
