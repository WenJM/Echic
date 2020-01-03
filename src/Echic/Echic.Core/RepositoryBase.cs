using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Echic.Core.Data;

namespace Echic.Core
{
    public abstract class RepositoryBase : IRepository
    {
        public IQueryable<TEntity> InitEntities<TEntity>() where TEntity : class
        {
            return DataContext.Set<TEntity>();
        }

        private IDatabaseFactory DBFactory
        {
            get;
            set;
        }

        private BaseDbContext dataContext;

        protected BaseDbContext DataContext
        {
            get { return dataContext ?? (dataContext = DBFactory.Get()); }
        }

        protected RepositoryBase(IDatabaseFactory dbFactory)
        {
            DBFactory = dbFactory;
        }

        public virtual void Add<TEntity>(TEntity entity) where TEntity : class
        {
            var state = dataContext.Entry(entity).State;
            if (state == EntityState.Detached)
            {
                this.DataContext.Entry(entity).State = EntityState.Added;
            }
        }

        public virtual void AddAll<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            foreach (var obj in entities)
            {
                this.Add(obj);
            }
        }

        public virtual void Update<TEntity>(TEntity entity) where TEntity : class
        {
            this.DataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            foreach (TEntity obj in entities)
            {
                this.Update(obj);
            }
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            this.DataContext.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Delete<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class
        {
            IEnumerable<TEntity> entities = this.InitEntities<TEntity>().Where<TEntity>(where).AsEnumerable();
            foreach (var obj in entities)
            {
                this.Delete(obj);
            }
        }

        public virtual void DeleteAll<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            foreach (var obj in entities)
            {
                this.Delete(obj);
            }
        }

        public virtual TEntity GetById<TEntity>(long id) where TEntity : class
        {
            return this.DataContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetById<TEntity>(string id) where TEntity : class
        {
            return this.DataContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return this.InitEntities<TEntity>().AsEnumerable().ToList();
        }

        public virtual IEnumerable<TEntity> GetMany<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class
        {
            return this.InitEntities<TEntity>().Where(where).ToList();
        }

        public TEntity Get<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class
        {
            return this.InitEntities<TEntity>().Where(where).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAllLazy<TEntity>() where TEntity : class
        {
            return this.InitEntities<TEntity>();
        }
    }

    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Entities{ get; set;}

        private IDatabaseFactory DBFactory { get; set;}

        private BaseDbContext dataContext;

        protected BaseDbContext DataContext
        {
            get { return dataContext ?? (dataContext = DBFactory.Get()); }
        }

        protected RepositoryBase(IDatabaseFactory dbFactory)
        {
            DBFactory = dbFactory;
            Entities = DataContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            var state = dataContext.Entry(entity).State;
            if (state == EntityState.Detached)
            {
                dataContext.Entry(entity).State = EntityState.Added;
            }
        }

        public virtual void AddAll(IEnumerable<TEntity> entities)
        {
            foreach (var obj in entities)
            {
                this.Add(obj);
            }
        }

        public virtual void Update(TEntity entity)
        {
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        //新增方法
        public virtual void Update(IEnumerable<TEntity> entities)
        {
            foreach (TEntity obj in entities)
            {
                this.Update(obj);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            dataContext.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> entities = this.Entities.Where<TEntity>(where).AsEnumerable();
            foreach (var obj in entities)
            {
                this.Delete(obj);
            }
        }

        //新增方法
        public virtual void DeleteAll(IEnumerable<TEntity> entities)
        {
            foreach (var obj in entities)
            {
                this.Delete(obj);
            }
        }

        public virtual TEntity GetById(long id)
        {
            return this.DataContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetById(string id)
        {
            return this.DataContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.DataContext.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return this.DataContext.Set<TEntity>().Where(where).ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return this.DataContext.Set<TEntity>().Where(where).FirstOrDefault<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAllLazy()
        {
            return Entities;
        }
    }
}
