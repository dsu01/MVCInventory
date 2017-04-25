using System;
using System.Collections.Generic;
using AutoMapper;
using System.Data.Entity;
using System.Linq;
using MVCInventory.Business.Models;
using MVCInventory.Data;
using MVCInventory.Domain;

namespace MVCInventory.Business
{
    public interface IFacilityManager : IDisposable
    {
        List<FacilityModel> GetAll();
        // repository pattern, keep a degree of separation between data model entities and the storage
        // and retrieval logic. 
        //without saying how and where the data is stored
        FacilityModel Add(FacilityModel item);
        FacilityModel GetById(Guid id);
        bool Update(FacilityModel facility);
        void Delete(Guid id);
    }

    public class FacilityManager : IFacilityManager
    {
        //private readonly ILogService _logService;

        private InventoryContext dbContext = new InventoryContext();
        private bool _isDisposed;
        //dbContext.Configuration.LazyLoadingEnabled = false;

        public FacilityModel Add(FacilityModel item)
        {
            using (dbContext)
            {
                var upd = Mapper.Map<Facility>(item);
                dbContext.Facilities.Add(upd);
                dbContext.SaveChanges();
                var res = dbContext.Facilities.FirstOrDefault(x => x.FacilityName == upd.FacilityName);
                var result = Mapper.Map<FacilityModel>(res);

                return result;
            }
        }

        public bool Update(FacilityModel item)
        {
            using (dbContext)
            {
                var existingFacility = dbContext.Facilities.FirstOrDefault(x => x.Id == item.Id);
                if (existingFacility != null)
                {
                    existingFacility.FacilityName = item.FacilityName;
                    existingFacility.FacilityGroup = item.FacilityGroup;

                    try
                    {
                        return dbContext.SaveChanges() > 0;
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting
                                // the current instance as InnerException
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }
                 
                }
                else
                {
                    return false;
                }
            }
        }
        public FacilityModel GetById(Guid Id)
        {
            using (dbContext)
            {
                var res = dbContext.Facilities.Where(x => x.Id == Id)
                    .Include(x => x.Building)
                    .FirstOrDefault();
                var result = Mapper.Map<FacilityModel>(res);

                return result;
            }
        }

        public void Delete(Guid Id)
        {
            using (dbContext)
            {
                var existingFacility = dbContext.Facilities.FirstOrDefault(x => x.Id == Id);
                if (existingFacility == null)
                    return;
                dbContext.Facilities.Remove(existingFacility);
                dbContext.SaveChanges();
            }
        }

      
        public List<FacilityModel> GetAll()
        {
            using (dbContext)
            {
                var list = dbContext.Facilities
                    .Include(x => x.Building)
                    .ToList();

             
                var result = Mapper.Map<List<FacilityModel>>(list);

                return result;
              
            }
        }

        public void Dispose()
        {
            if (this._isDisposed == false)
            {
                this.dbContext.Dispose();
                this._isDisposed = true;
            }
        }
    }
}
