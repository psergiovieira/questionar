privateModules.controller('CreateQuestion', ['$scope', '$http', 'dialog', '$location' ,
  function ($scope, $http, dialog, $location) {
  	$scope.courses = [];
    $scope.question = {};
    $scope.question.course = {};
    $scope.question.course.Name = "Selecione";

	loadCourses();

	function loadCourses() {
    	return $http({url: urlApi + 'Course/Get',method: 'GET'})
       .success(function(result) {
           $scope.courses = result;
        }).error(function(result) {
            $scope.courses = [];    
        }); 
	}

  $scope.courseSelected = function (course) {
 
        $scope.question.course = course;
      
  }
  
  }]);