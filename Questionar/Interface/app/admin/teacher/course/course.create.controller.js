privateModules.controller('CreateCourse', ['$scope', '$http', 'dialog', '$location' ,
  function ($scope, $http, dialog, $location) {
  	$scope.course = {};
  	$scope.save = function() {	
      var data = $scope.course;
       $http({url: urlApi + 'Course/Post',method: 'POST', data: angular.toJson(data) })
       .success(function(result) {            

             dialog({message: result});  

            $location.path('/admin/teacher/home.html');
        }).error(function(result) {
            dialog({message: result.Message});           
        });  
	};
  
  }]);