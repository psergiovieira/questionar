privateModules.controller('ViewCourse', ['$scope', '$http', 'dialog', '$location','$routeParams' ,
  function ($scope, $http, dialog, $location, $routeParams) {
  	$scope.course = [];
  if ($routeParams.id !== undefined) {
  	loadCourse($routeParams.id);
  }

	function loadCourse(id) {
    	return $http({url: urlApi + 'Course/Get?'+ id,method: 'GET'})
       .success(function(result) {
           $scope.course = result;
        }).error(function(result) {
            $scope.course = {};    
        }); 
	}
  
  }]);