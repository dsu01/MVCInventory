var mvcInventoryControllers = angular.module('MVCInventoryApp.controllers', []);

mvcInventoryControllers.controller('BuildingIndexCtrl', function ($scope, MVCInventoryAppService) {
    $scope.buildingList = [];

    function selectView(view) {
        $('.display').not('#' + view + "Display").hide();
        $('#' + view + "Display").show();
    }
   
    this.getData = function() {
        MVCInventoryAppService.GetBuilding()
            .then(function(response) {
                $scope.buildingList = response.data;
                if ($('input:radio') != null && $('input:radio')[0] != null)
                    $('input:radio')[0].checked = true;
                selectView("summary");
            })
               //.error(function (error) {
               //    $scope.data.error = error;
               //});
        .catch
        (function(response) {
                alert("Loading facilities failed...");
            }
        );
    }
    
    this.getData();

    $scope.remove = function (id) {
        MVCInventoryAppService.remove(id)
           .then(function (response) {
               selectView("summary");
           })
       .catch
       (function (response) {
           alert("remove building failed...");
       }
       );
    }
}
);