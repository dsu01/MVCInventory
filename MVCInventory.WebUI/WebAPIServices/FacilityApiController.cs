using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MVCInventory.Business;
using MVCInventory.Business.Abstract;
using MVCInventory.Data;
using MVCInventory.Domain;

namespace MVCInventory.WebUI.WebAPIServices
{
    public class FacilityApiController : ApiController
    {
        private IFacilityRepository facilityRepo = FacilityRepository.getRepository();
     
        public FacilityApiController() { }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/facility", Name = "GetFacilities")]
        //public List<Facility> GetAllFacilities()
        public IEnumerable<Facility> GetAllFacilities()
        {
            // return facilityRepo.GetAll().ToList();
            return facilityRepo.GetAll();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/facility/{Id}", Name = "GetFacilityById")]
        public Facility GetFacilityById(Guid id)
        {
            return facilityRepo.FetchByFacilityId(id);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/facility/add", Name = "AddFacility")]
        public Facility AddFacility(Facility Facility)
        {
            return facilityRepo.Add(Facility);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/facility/edit", Name = "UpdateFacility")]
        public Facility UpdateFacility(Facility Facility)
        {
            return facilityRepo.Update(Facility);
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/facility/delete/{id}", Name = "DeleteFacility")]
        public void DeleteFacility(Guid id)
        {
            facilityRepo.DeleteFacility(id);
        }
    }
}