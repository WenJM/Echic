using Echic.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Echic.Domain.IRepositories
{
    public interface IRepository<TEntity> where TEntity : AggregateRoot
    {
        int Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);
        int Update(TEntity entity);
        int Update(IEnumerable<TEntity> entities);
        int Delete(TEntity entity);
        int Delete(IEnumerable<TEntity> entities);
        int Delete(Expression<Func<TEntity, bool>> where);

        TEntity GetById(int Id);
        TEntity GetById(long Id);
        TEntity GetById(string Id);
        TEntity Get(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAllLazy();
    }
}
