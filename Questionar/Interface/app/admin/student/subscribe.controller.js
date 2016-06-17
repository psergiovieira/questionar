privateModules.controller('Subscribe', ['$scope', '$http', 'dialog', '$location','$routeParams', '$rootScope' ,
  function ($scope, $http, dialog, $location, $routeParams, $rootScope) {
  	$scope.course = [];
  if ($routeParams.id !== undefined) {
  	loadCourse($routeParams.id);
  }

	function loadCourse(id) {
    	return $http({url: urlApi + 'Course/Get?id='+ id,method: 'GET'})
       .success(function(result) {
           $scope.course = result;
        }).error(function(result) {
            $scope.course = {};    
        }); 
	}

  
  
  }]);