(function () {
    'use strict';

    angular
     .module('Library')
     .controller('managesController', managesController);

    managesController.$inject = ['$q', '$scope', '$http', 'managesService', 'accountService', 'alertService'];

    function managesController($q, $scope, $http, managesService, accountService, alertService) {

        $scope.areOrdersEmpty = true;
        $scope.orders = null;
        $scope.savedOrder = null;

        $scope.saveOrder = function (order) {
            $scope.savedOrder = order;
        }

        $scope.getOrdersInfo = function () {
            $scope.getOrdersInfoPromise = createGetOrdersInfoPromise();
            $scope.getOrdersInfoPromise.then(function (orders) {
                if (orders.data.length !== 0) {
                    $scope.areOrdersEmpty = false;
                    $scope.orders = orders.data;
                    for (var i = 0; i < $scope.orders.length; i++) {
                        $scope.orders[i].orderDate = $scope.orders[i].orderDate.replace("T", " ");
                        $scope.orders[i].orderDate = $scope.orders[i].orderDate.substring(0, 19);
                        $scope.orders[i].returnDate = $scope.orders[i].returnDate.replace("T", " ");
                        $scope.orders[i].returnDate = $scope.orders[i].returnDate.substring(0, 19);
                    }
                }
                else {
                    $scope.areOrdersEmpty = true;
                }
            });
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
            if (changePasswordModel.newPassword.length < 5)
                alertService.showError("Password must be more than 5 character");
            else if (!hasUpperCase(changePasswordModel.newPassword))
                alertService.showError("Password must contain a capital letters");
            else if (!hasNumber(changePasswordModel.newPassword))
                alertService.showError("Password must contain a numbers. ");
            else
                if (changePasswordModel.newPassword !== changePasswordModel.newPasswordConfirm)
                    alertService.showError("Please confirm your password");
                else {
                    $scope.changePasswordPromise = createchangePasswordPromise(changePasswordModel);
                    $scope.changePasswordPromise.then(function (result) {
                        if (result.data)
                            alertService.showSuccess("Password succesfullt changed");
                        else {
                            alertService.showError("Confirm your new password");
                        }
                    });
                }
        };

        $scope.changeUserInfo = function (userInfo) {
            if (userInfo.phoneNumber.length < 8 || isNaN(userInfo.phoneNumber))
                alertService.showError("Invalid phone number");
            else {
                $scope.changeUserInfoPromise = createChangeUserInfoPromise(userInfo);
                $scope.changeUserInfoPromise.then(function (result) {
                    if (result.data)
                        alertService.showSuccess("Information succesfully changed");
                    else {
                        alertService.showError("Input all fields");
                    }
                });
            }
        };

        function hasUpperCase(str) {
            return (/[A-Z]+/.test(str));
        }

        function hasNumber(myString) {
            return /\d/.test(myString);
        }


        $scope.deleteOrder = function () {
            $scope.deleteOrderPromise = createDeleteOrderPromise($scope.savedOrder);
            $scope.deleteOrderPromise.then(function (result) {
                if (result.data === true) {
                    $scope.getOrdersInfo();
                    alertService.showSuccess("Order successfully deleted");
                }
                else
                    alertService.showError("Order not deleted")

            });
        }

        var createDeleteOrderPromise = function (order) {
            return $q(function (resolve, reject) {
                managesService.deleteOrder(order)
                    .then(function (data) {
                        resolve(data);
                    }, function (response) {
                        console.error(response);
                        reject();
                    });
            });
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

        var createGetOrdersInfoPromise = function () {
            return $q(function (resolve, reject) {
                managesService.getOrdersInfo()
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