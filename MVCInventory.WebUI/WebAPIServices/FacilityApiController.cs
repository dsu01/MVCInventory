using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using MVCInventory.Business;
using MVCInventory.Business.Abstract;
using MVCInventory.Business.Models;
using MVCInventory.Data;
using MVCInventory.Domain;

namespace MVCInventory.WebUI.WebAPIServices
{
    public class FacilityApiController : ApiController
    {
        private IFacilityRepository _facilityRepo = FacilityRepository.getRepository();
        //private readonly IFacilityManager _facilityManager;

        public FacilityApiController(IFacilityRepository facilityRepo)
        {
            _facilityRepo = facilityRepo;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/facility", Name = "GetAllFacilities")]
        public List<FacilityModel> GetAllFacilities()
        {
            var result = _facilityRepo.GetAll().ToList();
            var mapped = Mapper.Map<List<FacilityModel>>(result);

            return mapped;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/facility/{Id}", Name = "GetFacilityById")]
        public FacilityModel GetFacilityById(Guid id)
        {
            var result = _facilityRepo.GetByFacilityId(id);
            var mapped = Mapper.Map<FacilityModel>(result);

            return mapped;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/facility/add", Name = "AddFacility")]
        public FacilityModel AddFacility(FacilityModel item)
        {
            var facility = Mapper.Map<Facility>(item);
            var result = _facilityRepo.Add(facility);
            var mapped = Mapper.Map<FacilityModel>(result);

            return mapped;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/facility/edit", Name = "UpdateFacility")]
        public bool UpdateFacility(FacilityModel item)
        {
            var facility = Mapper.Map<Facility>(item);
            var result = _facilityRepo.Update(facility);
            var mapped = Mapper.Map<FacilityModel>(result);

            return true;
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/facility/delete/{id}", Name = "DeleteFacility")]
        public void DeleteFacility(Guid id)
        {
            //var result = _facilityRepo.DeleteFacility(id);
        }
    }
}
