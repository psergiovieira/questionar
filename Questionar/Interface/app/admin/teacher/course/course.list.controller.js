privateModules.controller('ListCourse', ['$scope', '$http', 'dialog', '$location' ,
  function ($scope, $http, dialog, $location) {
  	$scope.courses = [];

	loadCourses();

	function loadCourses() {
    	return $http({url: urlApi + 'Course/Get',method: 'GET'})
       .success(function(result) {
           $scope.courses = result;
        }).error(function(result) {
            $scope.courses = [];    
        }); 
	}
  
  }]);