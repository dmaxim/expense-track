using Barney.Domain.Models;
using Barney.Domain.Repositories;
using Mx.EntityFramework.Contracts;
using Mx.EntityFramework.Repositories;


namespace Barney.Data.Repositories
{
    public class ExpenseClassificationRepository : Repository<ExpenseClassification>, IExpenseClassificationRepository
    {
        public ExpenseClassificationRepository(IEntityContext entityContext) : base(entityContext)
        {
        }
    }
}
