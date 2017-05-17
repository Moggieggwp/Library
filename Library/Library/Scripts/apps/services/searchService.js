(function () {
    'use strict';

    angular
        .module('Library')
        .service('searchService', searchService);

    searchService.$inject = ['$http'];

    function searchService($http) {
        var url = "/api/Search";

        this.searchItems = function (searchText) {
            return $http.get(url + "/GetItems?partialName=" + searchText);
        };

        this.getDetailInfo = function (bookId) {
            return $http.get(url + "/GetDetailsInfo?bookId=" + bookId);
        };

        this.orderBook = function (data) {
            return $http({
                method: 'POST',
                url: url + "/OrderBook",
                data: data,
                headers: { 'Content-Type': 'application/json' }
            });
        };
    } 
})();