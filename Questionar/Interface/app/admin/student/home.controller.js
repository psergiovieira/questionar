privateModules.controller('HomeStudent', ['$scope', '$http', 'dialog','$rootScope', 
  function ($scope, $http, dialog, $rootScope) {


   
   $scope.inputSearch = '';
   $scope.courses = {};


   $scope.search = function() {
   		$rootScope.spinner = {active: true};   		
    	return $http({url: urlApi + 'Course/Get?search=' + $scope.inputSearch,method: 'GET'})
       .success(function(result) {       	
           $scope.courses = result;
           $rootScope.spinner = {active: false};
        }).error(function(result) {
            $scope.courses = [];    
            $rootScope.spinner = {active: false};
        }); 
	}
	
  }]);