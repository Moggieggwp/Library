(function () {
    'use strict';

    angular
     .module('Library')
     .controller('accountController', accountController);

    accountController.$inject = ['$q', '$scope', '$http', 'alertService', 'accountService', 'searchService'];

    function accountController($q, $scope, $http, alertService, accountService, searchService) {

        $scope.login = function (loginViewModel) {
            if (loginViewModel.userPassword.length < 5)
                alertService.showError("Password must be more than 5 character");
            else if (!hasUpperCase(loginViewModel.userPassword))
                alertService.showError("Password must contain a capital letters");
            else if (!hasNumber(loginViewModel.userPassword))
                alertService.showError("Password must contain a numbers. ");
            else {
                $scope.loginPromise = createLoginPromise(loginViewModel);
                $scope.loginPromise.then(function () {
                    var data = window.localStorage.getItem("BookForOrder");
                    window.localStorage.removeItem("BookForOrder");
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
            }
        };

        $scope.register = function (registerViewModel, userPasswordConfirm) {
            if (registerViewModel.userName.length < 3)
                alertService.showError("Name is too short");
            else
                if (registerViewModel.userSurname.length < 3)
                    alertService.showError("Surname is too short");
                else
                    if (registerViewModel.userPhone.length < 8 || isNaN(registerViewModel.userPhone))
                        alertService.showError("Invalid phone number");
                    else
                        if (registerViewModel.userPassword.length < 5)
                            alertService.showError("Password must be more than 5 character");
                        else if (!hasUpperCase(registerViewModel.userPassword))
                            alertService.showError("Password must contain a capital letters");
                        else if (!hasNumber(registerViewModel.userPassword))
                            alertService.showError("Password must contain a numbers. ");
                        else
                            if (registerViewModel.userPassword !== userPasswordConfirm)
                                alertService.showError("Please confirm your password");
                            else {
                                $scope.registerPromise = createRegisterPromise(registerViewModel);
                                $scope.registerPromise.then(function () {
                                    window.location.replace("http://localhost:51620");
                                    alertService.showSuccess("Successfully");
                                });
                            }
        };

        function hasUpperCase(str) {
            return (/[A-Z]+/.test(str));
        }

        function hasNumber(myString) {
            return /\d/.test(myString);
        }

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