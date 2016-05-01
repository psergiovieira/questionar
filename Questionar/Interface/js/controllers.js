var publicModules = angular.module('public', []);
var urlApi = 'http://localhost/Questionar.WebApi/api/';

publicModules.controller('Home', ['$scope', '$http',
  function ($scope, $http) {

   $scope.Teste = 'teste binding...';
  }]);

publicModules.controller('Account', ['$scope', '$http',  
  function ($scope, $http) {

   $scope.user = {};
   $scope.save = function() {

   	var data = $scope.user;
   	return $http({
                url: urlApi + 'User/Post',
                method: 'POST',
                data: angular.toJson(data)
            });
  
	}
  }]);

