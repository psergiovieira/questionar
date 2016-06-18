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

  $scope.subscribe = function() {
    $rootScope.spinner = {active: true}
    var data = $scope.course;

      $http({url: urlApi + 'Subscribe/Post',method: 'POST', data: angular.toJson(data) })
       .success(function(result) {             
            $rootScope.spinner = {active: false}
            dialog({message: result}); 
            $location.path('/admin/student/home.html');
        }).error(function(result) {
            $rootScope.spinner = {active: false}
            dialog({message: result.Message});       
            $location.path('/admin/student/home.html');    
        });
  }

  
  
  }]);