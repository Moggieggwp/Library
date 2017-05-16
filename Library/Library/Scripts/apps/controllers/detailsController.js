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
            $scope.detailedBook.book.issueYear = $scope.detailedBook.book.issueYear.substring(0, 10);
            for (var i = 0; i < $scope.detailedBook.writers.length; i++) {
                $scope.detailedBook.writers[i].birthDate = $scope.detailedBook.writers[i].birthDate.substring(0, 10);
            }
        }

        $scope.readOnline = function () {
            window.location.href = $scope.detailedBook.book.pathToReadOnline;
        }
    }
})();