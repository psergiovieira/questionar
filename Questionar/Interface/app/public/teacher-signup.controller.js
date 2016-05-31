publicModules.controller('TeacherSignUp', ['$scope', '$http', 'dialog', '$location' ,
  function ($scope, $http, dialog, $location) {   
  	$scope.user = {};
   $scope.save = function() {

   	var data = $scope.user;
    data.IsTeacher = true;

       $http({url: urlApi + 'User/Post',method: 'POST', data: angular.toJson(data) })
       .success(function(result) {            

             dialog({message: result});  

            $location.path('/admin/teacher/home.html');
        }).error(function(result) {
            dialog({message: result.Message});           
        });           
  
	}

  }]);