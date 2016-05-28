publicModules.controller('AccountSignIn', ['$scope', '$http', 'dialog', '$location' ,
  function ($scope, $http, dialog, $location) {

   $scope.user = {};
   $scope.login = function() {

   	var data = $scope.user;


      $http({url: urlApi + 'User/Login',method: 'POST', data: angular.toJson(data) })
       .success(function(result) {            

             dialog({message: result});  

            $location.path('/admin/student/home.html');
        }).error(function(result) {
            dialog({message: result.Message});           
        });           
  
	}
  }]);
