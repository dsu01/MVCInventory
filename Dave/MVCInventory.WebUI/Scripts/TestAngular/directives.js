angular.module('FacilitiesApp.directives', [])
.controller('DialogController', ['$scope', '$timeout', function ($scope, $timeout) {
    $scope.name = 'Scott';
    $scope.message = 'Closing Facility...';
    $scope.hideDialog = function (message) {
        $scope.message = message;
        $scope.dialogIsHidden = true;
        $timeout(function () {
            $scope.message = 'Closing Facility';
            $scope.dialogIsHidden = false;
        }, 2000);
    };
}])
.directive('facilityInfo', function () {
    return {
        scope: { CurrentFacility: '=facility' },
        //scope: { CurrentFacility: '=999' },
        templateUrl: "Partials/FacilityInfo.html"
        // template: 'Name: {{CurrentFacility.FacilityName}} Property: {{CurrentFacility.FacilityGroup}}'
    };
})
.directive('myCurrentTime', ['$interval', 'dateFilter', function ($interval, dateFilter) {
    function link(scope, element, attrs) {
        var format, timeoutId;

        function updateTime() {
            element.text(dateFilter(new Date(), format));
        }

        scope.$watch(attrs.myCurrentTime, function (value) {
            format = value;
            updateTime();
        });

        element.on('$destroy', function () {
            $interval.cancel(timeoutId);
        });

        // start the UI update process; save the timeoutId for canceling
        timeoutId = $interval(function () {
            updateTime(); // update DOM
        }, 1000);
    }

    return {
        link: link
    };
}])
.directive('myDialog', function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {
            'close': '&onClose'
        },
        templateUrl: 'Partials/MyDialogClose.html'
    };
})
;
