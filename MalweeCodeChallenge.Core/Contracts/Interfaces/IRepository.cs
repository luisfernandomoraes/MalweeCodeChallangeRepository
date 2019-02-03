using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MalweeCodeChallenge.Core.Contracts.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        long Count();
        long Count(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);
        TEntity FindByKey(params object[] key);
        void Update(TEntity obj);
        TEntity Add(TEntity obj);
        void AddOrUpdate(TEntity obj);
        void AddRange(List<TEntity> objs);
        void Remove(Expression<Func<TEntity, bool>> predicate);
        void Remove(TEntity entity);
        bool Any(Expression<Func<TEntity, bool>> predicate);
    }
}