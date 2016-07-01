privateModules.controller('ListQuestion', ['$scope', '$http', 'dialog', '$location', '$rootScope' ,
  function ($scope, $http, dialog, $location, $rootScope) {
  	$scope.courses = [];

	loadQuestions();

	function loadQuestions() {
       $rootScope.spinner = {active: true}
    	return $http({url: urlApi + 'Question/Get',method: 'GET'})
       .success(function(result) {        
           $scope.questions = result;
            $rootScope.spinner = {active: false}
        }).error(function(result) {
            $scope.questions = [];    
             $rootScope.spinner = {active: false}
        }); 
	}
  
  }]);