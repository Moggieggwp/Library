(function () {
    'use strict';

    angular
     .module('Library')
     .controller('detailsController', detailsController);

    detailsController.$inject = ['$q', '$scope', '$http', 'searchService', 'accountService', 'alertService'];

    function detailsController($q, $scope, $http, searchService, accountService, alertService) {

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

        $scope.orderBook = function () {
            var isLogged = false;
            accountService.isLogged().then(function (result) {
                isLogged = result.data;
                if (isLogged) {
                    doOrderBook();
                    //window.location.replace("http://localhost:51620");
                }
                else {
                    window.localStorage.setItem("BookForOrder", JSON.stringify($scope.detailedBook.book.bookId));
                    window.location.href = "http://localhost:51620/Account/Login";
                }
            });
        }

        var doOrderBook = function () {
            $scope.orderBookPromise = createOrderBookPromise($scope.detailedBook.book.bookId);
            $scope.orderBookPromise.then(function (result) {
                if (result.data)
                    alertService.showSuccess("Book Successfully ordered.");
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