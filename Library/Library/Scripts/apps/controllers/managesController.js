(function () {
    'use strict';

    angular
     .module('Library')
     .controller('managesController', managesController);

    managesController.$inject = ['$q', '$scope', '$http', 'managesService', 'accountService', 'alertService'];

    function managesController($q, $scope, $http, managesService, accountService, alertService) {

        $scope.getOrdersInfo = function () {

        };

        $scope.getUserInfo = function () {
            $scope.getUserInfoPromise = createGetUserInfoPromise();
            $scope.getUserInfoPromise.then(function (userData) {
                $scope.userInfo = userData.data;
            });
        };

        $scope.getAccountInfo = function () {
            $scope.getAccountInfoPromise = createGetAccountInfoPromise();
            $scope.getAccountInfoPromise.then(function (accountData) {
                $scope.accountInfo = accountData.data;
            });
        };

        $scope.changePassword = function (changePasswordModel) {
            $scope.changePasswordPromise = createchangePasswordPromise(changePasswordModel);
            $scope.changePasswordPromise.then(function (result) {
                if (result.data)
                    alertService.showSuccess("Password succesfullt changed");
                else {
                    alertService.showError("Confirm your new password");
                }
            })
        };

        $scope.changeUserInfo = function (userInfo) {
            $scope.changeUserInfoPromise = createChangeUserInfoPromise(userInfo);
            $scope.changeUserInfoPromise.then(function (result) {
                if (result.data)
                    alertService.showSuccess("Information succesfully changed");
                else {
                    alertService.showError("Input all fields");
                }
            })
        };

        var createChangeUserInfoPromise = function (userInfo) {
            return $q(function (resolve, reject) {
                managesService.changeUserInfo(userInfo)
                    .then(function (data) {
                        resolve(data);
                    }, function (response) {
                        console.error(response);
                        reject();
                    });
            });
        };

        var createGetUserInfoPromise = function () {
            return $q(function (resolve, reject) {
                managesService.getUserInfo()
                    .then(function (data) {
                        resolve(data);
                    }, function (response) {
                        console.error(response);
                        reject();
                    });
            });
        };

        var createGetAccountInfoPromise = function () {
            return $q(function (resolve, reject) {
                managesService.getAccountInfo()
                    .then(function (data) {
                        resolve(data);
                    }, function (response) {
                        console.error(response);
                        reject();
                    });
            });
        };

        var createchangePasswordPromise = function (changePasswordModel) {
            return $q(function (resolve, reject) {
                managesService.changePassword(changePasswordModel)
                    .then(function (data) {
                        resolve(data);
                    }, function (response) {
                        console.error(response);
                        reject();
                    });
            });
        };
    }
})();