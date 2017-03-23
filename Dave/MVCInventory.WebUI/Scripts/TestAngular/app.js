var app = angular.module('FacilitiesApp', [
  'FacilitiesApp.services',
  'FacilitiesApp.controllers',
  'FacilitiesApp.directives',
  'FacilitiesApp.components',
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

app.directive('facilityInfo',
    function () {
        return {
            scope: { CurrentFacility: '=facility' },
            //scope: { CurrentFacility: '=999' },
            templateUrl: "Partials/FacilityInfo.html"
            // template: 'Name: {{CurrentFacility.FacilityName}} Property: {{CurrentFacility.FacilityGroup}}'
        };
    });

app.directive('buildingSelector',
    function() {
        return {
            //scope: { CurrentFacility: '=facility' },
            
            controller: 'BuildingSelectorController',
            templateUrl: "Partials/BuildingSelector.html"
        };
    });


app.directive('myCurrentTime',
[
    '$interval', 'dateFilter', function($interval, dateFilter) {
        function link(scope, element, attrs) {
            var format, timeoutId;

            function updateTime() {
                element.text(dateFilter(new Date(), format));
            }

            scope.$watch(attrs.myCurrentTime,
                function(value) {
                    format = value;
                    updateTime();
                });

            element.on('$destroy',
                function() {
                    $interval.cancel(timeoutId);
                });

            // start the UI update process; save the timeoutId for canceling
            timeoutId = $interval(function() {
                    updateTime(); // update DOM
                },
                1000);
        }

        return {
            link: link
        };
    }
]);

app.directive('myDialog',
    function() {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                'close': '&onClose'
            },
            templateUrl: 'Partials/MyDialogClose.html'
        };
    });



