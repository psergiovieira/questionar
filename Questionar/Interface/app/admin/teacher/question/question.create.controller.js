privateModules.controller('CreateQuestion', ['$scope', '$http', 'dialog', '$location', '$rootScope' ,
  function ($scope, $http, dialog, $location, $rootScope) {
  	$scope.courses = [];
    $scope.question = {};
    $scope.question.Course = {};
    $scope.question.Course.Name = "Selecione";
    $scope.question.Alternatives = [];
    $scope.question.Description = undefined;

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
      $scope.question.Course = course;      
  }

  $scope.addAlternative = function(item){
        var alternativeToAdd = {
            "Order": $scope.question.Alternatives.length + 1,
            "Description": item,
            "IsCorrect": false
        };

        $scope.question.Alternatives.push(alternativeToAdd);
  }

   $scope.selectAlternative = function (alternative) { 
      alternative.IsCorrect = !alternative.IsCorrect;      
   }

   $scope.save = function () { 
       $rootScope.spinner = {active: true}
       var data = $scope.question;
       $http({url: urlApi + 'Question/Post',method: 'POST', data: angular.toJson(data) })
       .success(function(result) {            

             dialog({message: result});  
             $rootScope.spinner = {active: false}
            $location.path('/admin/teacher/home.html');
        }).error(function(result) {
            $rootScope.spinner = {active: false}
            dialog({message: result.Message});           
        });
   }

  
  }]);