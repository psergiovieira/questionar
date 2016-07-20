privateModules.controller('HomeStudent', ['$scope', '$http', 'dialog','$rootScope', 
  function ($scope, $http, dialog, $rootScope) {


   
   $scope.inputSearch = '';
   $scope.courses = {};
   $scope.newQuestion = false;
   $scope.answer = null;
   loadQuestion();   


    function loadQuestion() {
       $rootScope.spinner = {active: true}
      return $http({url: urlApi + 'UserQuestion/Get',method: 'GET'})
       .success(function(result) {  
       if(result != null){
          $scope.question = result;
          $scope.newQuestion = true;
       }      
                      
        $rootScope.spinner = {active: false}
        }).error(function(result) {
            $scope.question = null;    
             $rootScope.spinner = {active: false}
        }); 
      }


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

  $scope.reply = function(){
    alert($scope.answer.Description);
  }

   $scope.selectAnswer = function (alternative) { 
      $scope.answer = alternative;      
   }
	
  }]);