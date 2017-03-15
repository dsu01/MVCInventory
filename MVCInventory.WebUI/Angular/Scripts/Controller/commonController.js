var commonControllers = angular.module('MVCInventoryApp.commonControllers', []);

commonControllers.controller('FileUploadCtrl', [
  '$scope', 'fileUploadService', function($scope, fileUploadService) {
      'use strict';
      $scope.pagename = 'File Upload';
      $scope.model = {};
      $scope.model.uploadFiles = [];

    }
]);