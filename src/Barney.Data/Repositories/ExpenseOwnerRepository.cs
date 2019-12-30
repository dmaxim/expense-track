using Barney.Domain.Models;
using Barney.Domain.Repositories;
using Mx.EntityFramework.Contracts;
using Mx.EntityFramework.Repositories;


namespace Barney.Data.Repositories
{
    public class ExpenseOwnerRepository : Repository<ExpenseOwner>, IExpenseOwnerRepository
    {
        public ExpenseOwnerRepository(IEntityContext entityContext) : base(entityContext)
        {
        }
    }
}
