var mvcInventoryApp = angular.module('MVCInventoryApp', [
    'MVCInventoryApp.services',
    'MVCInventoryApp.controllers',
    'MVCInventoryApp.directives',
    'ngRoute'
]);

mvcInventoryApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

    $routeProvider.
           when('/buildings', {
               templateUrl: '../Angular/Template/Buildings.html',
               //template: 'Route 1',
               controller: 'BuildingIndexCtrl'
           }).
             when('/facility/addedit', {
                 templateUrl: 'Angular/Template/FacilityAddEdit.html',
                 //template: 'Route 2',
                 controller: 'FacilityDetailCtrl'
             }).
            when('/', {
                templateUrl: 'Angular/Template/Facility.html',
                controller: 'FacilityIndexCtrl'
            }).
           otherwise({
               redirectTo: '/'
           });

    $locationProvider.html5Mode(true);
    }
]);