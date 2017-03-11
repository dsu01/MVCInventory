using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCInventory.Domain.Abstract;
using MVCInventory.Domain;

namespace MVCInventory.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IBuildingRepository buildingRepo;

        public AdminController(IBuildingRepository buildrepo)
        {
            buildingRepo = buildrepo;
        }
        public ActionResult ChangeBuildingName(string oldName, string newName)
        {
            Building building = buildingRepo.FetchByBuildingName(oldName);
            building.BuildingName = newName;
            buildingRepo.SubmitChanges();
            return View();
        }
        
    }
}