using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Echic.Core
{
    public interface IRepository
    {
        IQueryable<TEntity> InitEntities<TEntity>() where TEntity : class;

        void Add<TEntity>(TEntity entity) where TEntity : class;
        void AddAll<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class;
        void DeleteAll<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        TEntity GetById<TEntity>(long Id) where TEntity : class;
        TEntity GetById<TEntity>(string Id) where TEntity : class;
        TEntity Get<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
        IEnumerable<TEntity> GetMany<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class;
        IEnumerable<TEntity> GetAllLazy<TEntity>() where TEntity : class;
    }

    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Entities { get; set; }

        void Add(TEntity entity);
        void AddAll(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        void DeleteAll(IEnumerable<TEntity> entities);

        TEntity GetById(long Id);
        TEntity GetById(string Id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAllLazy();
    }
}
