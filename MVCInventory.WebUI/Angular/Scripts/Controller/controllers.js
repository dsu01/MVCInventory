﻿var mvcInventoryControllers = angular.module('MVCInventoryApp.controllers', []);

mvcInventoryControllers.controller('BuildingIndexCtrl', function ($scope, MVCInventoryAppService) {
    $scope.buildingList = [];
    $scope.currentBuilding = {};
    getData();

    function selectView(view) {
        $('.display').not('#' + view + "Display").hide();
        $('#' + view + "Display").show();
    }
   
    function getData() {
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

    $scope.edit = function (id) {       
        MVCInventoryAppService.GetBuildingById(id)
         .then(function (response) {
             $scope.currentBuilding = response.data;
             selectView("edit");
         })        
     .catch
     (function (response) {
         alert("edit failed...");
     }
     );
    }

    $scope.sumbitChange = function (item) {        
        MVCInventoryAppService.update(item)
           .then(function (response) {               
               getData();
           })            
       .catch
       (function (response) {
           alert("update failed...");
       }
       );
    }
}
);