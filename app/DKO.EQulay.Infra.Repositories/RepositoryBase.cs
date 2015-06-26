using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQulay.Infra.Repositories.EF;
using Microsoft.Practices.ServiceLocation;

namespace DKO.EQulay.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public DbContext Context { get; private set; }

        public RepositoryBase()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager>();
            Context = contextManager.Context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public int AddWithReturnId(TEntity entity)
        {
             Context.Set<TEntity>().Add(entity);
            return 0;
        }

        public void Delete(TEntity entity)
        {
            if (entity != null) Context.Set<TEntity>().Remove(entity);
        }

        public void Delete(int idEntity)
        {
            var entity = Get(idEntity);
            Delete(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> @where)
        {
            var entities = Context.Set<TEntity>().Where<TEntity>(where).AsEnumerable();
            foreach (var obj in entities)
                Context.Set<TEntity>().Remove(obj);
        }

        public TEntity Get(int idEntity)
        {
            return Context.Set<TEntity>().Find(idEntity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> @where)
        {
            return Context.Set<TEntity>().Where(where).FirstOrDefault<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> @where)
        {
            return Context.Set<TEntity>().Where(where).ToList();
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
