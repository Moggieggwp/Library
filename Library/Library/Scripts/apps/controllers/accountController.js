(function () {
    'use strict';

    angular
     .module('Library')
     .controller('accountController', accountController);

    accountController.$inject = ['$q', '$scope', '$http', 'alertService', 'accountService'];

    function accountController($q, $scope, $http, alertService, accountService) {

        $scope.login = function (loginViewModel) {
            $scope.loginPromise = createLoginPromise(loginViewModel);
            $scope.loginPromise.then(function () {
                var data = window.localStorage.getItem("order");
                if (data === null)
                    window.location.replace("http://localhost:51620");
                alertService.showSuccess("Successfully");
            });
        };

        $scope.register = function (registerViewModel, userPasswordConfirm) {
            if (registerViewModel.userPassword === userPasswordConfirm) {
                $scope.registerPromise = createRegisterPromise(registerViewModel);
                $scope.registerPromise.then(function () {
                    window.location.replace("http://localhost:51620");
                    alertService.showSuccess("Successfully");
                });
            }
        };

        var createLoginPromise = function (loginViewModel) {
            return $q(function (resolve, reject) {
                accountService.login(loginViewModel)
                    .then(function (data) {
                        resolve(data);
                    }, function (response) {
                        console.error("Login error");
                        console.error(response);
                        reject();
                    });
            });
        };

        var createRegisterPromise = function (registerViewModel) {
            return $q(function (resolve, reject) {
                accountService.register(registerViewModel)
                    .then(function (data) {
                        resolve(data);
                    }, function (response) {
                        console.error("Login error");
                        console.error(response);
                        reject();
                    });
            });
        };
    }
})();