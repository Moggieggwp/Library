(function () {
    'use strict';

    angular
     .module('Library')
     .controller('searchController', searchController);

    searchController.$inject = ['$q', '$scope', '$http', 'searchService', 'alertService'];

    function searchController($q, $scope, $http, searchService, alertService) {

        $scope.search = function (searchText) {
            window.sessionStorage.setItem("search", searchText);
            window.location = "/SearchResult/Index";
        };

        $scope.getSearchItems = function (car) {
            var searchText = window.sessionStorage.getItem("search");

            $scope.getSearchItemsPromise = createGetSearchItemsPromise(searchText);
            $scope.getSearchItemsPromise.then(function (orders) {
                alertService.showSuccess("Car successfuly added");
                console.log(orders.data.id);
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