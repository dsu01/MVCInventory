using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using MVCInventory.WebUI.Models;
using MVCInventory.Data;

namespace MVCInventory.WebUI.Controllers
{
    public class HomeController : Controller
    {
        InventoryContext repo = new InventoryContext();
        // GET: Home
        public ActionResult Index()
        {
            //Init();
            //var building = repo.Buildings.FirstOrDefault();
            Claim newClaim = new Claim(ClaimTypes.Country, "Sweden");
            return View();
        }

        //private void Init()
        //{
        //    using (var dbContext = new InventoryContext())
        //    {
        //        var buildings = dbContext.Buildings.ToList();
        //    }
        //}
    }
}