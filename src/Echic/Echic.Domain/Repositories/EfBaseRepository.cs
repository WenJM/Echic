using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Echic.Domain.Base;
using Echic.Domain.UnitOfWork;
using Echic.Domain.IRepositories;

namespace Echic.Domain.Repositories
{
    public class EfBaseRepository<TEntity> : IRepository<TEntity> where TEntity : AggregateRoot
    {
        public IMySqlefUnitOfWork UnitOfWork { get; set; }

        public int Add(TEntity entity)
        {
            this.UnitOfWork.Created(entity);
            return this.UnitOfWork.Commit();
        }

        public int AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var obj in entities)
            {
                UnitOfWork.Created(obj);
            }
            return UnitOfWork.Commit();
        }
        
        public int Update(TEntity entity)
        {
            this.UnitOfWork.Modified(entity);
            return this.UnitOfWork.Commit();
        }

        public int Update(IEnumerable<TEntity> entities)
        {
            foreach (var obj in entities)
            {
                UnitOfWork.Modified(obj);
            }
            return UnitOfWork.Commit();
        }

        public int Delete(TEntity entity)
        {
            this.UnitOfWork.Deleted(entity);
            return this.UnitOfWork.Commit();
        }

        public int Delete(IEnumerable<TEntity> entities)
        {
            foreach (var obj in entities)
            {
                UnitOfWork.Deleted(obj);
            }
            return UnitOfWork.Commit();
        }

        public int Delete(Expression<Func<TEntity, bool>> where)
        {
            var entities = this.GetMany(where);
            foreach (var obj in entities)
            {
                UnitOfWork.Deleted(obj);
            }
            return UnitOfWork.Commit();
        }

        public TEntity GetById(int Id)
        {
            return this.UnitOfWork.DBContext.Set<TEntity>().Find(Id);
        }

        public TEntity GetById(long Id)
        {
            return this.UnitOfWork.DBContext.Set<TEntity>().Find(Id);
        }

        public TEntity GetById(string Id)
        {
            return this.UnitOfWork.DBContext.Set<TEntity>().Find(Id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return this.UnitOfWork.DBContext.Set<TEntity>().Where(where).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return this.UnitOfWork.DBContext.Set<TEntity>().Where(where).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.UnitOfWork.DBContext.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllLazy()
        {
            return this.UnitOfWork.DBContext.Set<TEntity>();
        }
    }
}
