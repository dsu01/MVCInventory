using System;
using System.Collections.Generic;
using System.Linq;
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
            Init();

            return View();
        }

        private void Init()
        {
            using (var dbContext = new InventoryContext())
            {
                var buildings = dbContext.Buildings.ToList();
            }
        }
    }
}