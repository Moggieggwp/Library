(function () {
    'use strict';
    angular
        .module('Library', ['toaster', 'ngAnimate', 'cgBusy']).value('cgBusyDefaults', createBusyDefaults());


    function createBusyDefaults() {
        return {
            backdrop: true,
            delay: 0,
            minDuration: 500
        };
    }
})();