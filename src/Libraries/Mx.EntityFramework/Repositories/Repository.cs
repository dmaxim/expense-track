using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Mx.EntityFramework.Contracts;

namespace Mx.EntityFramework.Repositories
{
	public abstract class Repository<TEntity> : RepositoryReadOnly<TEntity>, IRepository<TEntity> where TEntity : class
	{


		protected Repository(IEntityContext entityContext) : base(entityContext)
		{

		}

		public virtual void Insert(TEntity entity)
		{
			Context.Set<TEntity>().Add(entity);

		}


		public virtual void Update(TEntity entity)
		{
			if (!Exists(entity))
			{
				Context.Set<TEntity>().Attach(entity);
			}
			Context.Entry(entity).State = EntityState.Modified;

		}

		public virtual void Delete(TEntity entity)
		{
			if (!Exists(entity))
			{
				Context.Set<TEntity>().Attach(entity);
			}

			Context.Set<TEntity>().Remove(entity);

		}


		public virtual void SaveChanges()
		{
			try
			{
				Context.SaveChanges();
			}
			catch (RetryLimitExceededException)
			{
				// TODO:  Determine how to best handle this - The EntityContextConfiguration SQLAzureExecutionStrategy will automatically retry operations
				// http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/connection-resiliency-and-command-interception-with-the-entity-framework-in-an-asp-net-mvc-application
				// https://msdn.microsoft.com/en-us/data/dn45683 
				throw;
			}
		}

        public async Task SaveChangesAsync()
        {
			try
			{
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (RetryLimitExceededException)
            {
                // TODO:  Determine how to best handle this - The EntityContextConfiguration SQLAzureExecutionStrategy will automatically retry operations
                // http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/connection-resiliency-and-command-interception-with-the-entity-framework-in-an-asp-net-mvc-application
                // https://msdn.microsoft.com/en-us/data/dn45683 
                throw;
            }
		}


        private bool Exists(TEntity entity) 
		{
			return Context.Set<TEntity>().Local.Any(attachedEntity => attachedEntity == entity);
		}
	}
}
