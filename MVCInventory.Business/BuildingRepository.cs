using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCInventory.Business.Abstract;
using MVCInventory.Data;
using MVCInventory.Domain;

namespace MVCInventory.Business
{
    public class BuildingRepository : IBuildingRepository 
    {
        private static BuildingRepository repo = new BuildingRepository();
        public Building Add(Building building)
        {
            using (var dbContext = new InventoryContext())
            {
                 dbContext.Buildings.Add(building);
                dbContext.SaveChanges();
                return dbContext.Buildings.FirstOrDefault(x => x.BuildingName == building.BuildingName);
            }
        }

        public Building Update(Building item)
        {
            using (var dbContext = new InventoryContext())
            {
                var existingBuilding = dbContext.Buildings.FirstOrDefault(x => x.Id == item.Id);
                if (existingBuilding != null)
                {
                    existingBuilding.BuildingName = item.BuildingName;
                    existingBuilding.Property = item.Property;
                  
                    dbContext.SaveChanges();

                    return dbContext.Buildings.FirstOrDefault(x => x.Id == item.Id);
                }
                else
                {
                    return null;
                }
            }
        }
        public Building FetchByBuildingId(int Id)
        {
            using (var dbContext = new InventoryContext())
            {
                return dbContext.Buildings.FirstOrDefault(x => x.Id == Id);
            }
        }

        public void DeleteBuilding(int Id)
        {
            using (var dbContext = new InventoryContext())
            {
                var existingBuilding = dbContext.Buildings.FirstOrDefault(x => x.Id == Id);
                if (existingBuilding == null)
                    return;
               dbContext.Buildings.Remove(existingBuilding);
                dbContext.SaveChanges();
            }
        }

        public Building FetchByBuildingName(string name)
        {
            using (var dbContext = new InventoryContext())
            {
                return dbContext.Buildings.FirstOrDefault(x => x.BuildingName == name);
            }
        }

        public int SubmitChanges()
        {
            using (var dbContext = new InventoryContext())
            {
                return dbContext.SaveChanges();
            }
        }

       
        public static IBuildingRepository getRepository()
        {
            return repo;
        }

        public IEnumerable<Building> GetAll()
        {

            try
            {
                using (var dbContext = new InventoryContext())
                {
                    return dbContext.Buildings.ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
    }
}
