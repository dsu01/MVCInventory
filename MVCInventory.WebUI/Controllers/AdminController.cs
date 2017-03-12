using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCInventory.Business.Abstract;
using MVCInventory.Business;
using MVCInventory.Domain;

namespace MVCInventory.WebUI.Controllers
{
    public class AdminController : Controller
    {
        //private IBuildingRepository buildingRepo;
        private IBuildingRepository buildingRepo = BuildingRepository.getRepository();


        //public AdminController(IBuildingRepository buildrepo)
        //{
        //    buildingRepo = buildrepo;
        //}
        public ActionResult ChangeBuildingName(string oldName, string newName)
        {
            Building building = buildingRepo.FetchByBuildingName(oldName);
            building.BuildingName = newName;
            buildingRepo.SubmitChanges();
            return View();
        }

        public ActionResult BuildingManager()
        {
            var buildinglist = buildingRepo.GetAll().ToList();
            return View(buildinglist);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Building building)
        {
            buildingRepo.Add(building);
            return RedirectToAction("BuildingManager");
        }
    }
}