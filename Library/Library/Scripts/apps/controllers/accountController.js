(function () {
    'use strict';

    angular
     .module('Library')
     .controller('accountController', accountController);

    accountController.$inject = ['$q', '$scope', '$http', 'alertService', 'accountService', 'searchService'];

    function accountController($q, $scope, $http, alertService, accountService, searchService) {

        $scope.login = function (loginViewModel) {
            $scope.loginPromise = createLoginPromise(loginViewModel);
            $scope.loginPromise.then(function () {
                var data = window.localStorage.getItem("BookForOrder");
                alertService.showSuccess("Successfully logged");
                if (data === null) {
                    window.location.replace("http://localhost:51620");
                }
                else {
                    var bookId = JSON.parse(data);
                    doOrderBook(bookId);
                    window.location.replace("http://localhost:51620");
                }
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
                        alertService.showError("This user is not exist");
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
                        alertService.showError("This user is not exist");
                        console.error("Login error");
                        console.error(response);
                        reject();
                    });
            });
        };

        var doOrderBook = function (bookId) {
            $scope.orderBookPromise = createOrderBookPromise(bookId);
            $scope.orderBookPromise.then(function (result) {
                if (result.data) {
                    alertService.showSuccess("Book Successfully ordered.");
                    window.localStorage.removeItem("BookForOrder");
                }
                else {
                    alertService.showError("Something was wrong(")
                }
            })
        }

        var createOrderBookPromise = function (bookId) {
            return $q(function (resolve, reject) {
                searchService.orderBook(bookId)
                    .then(function (result) {
                        resolve(result);
                    }, function (response) {
                        console.error("!");
                        console.error(response);
                        reject();
                    });
            });
        };
    }
})();