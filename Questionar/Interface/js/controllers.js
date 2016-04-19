var publicModules = angular.module('public', []);

publicModules.controller('Home', ['$scope', '$http',
  function ($scope, $http) {

   $scope.Teste = 'teste binding...';
  }]);

publicModules.controller('Account', ['$scope', '$http',
  function ($scope, $http) {

   $scope.user = {};
   $scope.save = function() {

   	var data = $scope.user;
   };

  }]);

