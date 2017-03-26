using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using System.Data.Entity;

namespace MVCInventory.Business
{
    //public abstract class Manager<TM, TE> : IManager<TM, TE>
    //        where TM : IModel
    //        where TE : Entity<int>
    //{
        //protected DbContext Entities;
        //public Manager(IStore<TE> store)
        //{
        //    this.Store = store;
        //}

        //private List<ValidationResult> ValidateModel(object model)
        //{
        //    var context = new ValidationContext(model, serviceProvider: null, items: null);
        //    var results = new List<ValidationResult>();
        //    Validator.TryValidateObject(
        //        model, context, results,
        //        validateAllProperties: true
        //    );

        //    return results;
        //}

        //public virtual List<TM> Get()
        //{
        //    var records = this.Store.GetAll();
        //    return Mapper.Map<IEnumerable<TE>, List<TM>>(records);
        //}

        //public virtual List<TM> Get(Func<TM, bool> predicate)
        //{

        //    var records = this.Store.GetAll();
        //    var model = Mapper.Map<IEnumerable<TE>, List<TM>>(records).Where(predicate);
        //    return model.Any() ? model.ToList() : new List<TM>();
        //}

        //public List<TM> GetFiltered(Expression<Func<TE, bool>> predicate)
        //{
        //    var records = this.Store.Get(predicate);
        //    return Mapper.Map<IEnumerable<TE>, List<TM>>(records);
        //}

        //public List<TM> GetFiltered(params Expression<Func<TE, bool>>[] predicates)
        //{
        //    var records = this.Store.Get(predicates);
        //    return Mapper.Map<IEnumerable<TE>, List<TM>>(records);
        //}

        //public virtual TM GetById(int id)
        //{
        //    TE record = null;
        //    if (typeof(AuditableEntity<int>).IsAssignableFrom(typeof(TE)))
        //    {
        //        record = this.Store.SingleOrDefault(e => e.Id == id, "CreatedBy", "UpdatedBy");
        //    }
        //    else
        //    {
        //        record = this.Store.SingleOrDefault(e => e.Id == id);
        //    }
        //    var model = Mapper.Map<TE, TM>(record);

        //    return model;
        //}

        //public virtual void Delete(int id)
        //{
        //    this.Delete(id, false);
        //}

        //public virtual void Delete(int id, bool forceDelete)
        //{
        //    var record = this.Store.SingleOrDefault(e => e.Id == id);
        //    if (record != null)
        //    {
        //        this.Store.Delete(record, forceDelete);
        //        this.Store.Save();
        //    }
        //    else
        //    {
        //        throw new Exception("Record not found.");
        //    }
        //}

        //public virtual TM Save(TM model)
        //{
        //    TE record = null;
        //    if (model.IsNew)
        //    {
        //        record = SaveNew(model);
        //    }
        //    else
        //    {
        //        record = this.Store.SingleOrDefault(e => e.Id == model.Id);
        //        if (record == null)
        //        {
        //            throw new Exception("Record not found.");
        //        }
        //        record = SaveExisting(model, record);
        //    }

        //    this.Store.Save();

        //    var updatedRecord = this.Store.SingleOrDefault(e => e.Id == record.Id);

        //    var result = Mapper.Map<TM>(updatedRecord);

        //    return result;
        //}

        //private TE SaveExisting(TM model, TE record)
        //{
        //    record = MapEntity(model, record);
        //    this.Store.Edit(record);
        //    return record;
        //}

        //protected virtual TE MapEntity(TM model, TE record)
        //{
        //    var mapped = Mapper.Map<TE>(model);
        //    if (record == null)
        //    {
        //        record = mapped;
        //    }
        //    else
        //    {
        //        record.Merge(mapped);
        //    }

        //    ClearAuditUsers(record);

        //    return record;
        //}

        //private TE SaveNew(TM model)
        //{
        //    var record = MapEntity(model, null);
        //    record = this.Store.Add(record);
        //    return record;
        //}

        //private void ClearAuditUsers(TE record)
        //{
        //    var auditable = record as AuditableEntity<int>;
        //    if (auditable != null)
        //    {
        //        auditable.CreatedBy = null;
        //        auditable.UpdatedBy = null;
        //    }
        //}

        //public virtual List<ValidationResult> Validate(TM model)
        //{
        //    return ValidateModel(model);
        //}

    }

    //public interface IManager<TM, TE>
    //{
    //    int Id { get; set; }
    //    bool IsNew { get; }

    //    List<TM> Get();
    //    List<TM> Get(Func<TM, bool> predicate);
    //    //List<TM> GetFiltered(Expression<Func<TE, bool>> predicate);
    //    //List<TM> GetFiltered(params Expression<Func<TE, bool>>[] predicates);
    //    TM GetById(int id);

    //    void Delete(int id);
    //    void Delete(int id, bool forceDelete);
    //    TM Save(TM model);
      
    //}
//}
