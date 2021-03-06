﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MVCInventory.Data;
using MVCInventory.Domain;

namespace MVCInventory.WebUI.Models
{
    public interface IFacilityRepository
    {
        IEnumerable<Facility> GetAll();

        Facility Get(Guid id);

        Facility Add(Facility item);

        void Remove(Guid id);

        bool Update(Facility item);
    }


    public class FacilityRepository : IFacilityRepository
    {
        private static FacilityRepository repo = new FacilityRepository();
        public static IFacilityRepository getRepository()
        {
            return repo;
        }

        public IEnumerable<Facility> GetAll()
        {
            try
            {
                using (var dbContext = new InventoryContext())
                {
                    var list = dbContext.Facilities.Include(x => x.Building).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Facility Get(Guid id)
        {
            using (var dbContext = new InventoryContext())
            {
                return dbContext.Facilities
                        .Where(x => x.Id == id)
                        .Include(x => x.Building)
                        .FirstOrDefault();
            }
        }

        public Facility Add(Facility item)
        {
            //if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();
            if (item.BuildingId == 0)
                item.BuildingId = 1;

            using (var dbContext = new InventoryContext())
            {
                dbContext.Facilities.Add(item);

                dbContext.SaveChanges();

                return dbContext.Facilities.FirstOrDefault(x => x.Id == item.Id);
            }
        }

        public void Remove(Guid id)
        {
            using (var dbContext = new InventoryContext())
            {
                var existingFacility = dbContext.Facilities.FirstOrDefault(x => x.Id == id);

                if (existingFacility == null)
                    return;

                dbContext.Facilities.Remove(existingFacility);

                dbContext.SaveChanges();
            }
        }

        public bool Update(Facility item)
        {
            using (var dbContext = new InventoryContext())
            {
                var existingFacility = dbContext.Facilities.FirstOrDefault(x => x.Id == item.Id);

                if (existingFacility != null)
                {
                    existingFacility.FacilityName = item.FacilityName;
                    existingFacility.FacilityGroup = item.FacilityGroup;
                    existingFacility.BuildingId = item.BuildingId;

                   
                    try
                    {
                        dbContext.SaveChanges();
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
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}