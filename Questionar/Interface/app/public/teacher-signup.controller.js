publicModules.controller('TeacherSignUp', ['$scope', '$http', 'dialog', '$location', '$rootScope' ,
  function ($scope, $http, dialog, $location, $rootScope) {   
  	$scope.user = {};
   $scope.save = function() {

   	var data = $scope.user;
    $rootScope.spinner = {active: true}
    data.IsTeacher = true;

       $http({url: urlApi + 'User/Post',method: 'POST', data: angular.toJson(data) })
       .success(function(result) {            
            $rootScope.spinner = {active: false}
             dialog({message: result});  

            $location.path('/admin/teacher/home.html');
        }).error(function(result) {
              $rootScope.spinner = {active: false}
              dialog({message: result.Message});           
        });           
  
	}

  }]);