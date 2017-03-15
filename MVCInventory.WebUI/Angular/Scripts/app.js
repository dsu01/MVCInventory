var mvcInventoryApp = angular.module('MVCInventoryApp', [
    'MVCInventoryApp.services',
  'MVCInventoryApp.controllers',
  'ngRoute'
]);

mvcInventoryApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
           when('/', {
               templateUrl: '../Angular/Template/Buildings.html',
               //template: 'Route 1',
               controller: 'BuildingIndexCtrl'
           }).
             when('/buildings', {
                 templateUrl: 'Angular/Template/Empty.html',
                 //template: 'Route 2',
                 controller: 'BuildingIndexCtrl'
             }).
           otherwise({
               redirectTo: '/'
           });
    }
]);