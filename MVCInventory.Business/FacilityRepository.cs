using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MVCInventory.Business.Abstract;
using MVCInventory.Data;
using MVCInventory.Domain;

namespace MVCInventory.Business
{
   public class FacilityRepository : IFacilityRepository
    {
        private static FacilityRepository repo = new FacilityRepository();
        public Facility Add(Facility item)
        {
            using (var dbContext = new InventoryContext())
            {
                dbContext.Facilities.Add(item);
                dbContext.SaveChanges();
                return dbContext.Facilities.FirstOrDefault(x => x.FacilityName == item.FacilityName);
            }
        }

        public Facility Update(Facility item)
        {
            using (var dbContext = new InventoryContext())
            {
                var existingFacility = dbContext.Facilities.FirstOrDefault(x => x.Id == item.Id);
                if (existingFacility != null)
                {
                    existingFacility.FacilityName = item.FacilityName;
                    existingFacility.FacilityGroup = item.FacilityGroup;

                    dbContext.SaveChanges();

                    return dbContext.Facilities.FirstOrDefault(x => x.Id == item.Id);
                }
                else
                {
                    return null;
                }
            }
        }
        public Facility FetchByFacilityId(Guid Id)
        {
            using (var dbContext = new InventoryContext())
            {
                return dbContext.Facilities.Where(x => x.Id== Id)
                    .Include(x => x.Building)
                    .FirstOrDefault();
            }
        }

        public void DeleteFacility(Guid Id)
        {
            using (var dbContext = new InventoryContext())
            {
                var existingFacility = dbContext.Facilities.FirstOrDefault(x => x.Id == Id);
                if (existingFacility == null)
                    return;
                dbContext.Facilities.Remove(existingFacility);
                dbContext.SaveChanges();
            }
        }

        public Facility FetchByFacilityName(string name)
        {
            using (var dbContext = new InventoryContext())
            {
                return dbContext.Facilities.FirstOrDefault(x => x.FacilityName == name);
            }
        }

        public int SubmitChanges()
        {
            using (var dbContext = new InventoryContext())
            {
                return dbContext.SaveChanges();
            }
        }


        public static IFacilityRepository getRepository()
        {
            return repo;
        }

        public IEnumerable<Facility> GetAll()
        {
            using (var dbContext = new InventoryContext())
            {
                var list = dbContext.Facilities
                    .Include(x => x.Building)
                    .Include(x=>x.FacilityAttachments).ToList();

                return list;
            }
        }
    }
}
