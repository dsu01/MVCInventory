angular.module('FacilitiesApp.controllers', []).
  controller('FacilitiesController', function ($scope, FacilityAPIService) {
      //$scope.nameFilter = null;

      function selectView(view) {
          $('.display').not('#' + view + "Display").hide();
          $('#' + view + "Display").show();
      }

      $scope.MyVar = 10;
      $scope.facilitiesList = [];
      $self = this;

      $scope.displayDetail = false;
      $scope.testFunc = function (displayDetail) {
          $scope.displayDetail = displayDetail;
      };

      $self.getData = function () {
          FacilityAPIService.GetFacilities()
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
      }

      $self.getFormData = function () {
          return {
              "Id": $('#editFacilityId')[0].value,
              "FacilityName": $('#editFacilityName')[0].value,
              "FacilityGroup": $('#editFacilityGroup')[0].value
          }
      };

      $self.getData();

      $("button").click(function (e) {
          var selectedRadio = $('input:radio:checked');
          var facilityId = selectedRadio.attr('value');
          switch (e.target.id) {
              case "refresh":
                  $self.getData();
                  break;
              case "delete":
                  //$.ajax({
                  //    type: "DELETE",
                  //    url: "/api/facility/" + selectedRadio.attr('value'),
                  //    success: function (data) {
                  //        selectedRadio.closest('tr').remove();
                  //    }
                  //});
                  break;
              case "add":
                  //selectView("add");
                  break;
              case "edit":
                  FacilityAPIService.GetFacility(facilityId)
                      .then(function (response) {
                          $scope.CurrentFacility = response.data;

                          //$('#editFacilityId').val(response.data.Id);
                          //$('#editFacilityName').val(response.data.FacilityName);
                          //$('#editFacilityGroup').val(response.data.FacilityGroup);
                          //selectView("edit");

                          $scope.displayDetail = true;
                      })
                    .catch(function (response) {
                        alert("Loading facility failed...");
                    })
                  ;
                  break;
              case "submitEdit":

                  var item = $scope.CurrentFacility;

                  if (item != null) {
                      FacilityAPIService.UpdateFacility(item)
                          .then(function (response) {
                              $self.getData();
                          })
                          .catch(function (response) {
                              alert("update facility failed...");
                          });
                  }
                  break;
              case "reveal":
                  //var controller = angular.module('FacilitiesApp.controllers000', []).controller('FacilitiesController');
                  //var controller_1 = angular.module('FacilitiesApp.controllers', []).controller('FacilitiesController');
                  //var controller = angular.module('FacilitiesApp.FacilitiesController000');
                  var controller_1 = angular.module('FacilitiesApp.controllers').controller('FacilitiesController');
                  var controller_2 = this;

                  var app = angular.module('FacilitiesApp', []);
                  var controllers = angular.module('FacilitiesApp.controllers', []);
                  //var controllers2 = angular.module('FacilitiesApp.controllers', []);
                  break;
          }
      });
  })
.controller('FacilityController', function ($scope, $routeParams, FacilityAPIService) {
    $scope.Id = $routeParams.Id;
    $scope.Facility = null;

    FacilityAPIService.GetFacility($scope.Id).then(function (response) {
        $scope.Facility = response.data;
    });
})
.controller('BuildingSelectorController', function ($scope, BuildingAPIService) {
    $scope.BuildingList = null;

    BuildingAPIService.GetBuildings().then(function (response) {
        $scope.BuildingList = response.data;

        //$scope.$watch('building', function (newValue, oldValue) {
        //    if (newValue) {
        //        $scope.buildingId = newValue.Id;
        //    }
        //});

        //$scope.$watch('buildingId', function (newValue, oldValue) {
        //    if (newValue) {
        //        //$scope.building = $filter('filter')($scope.states, function (d) { return d.IntegerValue === $scope.stateId; })[0];
        //        $scope.building = $scope.BuildingList[0];
        //    }
        //})

    });
})
.controller('CurrentTimeController', ['$scope', function ($scope) {
    $scope.format = 'M/d/yy h:mm:ss a';
}])
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
.controller('FacilityController', function ($scope, $routeParams, FacilityAPIService) {
    $scope.Id = $routeParams.Id;
    $scope.Facility = null;

    FacilityAPIService.GetFacility($scope.Id).then(function (response) {
        $scope.Facility = response.data;
    });
})
.controller('FacilityDetailController', function ($scope, FacilityAPIService) {

    //FacilityAPIService.GetFacility($scope.Id).then(function (response) {
    //    $scope.Facility = response.data;
    //});
    $scope.submit = function () {
        var item = $scope.facility;

        if (item != null) {
            FacilityAPIService.UpdateFacility(item)
                .then(function (response) {
                    // $scope.displayDetail = false;
                    $scope.testFunc(false);
                })
                .catch(function (response) {
                    alert("update facility failed...");
                });
        }
    }

})
;
