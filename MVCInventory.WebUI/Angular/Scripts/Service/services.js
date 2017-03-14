var mvcInventoryAppServices = angular.module('MVCInventoryApp.services', []);

mvcInventoryAppServices.factory('MVCInventoryAppService',
    function ($http) {
        var buildingAPIService = {};

        buildingAPIService.GetBuilding = function () {
            return $http({
                method: 'GET',
                url: "/api/buildings"
            });
        }

        return buildingAPIService;

    });