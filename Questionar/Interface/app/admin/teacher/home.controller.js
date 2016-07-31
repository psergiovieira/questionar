privateModules.controller('HomeTeacher', ['$scope', '$http', 'dialog', '$rootScope' ,
  function ($scope, $http, dialog, $rootScope) {

  
	$scope.dataCourses = {};
	loadDataCourses();

	 function loadDataCourses() {
	      $rootScope.spinner = {active: true}
	      return $http({url: urlApi + 'Home/Get',method: 'GET'})
	       .success(function(result) {  
	       if(result != null)
	          $scope.dataCourses = result;
	                      
	        $rootScope.spinner = {active: false}
	        }).error(function(result) {
	            $scope.dataCourses = null;    
	             $rootScope.spinner = {active: false}
	        }); 
	      }


  }]);