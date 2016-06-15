privateModules.controller('HomeStudent', ['$scope', '$http', 'dialog' ,
  function ($scope, $http, dialog) {
 
   $scope.inputSearch = '';
   $scope.courses = {};
   $scope.search = function() {
    	return $http({url: urlApi + 'Course/Get?search=' + $scope.inputSearch,method: 'GET'})
       .success(function(result) {
           $scope.courses = result;
        }).error(function(result) {
            $scope.courses = [];    
        }); 
	}
	
  }]);