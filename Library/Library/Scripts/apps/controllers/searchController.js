(function () {
    'use strict';

    angular
     .module('Library')
     .controller('searchController', searchController);

    searchController.$inject = ['$q', '$scope', '$http', 'searchService', 'alertService'];

    function searchController($q, $scope, $http, searchService, alertService) {
        $scope.isHomePage = true;
        $scope.isSearchResultPage = false;
        $scope.books = null;
        $scope.publishers = null;
        $scope.writers = null;
        $scope.imageName = "test.jpg";


        $scope.search = function (searchText) {
            $scope.isHomePage = false;
            $scope.isSearchResultPage = true;
            $scope.getSearchItems(searchText);
        };

        $scope.getSearchItems = function (searchText) {
            $scope.getSearchItemsPromise = createGetSearchItemsPromise(searchText);
            $scope.getSearchItemsPromise.then(function (items) {
                $scope.books = items.data.books;
                $scope.publishers = items.data.publishers;
                $scope.writers = items.data.writers;


                alertService.showSuccess("Items found");
            });
        };

        var createGetSearchItemsPromise = function (searchText) {
            return $q(function (resolve, reject) {
                searchService.searchItems(searchText)
                    .then(function (orders) {
                        resolve(orders);
                    }, function (response) {
                        console.error("Adding car error!");
                        console.error(response);
                        reject();
                    });
            });
        };
    }
})();