var mvcInventoryControllers = angular.module('MVCInventoryApp.controllers', []);

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
                        alert("Loading facilities failed...");
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
    getData();
   
    function getData() {
        MVCInventoryAppService.GetFacilities()
            .then(function (response) {
                //Dig into the responde to get the relevant data
                $scope.facilitiesList = response.data;

                if ($('input:radio') != null && $('input:radio')[0] != null)
                    $('input:radio')[0].checked = "checked";

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

        $("button").click(function (e) {
            var selectedRadio = $('input:radio:checked');
            var facilityId = selectedRadio.attr('value');
            switch (e.target.id) {
                case "refresh":
                    $self.getData();
                    break;
                case "editBtn":
                    MVCInventoryAppService.GetFacilityById(facilityId)
                        .then(function (response) {
                            $scope.CurrentFacility = response.data;
                            $scope.displayDetail = true;
                        })
                      .catch(function (response) {
                          alert("Loading facility failed...");
                      })
                    ;
                    break;
              
            }
        });
    }
    
    $scope.Refresh = function () {
        getData();
    }

    $scope.search = function() {
            $(".facility-table-wrapper").css("display", "block");
    }

   

    $scope.$watch('filter', function (newValue, oldValue) {
        //perform the initial search when the page first loads
        if (!oldValue && newValue)
            $scope.search();
    });


    }
);

mvcInventoryControllers.controller('FacilityDetailController', function ($scope, MVCInventoryAppService) {
    //var facilityId = $routeParams.Id;
    $scope.currentFacility = {};
   // $scope.selBuilding = {};
    
    //if (facilityId != null && parseInt(facilityId) > 0)
    //{ getDataByID();}
    
    $scope.canSubmit = function (editForm) {

        return (editForm.$valid);
    }
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
  

    $scope.sumbit = function (item) {
  
        if (item == null || item.Id == null ||item.Id < 0) {
            MVCInventoryAppService.AddFacility(item)
          .then(function (response) {
              $scope.displayDetail = false;
          })
      .catch
      (function (response) {
          alert("update failed...");
      }
      );
        }
        else {
            MVCInventoryAppService.UpdateFacility(item)
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
    
})
;
