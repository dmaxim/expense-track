using Barney.Domain.Models;
using Barney.Domain.Repositories;
using Mx.EntityFramework.Contracts;
using Mx.EntityFramework.Repositories;


namespace Barney.Data.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(IEntityContext entityContext) : base(entityContext)
        {
        }
    }
}
