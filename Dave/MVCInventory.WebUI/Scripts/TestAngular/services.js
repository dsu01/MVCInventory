angular.module('FacilitiesApp.services', []).
  factory('FacilityAPIService', function ($http) {

      var facilityAPIService = {};

      facilityAPIService.GetFacilities = function () {
          return $http({
              //method: 'JSONP',
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
  });
