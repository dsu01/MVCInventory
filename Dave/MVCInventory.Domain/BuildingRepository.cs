using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCInventory.Domain.Interface;
using Unity.Mvc5;


namespace MVCInventory.Domain
{
    //public class BuildingRepository : IBuildingRepository<Building, int>
    //{
    //    [Dependency]
    //    InventoryContext dbContext = new InventoryContext();
    //    //Using the [Dependency] attribute means that the context property of the type ApplicationEntities is target for Dependency injection in the current type. 
    //    //When the Unity Container instantiates, the property types marked with [Dependency] is instantiated and injected.
    //    public IEnumerable<Building> GetAll()
    //    {
    //            return dbContext.Buildings.ToList();
           
    //    }

    //    public Building Get(Guid id)
    //    {
          
    //        return dbContext.Buildings.FirstOrDefault(x => x.Id == id);
           
    //    }

    //    public Building Add(Facility item)
    //    {
         
          
    //            dbContext.Buildings.Add(item);

    //            dbContext.SaveChanges();

    //            return dbContext.Buildings.FirstOrDefault(x => x.Id == item.Id);
           
    //    }

    //    public void Remove(Guid id)
    //    {
        
    //            var existingBuilding = dbContext.Buildings.FirstOrDefault(x => x.Id == id);

    //            if (existingBuilding == null)
    //                return;

    //            dbContext.Buildings.Remove(existingBuilding);

    //            dbContext.SaveChanges();
            
    //    }


    //}
}
