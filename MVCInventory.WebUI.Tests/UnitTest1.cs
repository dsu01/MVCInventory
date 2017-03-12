using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MVCInventory.Domain;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MVCInventory.WebUI.Controllers;
using MVCInventory.Business.Abstract;
using MVCInventory.Data;

namespace MVCInventory.WebUI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //arrange
           
        }

        [TestClass]
        public class AdminControllerTests
        {

            [TestMethod]
            public void CanChangeLoginName()
            {
                // Arrange (set up a scenario)
                Building building = new Building() { BuildingName = "16" };
                FakeRepository repositoryParam = new FakeRepository();
                repositoryParam.Add(building);
                // AdminController target = new AdminController(repositoryParam);
                AdminController target = new AdminController();
                string oldBuildingName = building.BuildingName;
                string newBuildingName = "18";

                // Act (attempt the operation)
                target.ChangeBuildingName(oldBuildingName, newBuildingName);

                // Assert (verify the result)
                Assert.AreEqual(newBuildingName, building.BuildingName);
                Assert.IsTrue(repositoryParam.SubmitChanges() > 0);
            }
            class FakeRepository : IBuildingRepository
            {
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

                public Building FetchByBuildingName(string name)
                {
                    using (var dbContext = new InventoryContext())
                    {
                        return dbContext.Buildings.FirstOrDefault(x => x.BuildingName == name);
                    }
                }

                public Building FetchByBuildingId(int Id)
                {
                    return new Building() { Id = Id };
                }

                public int SubmitChanges()
                {

                    using (var dbContext = new InventoryContext())
                    {
                        return dbContext.SaveChanges();
                    }
                }

                public IEnumerable<Building> GetAll()
                {
                    using (var dbContext = new InventoryContext())
                    {
                        return dbContext.Buildings.ToList();
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
            }
        }
    }
}
