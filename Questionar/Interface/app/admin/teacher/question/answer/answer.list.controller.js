privateModules.controller('ListAnswer', ['$scope', '$http', 'dialog', '$location','$routeParams', '$rootScope' ,
  function ($scope, $http, dialog, $location, $routeParams, $rootScope) {
    $scope.answers = {}
  	var idQuestion = 0;
  if ($routeParams.id !== undefined) {
  	idQuestion = $routeParams.id;
  }

  loadAnswers();
  
      function loadAnswers() {
       $rootScope.spinner = {active: true}
      return $http({url: urlApi + 'Answer/Get?idQuestion=' + idQuestion,method: 'GET'})
       .success(function(result) {        
           $scope.answers = result;
            $rootScope.spinner = {active: false}
        }).error(function(result) {
            $scope.answers = [];    
             $rootScope.spinner = {active: false}
        }); 
  }
  
  }]);