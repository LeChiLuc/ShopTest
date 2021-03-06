﻿/// <reference path="/Assets/Admin/libs/angular/angular.js" />

(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http','notificationService'];
    function apiService($http) {
        return {
            get: get,
            post:post
        }
        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Authenticate is required.');
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }
        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    }
})(angular.module('shoptest.common'));