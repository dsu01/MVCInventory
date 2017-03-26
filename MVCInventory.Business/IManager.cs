using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace MVCInventory.Business
{
    public interface IManager<TM, TE> : IManager
        where TM : IModel
        where TE : Entity<int>
    {
        List<TM> Get();
        List<TM> Get(Func<TM, bool> predicate);
        List<TM> GetFiltered(Expression<Func<TE, bool>> predicate);
        List<TM> GetFiltered(params Expression<Func<TE, bool>>[] predicates);
        TM GetById(int id);

        void Delete(int id);
        void Delete(int id, bool forceDelete);
        TM Save(TM model);
        List<ValidationResult> Validate(TM model);
    }

    public interface IManager
    {
    }

    public interface IModel
    {
        int Id { get; set; }

        bool IsNew { get; }
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; }


        public override void Merge(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public abstract class BaseEntity : ICloneable
    {
        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        public abstract void Merge(BaseEntity entity);
    }
}
