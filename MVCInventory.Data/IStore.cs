using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCInventory.Data
{
    public interface IStore<T> 
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Get(params Expression<Func<T, bool>>[] predicates);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate, int count);
        T SingleOrDefault(Expression<Func<T, bool>> predicate, params string[] includes);
        T Add(T entity);
        T Delete(T entity);
        T Delete(T entity, bool forceDelete);
        void Edit(T entity);
        void Save();
    }

    //public abstract class Store<T> : IStore<T>
    //{
    //    protected DbContext Entities;
    //    protected readonly IDbSet<T> DbSet;

    //    public Store(DbContext context)
    //    {
    //        this.Entities = context;
    //        this.DbSet = context.Set<T>();
    //    }

    //    public virtual IEnumerable<T> GetAll()
    //    {
    //        return this.DbSet.AsEnumerable();
    //    }

    //    public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
    //    {
    //        var query = this.DbSet.AsExpandable().Where(predicate);

    //        return query.AsEnumerable();
    //    }

    //    public virtual IEnumerable<T> Get(params Expression<Func<T, bool>>[] predicates)
    //    {
    //        var query = this.DbSet.AsExpandable();
    //        if (predicates.Any())
    //        {
    //            query = predicates.Aggregate(query, (current, predicate) => current.Where(predicate));
    //        }
    //        return query.AsEnumerable();
    //    }

    //    public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate, int count)
    //    {

    //        IEnumerable<T> query = this.DbSet.Where(predicate).Take(count).AsEnumerable();
    //        return query;
    //    }

    //    public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate, params string[] includes)
    //    {
    //        var query = this.DbSet.AsQueryable();
    //        query = includes.Aggregate(query, (current, include) => current.Include(include));
    //        return query.SingleOrDefault(predicate);
    //    }

    //    public virtual T Add(T entity)
    //    {
    //        return this.DbSet.Add(entity);
    //    }

    //    public virtual T Delete(T entity)
    //    {
    //        return Delete(entity, false);
    //    }

    //    public virtual T Delete(T entity, bool forceDelete)
    //    {
    //        var cantDeleteEntity = entity as ICantDeleteIfUsed;
    //        if (cantDeleteEntity != null)
    //        {
    //            if (!cantDeleteEntity.CanDelete())
    //            {
    //                throw new InvalidOperationException("This item cannot be deleted as it is in use.");
    //            }
    //        }
    //        var canSoftDeleteEntity = entity as ICanSoftDelete;
    //        if (canSoftDeleteEntity != null && !forceDelete)
    //        {
    //            canSoftDeleteEntity.IsDeleted = true;
    //            this.Entities.Entry(canSoftDeleteEntity).State = EntityState.Modified;
    //            return entity;

    //        }


    //        return this.DbSet.Remove(entity);
    //    }

    //    public virtual void Edit(T entity)
    //    {
    //        this.Entities.Entry(entity).State = EntityState.Modified;
    //    }

    //    public virtual void Save()
    //    {
    //        this.Entities.SaveChanges();
    //    }
    //}
}
