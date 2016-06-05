privateModules.controller('CreateCourse', ['$scope', '$http', 'dialog' ,
  function ($scope, $http, dialog) {
  	$scope.course = {};
  	$scope.save = function() {
	/*

       $http({url: urlApi + 'User/Post',method: 'POST', data: angular.toJson(data) })
       .success(function(result) {            

             dialog({message: result});  

            $location.path('/admin/student/home.html');
        }).error(function(result) {
            dialog({message: result.Message});           
        });  */
	};
  
  }]);