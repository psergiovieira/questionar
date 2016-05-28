(function() {
    'use strict';

    angular
        .module('questionar.widgets')
        .controller('DialogController', DialogController);

    DialogController.$inject = ['$scope', '$uibModalInstance', 'configuracoes'];

    /* @ngInject */
    function DialogController($scope, uibModalInstance, configuracoes) {
        $scope.message = configuracoes.message;
        $scope.buttons = {
            confirm: (configuracoes.buttons && configuracoes.buttons.confirm) ? configuracoes.buttons.confirm : 'OK',
            cancel: (configuracoes.buttons && configuracoes.buttons.cancel) ? configuracoes.buttons.cancel : 'Cancel'
        };
        $scope.isCancel = configuracoes.isCancel || false;

        $scope.close = close;
        $scope.confirm = confirm;
        $scope.cancel = cancel;

        function close() {
            uibModalInstance.dismiss('cancel');
        }

        function confirm() {
            uibModalInstance.close(true);
        }

        function cancel() {
            uibModalInstance.close(false);
        }
    }
})();
