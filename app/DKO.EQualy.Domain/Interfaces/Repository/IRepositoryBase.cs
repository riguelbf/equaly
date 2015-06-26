using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DKO.EQualy.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Delete(int idEntity);

        void Delete(Expression<Func<TEntity, bool>> where);

        TEntity Get(int idEntity);

        TEntity Get(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> GetAll();

        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);

        void Update(TEntity entity);
        
        //IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order);
    }
}