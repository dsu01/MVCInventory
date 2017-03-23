angular.module('FacilitiesApp.services', [])
.factory('FacilityAPIService', function ($http) {

      var facilityAPIService = {};

      facilityAPIService.GetFacilities = function () {
          return $http({
              method: 'GET',
              url: "/api/facility"
          });
      },

      facilityAPIService.GetFacility = function (id) {
          return $http({
              method: 'GET',
              url: '/api/facility/' + id
          });
      },
      
      facilityAPIService.UpdateFacility = function (item) {
          return $http({
              method: 'POST',
              url: '/api/facility',
              data: item
          });
      }

      return facilityAPIService;
})
.factory('BuildingAPIService', function ($http) {

    var buildingApiService = {};

    buildingApiService.GetBuildings = function () {
        return $http({
            method: 'GET',
            url: "/api/building"
        });
    }
    
    //,
    //buildingApiService.GetBuilding = function (id) {
    //    return $http({
    //        method: 'GET',
    //        url: '/api/building/' + id
    //    });
    //},

    //buildingApiService.UpdateBuilding = function (item) {
    //    return $http({
    //        method: 'POST',
    //        url: '/api/building',
    //        data: item
    //    });
    //}

    return buildingApiService;
})
;
