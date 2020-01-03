using Echic.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Echic.Domain.IRepositories
{
    public interface IUnitOfWorkRepositoryContext : IUnitOfWork, IDisposable
    {
        void Created<TEntity>(TEntity obj) where TEntity : AggregateRoot;

        void Modified<TEntity>(TEntity obj) where TEntity : AggregateRoot;

        void Deleted<TEntity>(TEntity obj) where TEntity : AggregateRoot;
    }
}
