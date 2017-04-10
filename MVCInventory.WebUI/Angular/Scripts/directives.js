var appDirectives = angular.module('MVCInventoryApp.directives', []);

appDirectives.directive('buildingSelector', ['$filter', function ($filter) {
    function link($scope, element, attrs) {

        if (!$scope.buildingId && $scope.BuildingList && $scope.BuildingList.length > 0)
            $scope.selBuilding = $scope.BuildingList[0];

        $scope.$watch('building', function (newValue, oldValue) {
            if (newValue) {
                $scope.buildingId = newValue.Id;
            }
        });

        $scope.$watch('buildingId',
            function (newValue, oldValue) {
                if (newValue) {
                    $scope.selBuilding = $filter('filter')($scope.BuildingList,
                        function (d) { return d.Id === $scope.buildingId; })[0];
                }
            });
    }

    return {
        retrict: 'E',
        scope: {
            building: '=',
            buildingId: '='
        },
        link: link,
        templateUrl: '/Angular/Directives/directive-building-dropdown.html',
        controller: 'BuildingSelectorController'
    };
}]);

appDirectives.directive('buildingInfo',
    function () {
        return {
            restrict: 'E',
            scope: { building: '=' },
            templateUrl: "/Angular/Directives/directive-building-info.html"
        };
    });

appDirectives.directive('facilityDetail',
[
    function($filter) {

        return {
            restrict: 'E',
            scope: {
                facility: '=',
                displayDetail: '=',
                testFunc: '='
            },
            link: link,
            controller: 'FacilityDetailController',
            templateUrl: "/Angular/Directives/directive-Facility-detail.html"
        };
    }
]);
