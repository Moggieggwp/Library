(function () {
    'use strict';

    angular
     .module('Library')
     .controller('detailsController', detailsController);

    detailsController.$inject = ['$q', '$scope', '$http', 'searchService', 'alertService'];

    function detailsController($q, $scope, $http, searchService, alertService) {

        $scope.getDetailedInfo = function () {
            var book = window.localStorage.getItem("detailedBook");
            $scope.detailedBook = JSON.parse(book);
        }
    }
})();