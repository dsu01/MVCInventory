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

.factory('ModalService', function () {

    var modals = []; // array of modals on the page
    var service = {};

    service.Add = Add;
    service.Remove = Remove;
    service.Open = Open;
    service.Close = Close;

    return service;

    function Add(modal) {
        // add modal to array of active modals
        modals.push(modal);
    }

    function Remove(id) {
        // remove modal from array of active modals
        var modalToRemove = _.findWhere(modals, { id: id });
        modals = _.without(modals, modalToRemove);
    }

    function Open(id) {
        // open modal specified by id
        var modal = _.findWhere(modals, { id: id });
        modal.open();
    }

    function Close(id) {
        // close modal specified by id
        var modal = _.findWhere(modals, { id: id });
        modal.close();
    }
})

;
