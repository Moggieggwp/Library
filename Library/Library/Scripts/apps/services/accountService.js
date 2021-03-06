﻿(function () {
    'use strict';

    angular
        .module('Library')
        .service('accountService', accountService);

    accountService.$inject = ['$http'];

    function accountService($http) {
        var url = "/api/Account";


        this.login = function (data) {
            return $http({
                method: 'POST',
                url: url + "/SignIn",
                data: data,
                headers: { 'Content-Type': 'application/json' }
            });
        };

        this.register = function (data) {
            return $http({
                method: 'POST',
                url: url + "/Register",
                data: data,
                headers: { 'Content-Type': 'application/json' }
            });
        };

        this.isLogged = function () {
            return $http.get(url + "/IsAuthenticated");
        }
    }
})();