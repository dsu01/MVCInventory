using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MVCInventory.WebUI.Models;
using MVCInventory.Data;
using MVCInventory.Domain;

namespace MVCInventory.WebUI.Controllers
{
    public class FacilityController : ApiController
    {
        IFacilityRepository repository = FacilityRepository.getRepository();

        [System.Web.Mvc.HttpGet]
        [Route("api/facility", Name = "GetFacilityRoute")]
        public IEnumerable<Facility> GetAllFacilitys()
        {
            return repository.GetAll();
        }

        [System.Web.Mvc.HttpGet]
        [Route("api/facility/{id}", Name = "GetFacilityByIDRoute")]
        public Facility GetFacility(Guid id)
        {
            return repository.Get(id);
        }

        [System.Web.Mvc.HttpPost]
        public Facility CreateFacility(Facility item)
        {
            return repository.Add(item);
        }

        [System.Web.Mvc.HttpPost]
        [Route("api/facility", Name = "UpdateFacilityRoute")]
        public bool UpdateFacility(Facility item)
        {
            return repository.Update(item);
        }

        public void DeleteFacility(Guid id)
        {
            repository.Remove(id);
        }
    }
}
