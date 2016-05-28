(function() {
    'use strict';

    angular
        .module('questionar.widgets')
        .service('dialog', dialog);

    dialog.$inject = ['$uibModal'];

    function dialog($uibModal) {
        var service = function(configuracoes) {
            return $uibModal.open({
                templateUrl: 'app/widgets/widgets.dialog.html',
                controller: 'DialogController',
                windowClass: 'modal-message',
                resolve: {
                    configuracoes: function() {
                        return configuracoes;
                    }
                }
            });
        };
        return service;
    }
})();
