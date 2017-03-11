using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCInventory.Domain.Abstract;
using MVCInventory.Domain;
using System.Collections.Generic;
using MVCInventory.WebUI.Controllers;

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
                AdminController target = new AdminController(repositoryParam);
                string oldBuildingName = building.BuildingName;
                string newBuildingName = "18";

                // Act (attempt the operation)
                target.ChangeBuildingName(oldBuildingName, newBuildingName);

                // Assert (verify the result)
                Assert.AreEqual(newBuildingName, building.BuildingName);
                Assert.IsTrue(repositoryParam.DidSubmitChanges);
            }
            class FakeRepository : IBuildingRepository
            {
                public List<Building> buildings = new List<Building>();
                public bool DidSubmitChanges = false;

                public void Add(Building building)
                {
                    buildings.Add(building);
                }

                public Building FetchByBuildingName(string name)
                {
                   return new Domain.Building() { BuildingName = name };
                }

                public Building FetchByBuildingId(int Id)
                {
                    return new Building() { Id = Id };
                }

                public void SubmitChanges()
                {
                    DidSubmitChanges = true;
                }
            }
        }
    }
}
