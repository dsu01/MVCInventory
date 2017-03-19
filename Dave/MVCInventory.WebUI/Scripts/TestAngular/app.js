angular.module('FacilitiesApp', [
  'FacilitiesApp.services',
  'FacilitiesApp.controllers',
  'ngRoute'
])
.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
      when("/Facilities", { templateUrl: "Partials/Facilities.html", controller: "FacilitiesController" }).
      when("/Facilities/:id", { templateUrl: "Partials/Facility.html", controller: "FacilityController" }).
      otherwise({ redirectTo: '/Facilities' });
}])
//.config(['$locationProvider', function ($locationProvider) {
//    $locationProvider
//        .html5Mode(true);
//}])
;
