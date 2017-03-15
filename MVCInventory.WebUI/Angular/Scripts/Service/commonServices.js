var commonServices = angular.module('commomServices', []);

commomServices.factory('fileUploadService',
    function($http) {

        var fileUploadService = {
            uploadAttachmentAsync: function(attachment) {
                var url = "api/file";
                var result = $http.post(url, attachment)
                    .then(function(response) {
                        return response.data;
                    });
                return result;
            },
            getUploadFilesAsync: function () {
                var url = "api/files";
                var result = $http.get(url).then(function (response) {
                    return response.data;
                });

                return result;
            }
        };

        return fileUploadService;
    });