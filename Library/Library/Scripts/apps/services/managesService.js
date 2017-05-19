(function () {
    'use strict';

    angular
        .module('Library')
        .service('managesService', managesService);

    managesService.$inject = ['$http'];

    function managesService($http) {
        var url = "/api/Search";

        this.getUserInfo = function (searchText) {
            return $http.get(url + "/GetUserInfo");
        };

        this.getAccountInfo = function (bookId) {
            return $http.get(url + "/GetUserEmail");
        };

        this.getOrdersInfo = function (bookId) {
            return $http.get(url + "/GetOrdersForUser");
        };

        this.changePassword = function (data) {
            return $http({
                method: 'POST',
                url: url + "/ChangePassword",
                data: data,
                headers: { 'Content-Type': 'application/json' }
            });
        };

        this.changeUserInfo = function (data) {
            return $http({
                method: 'POST',
                url: url + "/ChangeAccountData",
                data: data,
                headers: { 'Content-Type': 'application/json' }
            });
        };

        this.deleteOrder = function (data) {
            return $http({
                method: 'POST',
                url: url + "/DeleteOrder",
                data: data,
                headers: { 'Content-Type': 'application/json' }
            });
        };
    } 
})();