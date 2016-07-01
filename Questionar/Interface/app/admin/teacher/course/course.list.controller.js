privateModules.controller('ListCourse', ['$scope', '$http', 'dialog', '$location', '$rootScope' ,
  function ($scope, $http, dialog, $location, $rootScope) {
  	$scope.courses = [];

	loadCourses();

	function loadCourses() {
       $rootScope.spinner = {active: true}
    	return $http({url: urlApi + 'Course/Get',method: 'GET'})
       .success(function(result) {        
           $scope.courses = result;
            $rootScope.spinner = {active: false}
        }).error(function(result) {
            $scope.courses = [];    
             $rootScope.spinner = {active: false}
        }); 
	}
  
  }]);