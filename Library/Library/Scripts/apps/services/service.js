(function () {
    'use strict';

    angular
        .module('Library')
        .service('service', service);

    service.$inject = ['$http'];

    function service($http) {
        var url = "/api/Default";

        this.post = function (data) {
            return $http({
                method: 'POST',
                url: url + "/Post1",
                data: JSON.stringify(data),
                headers: { 'Content-Type': 'application/json' }
            });
        };

        this.get = function () {
            return $http.get(url + "/Get1");
        };
    }
})();