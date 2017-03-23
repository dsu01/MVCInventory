using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MVCInventory.WebUI.Models;
using MVCInventory.Data;
using MVCInventory.Domain;
using MVCInventory.Domain.Interface;

namespace MVCInventory.WebUI.Controllers
{
    public class BuildingController : ApiController
    {
        IBuildingRepository repository = BuildingRepository.getRepository();

        [System.Web.Mvc.HttpGet]
        [Route("api/Building", Name = "GetBuildingRoute")]
        public IEnumerable<Building> GetAllBuildings()
        {
            return repository.GetAll();
        }

        [System.Web.Mvc.HttpGet]
        [Route("api/Building/{id}", Name = "GetBuildingByIDRoute")]
        public Building GetBuilding(int id)
        {
            return repository.Get(id);
        }

        [System.Web.Mvc.HttpPost]
        public Building CreateBuilding(Building item)
        {
            return repository.Add(item);
        }

        [System.Web.Mvc.HttpPost]
        [Route("api/Building", Name = "UpdateBuildingRoute")]
        public bool UpdateBuilding(Building item)
        {
            return repository.Update(item);
        }

        public void DeleteBuilding(int id)
        {
            repository.Remove(id);
        }
    }
}
