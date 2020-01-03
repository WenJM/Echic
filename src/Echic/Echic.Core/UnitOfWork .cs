using System;
using System.Collections.Generic;
using System.Text;
using Echic.Core.Data;

namespace Echic.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory DBFactory;

        private BaseDbContext dataContext;

        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.DBFactory = dbFactory;
        }

        protected BaseDbContext DataContext
        {
            get { return dataContext ?? (dataContext = DBFactory.Get()); }
        }

        public void Commit()
        {
            DataContext.SaveChanges();
        }

        public void CommitAsync()
        {
            DataContext.SaveChangesAsync();
        }

    }
}
