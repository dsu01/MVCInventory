var mvcInventoryAppServices = angular.module('MVCInventoryApp.services', []);

mvcInventoryAppServices.factory('MVCInventoryAppService',
    function ($http) {
        var buildingAPIService = {};

        buildingAPIService.GetBuilding = function() {
            return $http({
                method: 'GET',
                url: "api/building"
            });
        };

        buildingAPIService.remove = function(id) {
            return $http({
                method: 'DELETE',
                url: "api/building/" + id
            });
        };

        return buildingAPIService;

    });