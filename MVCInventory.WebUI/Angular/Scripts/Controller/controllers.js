﻿var mvcInventoryControllers = angular.module('MVCInventoryApp.controllers', []);

mvcInventoryControllers.controller('BuildingSelectorController',
    function($scope, MVCInventoryAppService) {
        $scope.BuildingList = null;

        MVCInventoryAppService.GetBuilding()
            .then(function(response) {
                $scope.BuildingList = response.data;
            });
    });

mvcInventoryControllers.controller('BuildingIndexCtrl',
    function($scope, MVCInventoryAppService) {
        $scope.buildingList = [];
        $scope.currentBuilding = {};
        $scope.selBuilding = {};
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
                        alert("Loading buildings failed...");
                    }
                );
        }


        $scope.remove = function(id) {
            MVCInventoryAppService.remove(id)
                .then(function(response) {
                    selectView("summary");
                })
                .catch
                (function(response) {
                        alert("remove building failed...");
                    }
                );
        }


        $scope.edit = function(id) {
            MVCInventoryAppService.GetBuildingById(id)
                .then(function(response) {
                    $scope.currentBuilding = response.data;
                    selectView("edit");
                })
                .catch
                (function(response) {
                        alert("edit failed...");
                    }
                );
        }

        $scope.AddBuilding = function() {
            $scope.currentBuilding = {
                Id: -1,
                BuildingName: "",
                Property: ""
            };
            selectView("edit");
        }

        $scope.Refresh = function() {
            getData();

        }

        $scope.sumbitChange = function(item) {
            if (item == null || item.Id == null || item.Id < 0) {
                MVCInventoryAppService.addBuilding(item)
                    .then(function(response) {
                        getData();
                    })
                    .catch
                    (function(response) {
                            alert("update failed...");
                        }
                    );
            } else {
                MVCInventoryAppService.update(item)
                    .then(function(response) {
                        getData();
                    })
                    .catch
                    (function(response) {
                            alert("update failed...");
                        }
                    );
            }

        }
    });


mvcInventoryControllers.controller('FacilityIndexCtrl', function ($scope, MVCInventoryAppService) {
    $scope.facilityList = [];
    $self = this;

    $scope.displayDetail = false;
    $scope.testFunc = function (displayDetail) {
        $scope.displayDetail = displayDetail;

        //if ($scope.displayDetail)
        getData();
    };
  
     function getData() {
   // $scope.getData = function(){
        MVCInventoryAppService.GetFacilities()
            .then(function (response) {
                //Dig into the responde to get the relevant data
                $scope.facilitiesList = response.data;
                    $scope.displayDetail = false;

                    //$scope.searchFilter = function(driver) {
                    //    var keyword = new RegExp($scope.nameFilter, 'i');
                    //    return !$scope.nameFilter || keyword.test(facility.Property) || keyword.test(facility.FacilityName);
                    //};

                    //selectView("summary");
                })
              .catch(function (response) {
                  alert("Loading facilities failed...");
              }
              )
        ;

    }

    getData();


    $scope.refresh = function () {
        getData();
    }

    $scope.search = function() {
            $(".facility-table-wrapper").css("display", "block");
    }

    $scope.$watch('displayDetail', function (newValue) {
        if (!newValue) {
            $self.getData();
        }
    });

    // Show Blank Form For Adding New Facility
    $scope.addBlankFacilityForm = function () {
        //$scope.currentFacility = {
        //    "Id" : 0,
        //    "FacilityName": '',
        //    "FacilityGroup": '',
        //    BuildingId: 1,
        //    //Building: null
        //};
        $scope.currentFacility = {};
        //$scope.currentFacility = {};
        $scope.displayDetail = true;

    }
   
    // Save or add new facility
    //$scope.saveFacility = function () {
    //    if (!$scope.currentFacility.Id) {
    //        MVCInventoryAppService.addFacility($scope.currentFacility)
    //                    .then(function (response) {
    //                        getData();
    //                    })
    //                  .catch(function (response) {
    //                      alert("Add facility failed...");
    //                  })
    //        ;
    //    } else {
    //        MVCInventoryAppService.updateFacility($scope.currentFacility)
    //                  .then(function (response) {
    //                      if (response.data)
    //                          getData();
    //                      else {
    //                          alert('cannot add');
    //                      }
    //                  })
    //                .catch(function (response) {
    //                    alert("Add facility failed...");
    //                })
    //        ;
    //    }
    //}
            
    // Get facility
    $scope.getFacility = function (facilityId) {
        $scope.currentFacility = {};
        MVCInventoryAppService.GetFacilityById(facilityId)
                       .then(function (response) {
                           $scope.currentFacility = response.data;
                           $scope.displayDetail = true;
                       })
                     .catch(function (response) {
                         alert("Loading facility detail info failed...");
                     });
    }

    // Delete facility
    $scope.deleteFacility = function (facilityId) {
    
        MVCInventoryAppService.removeFacility(facilityId)
                       .then(function (response) {
                           getData();
                       })
                     .catch(function (response) {
                         alert("Loading facility detail info failed...");
                     });
    }

    $scope.$watch('filter', function (newValue, oldValue) {
        //perform the initial search when the page first loads
        if (!oldValue && newValue)
            $scope.search();
    });



    }
);

mvcInventoryControllers.controller('FacilityDetailController', function ($scope, MVCInventoryAppService) {
  
    //if (facilityId != null && parseInt(facilityId) > 0)
    //{ getDataByID();}
    
    //$scope.canSubmit = function (editForm) {

    //    return (editForm.$valid);
    //}
    //function getDataByID() {
    //    MVCInventoryAppService.GetFacilityById(parseInt(facilityId))
    //        .then(function (response) {
    //            //Dig into the responde to get the relevant data
    //            $scope.currentFacility = response.data;
    //        })
    //          .catch(function (response) {
    //              alert("Loading facilities failed...");
    //          }
    //          )
    //    ;
    //}
  

    $scope.saveFacility = function () {
        if (!$scope.facility.Id) {
           
            MVCInventoryAppService.addFacility($scope.facility)
                        .then(function (response) {
                            //how to call getData(); or Refresh
                            $scope.getData();
                            $scope.displayDetail = false;
                        })
                      .catch(function (response) {
                          alert("Add facility failed..." + response.message);
                      })
            ;
        } else {
            MVCInventoryAppService.updateFacility($scope.facility)
                      .then(function (response) {
                          if (response.data)
                          {
                            $scope.getData();
                            $scope.displayDetail = false;
                          }
                        else {
                            alert('cannot update');
                        }
                    })
                    .catch(function (response) {
                        alert("update facility failed..." + response.message);
                    })
            ;
        }
    }

    
})
;
