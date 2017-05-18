(function () {
    'use strict';

    angular
     .module('Library')
     .controller('searchController', searchController);

    searchController.$inject = ['$q', '$scope', '$http', 'searchService', 'alertService'];

    function searchController($q, $scope, $http, searchService, alertService) {
        $scope.isHomePage = true;
        $scope.isSearchResultPage = false;
        $scope.noItemsFound = false;
        $scope.books = null;
        $scope.publishers = null;
        $scope.writers = null;

        $scope.getBookDetails = function (book) {
            $scope.getBookDetailsPromise = createGetBookDetailsPromise(book.bookId);
            $scope.getBookDetailsPromise.then(function (detailedBook) {
                window.localStorage.setItem("detailedBook", JSON.stringify(detailedBook.data));
                window.location.href = 'SearchResult/BookInfo';
            })
        };

        $scope.search = function (searchText) {
            $scope.getSearchItems(searchText);
        };

        $scope.getSearchItems = function (searchText) {
            $scope.getSearchItemsPromise = createGetSearchItemsPromise(searchText);
            $scope.getSearchItemsPromise.then(function (items) {
                $scope.books = items.data.books;
                $scope.publishers = items.data.publishers;
                $scope.writers = items.data.writers;
                $scope.isHomePage = false;
                $scope.isSearchResultPage = true;
                if ($scope.books.length === 0 && $scope.publishers.length === 0 && $scope.writers.length === 0) {
                    $scope.noItemsFound = true;
                    $scope.isHomePage = false;
                    $scope.isSearchResultPage = false;
                    alertService.showWarning("No Items was found");
                }
                else {
                    alertService.showSuccess("Items was found");
                }

            });
        };

        var createGetSearchItemsPromise = function (searchText) {
            return $q(function (resolve, reject) {
                searchService.searchItems(searchText)
                    .then(function (orders) {
                        resolve(orders);
                    }, function (response) {
                        console.error("!");
                        console.error(response);
                        reject();
                    });
            });
        };

        var createGetBookDetailsPromise = function (bookId) {
            return $q(function (resolve, reject) {
                searchService.getDetailInfo(bookId)
                    .then(function (orders) {
                        resolve(orders);
                    }, function (response) {
                        console.error("!");
                        console.error(response);
                        reject();
                    });
            });
        };
    }
})();