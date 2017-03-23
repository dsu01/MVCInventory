using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MVCInventory.Data;
using MVCInventory.Domain;

namespace MVCInventory.WebUI.Models
{
    public interface IBuildingRepository
    {
        IEnumerable<Building> GetAll();

        Building Get(int id);

        Building Add(Building item);

        void Remove(int id);

        bool Update(Building item);
    }


    public class BuildingRepository : IBuildingRepository
    {
        private static BuildingRepository repo = new BuildingRepository();
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
                    var list = dbContext.Buildings.ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Building Get(int id)
        {
            using (var dbContext = new InventoryContext())
            {
                return dbContext.Buildings.FirstOrDefault(x => x.Id == id);
            }
        }

        public Building Add(Building item)
        {
            using (var dbContext = new InventoryContext())
            {
                dbContext.Buildings.Add(item);

                dbContext.SaveChanges();

                return dbContext.Buildings.FirstOrDefault(x => x.Id == item.Id);
            }
        }

        public void Remove(int id)
        {
            using (var dbContext = new InventoryContext())
            {
                var existingBuilding = dbContext.Buildings.FirstOrDefault(x => x.Id == id);

                if (existingBuilding == null)
                    return;

                dbContext.Buildings.Remove(existingBuilding);

                dbContext.SaveChanges();
            }
        }

        public bool Update(Building item)
        {
            using (var dbContext = new InventoryContext())
            {
                var existingBuilding = dbContext.Buildings.FirstOrDefault(x => x.Id == item.Id);

                if (existingBuilding != null)
                {
                    existingBuilding.BuildingName = item.BuildingName;
                    existingBuilding.Property = item.Property;
                    existingBuilding.IsActive = item.IsActive;

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

