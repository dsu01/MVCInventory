var appDirectives = angular.module('FacilitiesApp.directives', []);

appDirectives.directive('facilitySelector', ['$filter', function ($filter) {
    function link($scope, element, attrs) {

        if (!$scope.facilityId && $scope.FacilityList && $scope.FacilityList.length > 0)
            $scope.facility = $scope.FacilityList[0];

        $scope.$watch('facility', function (newValue, oldValue) {
            if (newValue) {
                $scope.facilityId = newValue.Id;
            }
        });

        $scope.$watch('facilityId',
            function (newValue, oldValue) {
                if (newValue) {
                    $scope.facility = $filter('filter')($scope.FacilityList,
                        function (d) { return d.Id === $scope.facilityId; })[0];
                }
            });
    }

    return {
        retrict: 'E',
        scope: {
            facility: '=',
            facilityid: '='
        },
        link: link,
        templateUrl: '/Shared/FacilityDropDown/directive-facilitySelector.html',
        controller: 'FacilitySelectorController'
    };
}]);

appDirectives.directive('facilityInfo',
    function () {
        return {
            restrict: 'E',
            scope: { facility: '=' },
            templateUrl: "Partials/derective-FacilityInfo.html"

        };
    });
