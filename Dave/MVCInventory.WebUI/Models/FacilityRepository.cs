using System;
using System.Collections.Generic;
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
                    var list = dbContext.Facilities.ToList();
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
                return dbContext.Facilities.FirstOrDefault(x => x.Id == id);
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
                   // existingFacility.BuildingId = item.BuildingId;

                    dbContext.SaveChanges();

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