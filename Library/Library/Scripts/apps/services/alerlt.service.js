(function () {
    'use strict';

    angular
        .module('Library')
        .service('alertService', alertService);

    alertService.$inject = ['toaster'];

    function alertService(toaster) {

        this.showWarning = function (message) {
            toaster.pop("warning", "Warning", message);
        }

        this.showSuccess = function (message) {
            toaster.pop("success", "Success", message);
        }

        this.showError = function (message) {
            toaster.pop("error", "Error", message);
        }
    }
})();