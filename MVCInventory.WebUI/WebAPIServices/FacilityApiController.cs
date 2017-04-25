using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MVCInventory.Business;
using MVCInventory.Business.Abstract;
using MVCInventory.Business.Models;
using MVCInventory.Data;
using MVCInventory.Domain;

namespace MVCInventory.WebUI.WebAPIServices
{
    public class FacilityApiController : ApiController
    {
      //  private IFacilityRepository facilityRepo = FacilityRepository.getRepository();
       private readonly IFacilityManager _facilityManager;

        public FacilityApiController(IFacilityManager facilityManager)
        {
            _facilityManager = facilityManager;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/facility", Name = "GetFacilities")]
        //public List<Facility> GetAllFacilities()
        public List<FacilityModel> GetAllFacilities()
        {
            // return facilityRepo.GetAll().ToList();
            return _facilityManager.GetAll();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/facility/{Id}", Name = "GetFacilityById")]
        public FacilityModel GetFacilityById(Guid id)
        {
            return _facilityManager.GetById(id);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/facility/add", Name = "AddFacility")]
        public FacilityModel AddFacility(FacilityModel Facility)
        {
            return _facilityManager.Add(Facility);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/facility/edit", Name = "UpdateFacility")]
        public bool UpdateFacility(FacilityModel Facility)
        {
            return _facilityManager.Update(Facility);
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/facility/delete/{id}", Name = "DeleteFacility")]
        public void DeleteFacility(Guid id)
        {
            _facilityManager.Delete(id);
        }
    }
}