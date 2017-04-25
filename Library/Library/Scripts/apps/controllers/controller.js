(function () {
    'use strict';

    angular
     .module('Library')
     .controller('controller', controller);

    controller.$inject = ['$q', '$scope', '$http', 'service', 'alertService'];

    function controller($q, $scope, $http, service, alertService) {

        $scope.text = "test";

        $scope.post = function (text) {
            $scope.addCarPromise = createAddCarPromise(text);
            $scope.addCarPromise.then(function (data) {
                console.log(data)
                alertService.showSuccess("Car successfuly added");
            });
        };

        $scope.get = function () {
            return $http.get("/Default/GetBook");
        };

        $scope.getOrders = function () {
            $scope.get()
                .success(function (orders) {
                    console.log(orders);
                }).error(function myfunction() {
                    console.log("Something wrong!!!");
                });
        };

        var createAddCarPromise = function (car) {
            return $q(function (resolve, reject) {
                service
                    .post(car);
            });
        };
    }
})();