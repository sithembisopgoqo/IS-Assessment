using System;
using System.Collections.Generic;

namespace ISBank_Assessment.DL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private InteractiveSolutionsBankEntities context;
        private Dictionary<Type, object> repositories;
        private bool disposed = false;

        public UnitOfWork(IDbContextFactory contextFactory)
        {
            context = contextFactory.DbContext;
        }

        public GenericRepository<TEntity> GetRepository<TEntity>()
         where TEntity : class
        {
            if (this.repositories == null)
            {
                this.repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);

            if (!this.repositories.ContainsKey(type))
            {
                this.repositories[type] = new GenericRepository<TEntity>(this.context);
            }

            return (GenericRepository<TEntity>)this.repositories[type];

        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
    }
}
