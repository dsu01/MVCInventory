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

        buildingAPIService.GetBuildingById = function (id) {
            return $http({
                method: 'GET',
                url: "api/building/" + id
            });
        };

        buildingAPIService.remove = function(id) {
            return $http({
                method: 'DELETE',
                url: "api/building/" + id
            });
        };

        buildingAPIService.addBuilding = function (item) {
            return $http({
                method: 'POST',
                url: "api/building",
                data: item
            });
        };

        buildingAPIService.update = function (item) {
            return $http({
                method: 'POST',
                url: "api/building/edit",
                data: item
            });
        };
        return buildingAPIService;

    });