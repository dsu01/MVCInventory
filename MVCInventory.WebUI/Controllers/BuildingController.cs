using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCInventory.Domain.Abstract;

namespace MVCInventory.WebUI.Controllers
{
    public class BuildingController : Controller
    {
        private IBuildingRepository repository;
        public int PageSize = 4;

        public BuildingController(IBuildingRepository buildingRepository){
            repository = buildingRepository;
            //add a constructor declares a dependency on the IBuildingRepository interface
        }
        
        //public ViewResult List(int page = 1)
        //{
        //    return View(repository.Buildings
        //        .OrderBy(b => b.Property)
        //        .Skip((page-1) * PageSize)//skip over the products that occur before the start of current page
        //        .Take(PageSize));
        //}
    }
}