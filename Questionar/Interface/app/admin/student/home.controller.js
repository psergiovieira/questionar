privateModules.controller('HomeStudent', ['$scope', '$http', 'dialog','$rootScope', 
  function ($scope, $http, dialog, $rootScope) {


   
   $scope.inputSearch = '';
   $scope.courses = {};
   $scope.question = {
      "Course": {
        "Id": 0,
        "Name": "Matemática",
        "Description": "ssssssssssssssssss",
        "Created": "0001-01-01T00:00:00",
        "Teacher": null,
        "Start": "0001-01-01T00:00:00"
      },
      "Description": "O QUE é SD?",
      "Alternatives": [
        {
          "Id": 41,
          "Question": null,
          "Description": "aaaaaaaaa",
          "Order": 1,
          "IsCorrect": false
        },
        {
          "Id": 42,
          "Question": null,
          "Description": "aaaaaaaaaaaaa",
          "Order": 2,
          "IsCorrect": false
        },
        {
          "Id": 43,
          "Question": null,
          "Description": "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
          "Order": 3,
          "IsCorrect": false
        }
      ]
    };


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
	
  }]);