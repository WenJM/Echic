using System;
using System.Collections.Generic;
using System.Text;
using Echic.Domain.Base;
using Echic.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Echic.Domain.UnitOfWork
{
    public class MySqlefUnitOfWork : IMySqlefUnitOfWork
    {
        public IDbContext DBContext { get; set; }

        public MySqlefUnitOfWork(IDbContext dbContext)
        {
            this.DBContext = dbContext;
        }

        public void Created<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            if (this.DBContext.Entry(obj).State == EntityState.Detached)
            {
                this.DBContext.Entry(obj).State = EntityState.Added;
            }

            IsCommitted = false;
        }

        public void Modified<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            if (this.DBContext.Entry(obj).State == EntityState.Detached)
            {
                this.DBContext.Set<TEntity>().Attach(obj);
            }
            this.DBContext.Entry(obj).State = EntityState.Modified;

            IsCommitted = false;
        }

        public void Deleted<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            this.DBContext.Entry(obj).State = EntityState.Deleted;

            IsCommitted = false;
        }

        public bool IsCommitted { get; set; }

        public int Commit()
        {
            if (IsCommitted)
            {
                return 0;
            }
            try
            {
                int result = this.DBContext.SaveChanges();

                IsCommitted = true;

                return result;
            }
            catch (DbUpdateException e)
            {
                throw e;
            }
        }

        public void Rollback()
        {
            IsCommitted = false;
        }

        public void Dispose()
        {
            if (!IsCommitted)
            {
                Commit();
            }
            this.DBContext.Dispose();
        }
    }
}
