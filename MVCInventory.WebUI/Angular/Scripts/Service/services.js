var mvcInventoryAppServices = angular.module('MVCInventoryApp.services', []);

mvcInventoryAppServices.factory('MVCInventoryAppService',
    function ($http) {
        var inventorAPIService = {};

        inventorAPIService.GetBuilding = function () {
            return $http({
                method: 'GET',
                url: "api/building"
            });
        };

        inventorAPIService.GetBuildingById = function (id) {
            return $http({
                method: 'GET',
                url: "api/building/" + id
            });
        };

        inventorAPIService.remove = function (id) {
            return $http({
                method: 'DELETE',
                url: "api/building/" + id
            });
        };

        inventorAPIService.addBuilding = function (item) {
            return $http({
                method: 'POST',
                url: "api/building",
                data: item
            });
        };

        inventorAPIService.update = function (item) {
            return $http({
                method: 'POST',
                url: "api/building/edit",
                data: item
            });
        };

        inventorAPIService.GetFacilities = function () {
            return $http({
                method: 'GET',
                url: "/api/facility"
            });
        },

        inventorAPIService.GetFacilityById = function (id) {
            return $http({
                method: 'GET',
                url: "api/facility/" + id
            });
        },

        inventorAPIService.removeFacility = function (id) {
            return $http({
                method: 'DELETE',
                url: "api/facility/delete/" + id
            });
        },

        inventorAPIService.addFacility = function (item) {
            return $http({
                method: 'POST',
                url: "api/facility/add",
                data: item
            });
        },

        inventorAPIService.updateFacility = function (item) {
            return $http({
                method: 'POST',
                url: "api/facility/edit",
                data: item
            });
        }
        return inventorAPIService;

    });