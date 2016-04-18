var publicModules = angular.module('public', []);

publicModules.controller('Home', ['$scope', '$http',
  function ($scope, $http) {

   $scope.Teste = 'teste binding...';
  }]);
