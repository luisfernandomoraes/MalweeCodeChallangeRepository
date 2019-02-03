using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using MalweeCodeChallenge.Core.Contracts.Interfaces;

namespace MalweeCodeChallenge.Core.Infra.EntityFramework
{
    public class Repository<TEntity> : IDisposable,
		IRepository<TEntity> where TEntity : class, IEntity
	{
		public readonly DbContext Context;

		public Repository(DbContext context)
		{
		    this.Context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public void Dispose()
		{
			Context.Dispose();
		}

		public TEntity Add(TEntity obj)
		{
			var local = Context.Set<TEntity>();

			var newObject = local.Add(obj);
			Context.SaveChanges();
			return newObject;
		}
        public void AddOrUpdate(TEntity obj)
        {
            var local = Context.Set<TEntity>();

            local.AddOrUpdate(obj);
            Context.SaveChanges();
         
        }

		public void AddRange(List<TEntity> entities)
		{
			if (entities.Count <= 0) return;
			var local = Context.Set<TEntity>();
			local.AddRange(entities);
			Context.SaveChanges();
		}

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Any(predicate);
        }

		public long Count()
		{
			return Context.Set<TEntity>().Count();
		}

        public long Count(Expression<Func<TEntity, bool>> predicate)
        {            
            return Context.Set<TEntity>().Count(predicate);
        }

		public TEntity FindByKey(params object[] key)
		{
			return Context.Set<TEntity>().Find(key);
		}

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }        

		public IQueryable<TEntity> GetAll()
		{
			return Context.Set<TEntity>();
		}

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            Context.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => Context.Set<TEntity>().Remove(del));
        }

		public void Remove(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);
		}

		public void Update(TEntity obj)
		{
			var local = Context.Set<TEntity>().Local.FirstOrDefault(f => f.IdDbKey == obj.IdDbKey);

			if (local != null)
			{
				Context.Entry(local).State = EntityState.Detached;
			}
			Context.Set<TEntity>().Attach(obj);
			Context.Entry(obj).State = EntityState.Modified;
		}
	}
}