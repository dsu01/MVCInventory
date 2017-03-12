using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MVCInventory.Business.Abstract;
using MVCInventory.Business;
using MVCInventory.Domain;

namespace MVCInventory.WebUI.Controllers
{
    public class BuildingApiController : ApiController
    {

        private IBuildingRepository buildingRepo = BuildingRepository.getRepository();
        //public BuildingApiController(IBuildingRepository buildrepo)
        //{
        //    buildingRepo = buildrepo;
        //}

        [System.Web.Http.HttpGet]
        public Building GetBuilding(string name)
        {
            return buildingRepo.FetchByBuildingName(name);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/building", Name = "GetBuilding")]
        public List<Building> GetAllBuildings()
        {
            return buildingRepo.GetAll().ToList();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/building/{Id}", Name = "GetBuildingById")]
        public Building GetBuilding(int id)
        {
            return buildingRepo.FetchByBuildingId(id);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/building", Name = "AddBuilding")]
        public Building AddBuilding(Building building)
        {
            return buildingRepo.Add(building);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/building", Name = "UpdateBuilding")]
        public Building UpdateBuilding(Building building)
        {
            return buildingRepo.Update(building);
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/building/{Id}", Name = "DeleteBuilding")]
        public void DeleteBuilding(int id)
        {
            buildingRepo.DeleteBuilding(id);
        }
    }
}