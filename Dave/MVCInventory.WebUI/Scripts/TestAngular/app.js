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
            restrict: 'E',
            scope: { selectedFacility: '=' },
            templateUrl: "Partials/derective-FacilityInfo.html"
        };
    });

app.directive('buildingSelector', ['$filter', function ($filter) {

    function link($scope, element, attrs) {

        //$scope.building = {};

        //if ($scope.default)
        //    $scope.states.splice(0, 0, { IntegerValue: null, StringValue: $scope.default });

        if (!$scope.buildingId && $scope.BuildingList && $scope.BuildingList.length > 0)
            $scope.building = $scope.BuildingList[0];

        $scope.$watch('building', function (newValue, oldValue) {
            if (newValue) {
                $scope.buildingId = newValue.Id;
            }
        });

        $scope.$watch('buildingId', function (newValue, oldValue) {
            if (newValue) {
                $scope.building = $filter('filter')($scope.BuildingList, function (d) { return d.Id === $scope.buildingId; })[0];
            }
        })
    }

    return {
        restrict: 'E',
        scope: {
            building: '=',
            buildingId: '=',
            'default': '@default',
        },
        link: link,
        controller: 'BuildingSelectorController',
        templateUrl: "Partials/BuildingSelector.html"
    };
}]);

app.directive('facilitySelector', function () {
    function link($scope, element, attrs) {

        $scope.selectedFacility = {};

        if ($scope.FacilityList.length > 0)
            $scope.selectedFacility = $scope.FacilityList[0];

        $scope.$watch('facility', function (newValue, oldValue) {
            if (newValue) {
                $scope.facilityId = newValue.Id;
            }
        });

        $scope.$watch('Id',
            function(newValue, oldValue) {
                if (newValue) {
                    $scope.selectedFacility = $filter('filter')($scope.FacilityList,
                        function (d) { return d.Id === $scope.facilityId; })[0];
                }
            });
    }

    return {
        retrict: 'E',
        templateUrl: 'Partials/derective-facilityselector.html',
        controller: 'FacilitySelectorController',
        scope: {
            facilityList: '='
        }
    }
});

app.directive('myCurrentTime',
[
    '$interval', 'dateFilter', function ($interval, dateFilter) {
        function link(scope, element, attrs) {
            var format, timeoutId;

            function updateTime() {
                element.text(dateFilter(new Date(), format));
            }

            scope.$watch(attrs.myCurrentTime,
                function (value) {
                    format = value;
                    updateTime();
                });

            element.on('$destroy',
                function () {
                    $interval.cancel(timeoutId);
                });

            // start the UI update process; save the timeoutId for canceling
            timeoutId = $interval(function () {
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
    function () {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                'close': '&onClose'
            },
            templateUrl: 'Partials/MyDialogClose.html'
        };
    });

app.directive('facilityDetail', [function ($filter) {

    function link($scope, element, attrs) {

        //$scope.$watch('building', function (newValue, oldValue) {
        //    if (newValue) {
        //        $scope.buildingId = newValue.Id;
        //    }
        //});
    }

    return {
        restrict: 'E',
        scope: {
            facility: '=',
            displayDetail: '=',
            testFunc: '=',
        },
        link: link,
        controller: 'FacilityDetailController',
        templateUrl: "Partials/FacilityDetail.html"
    };
}]);
