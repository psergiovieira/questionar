publicModules.controller('Account', ['$scope', '$http', 'dialog', '$location' ,
  function ($scope, $http, dialog, $location) {

   $scope.user = {};
   $scope.save = function() {

   	var data = $scope.user;

       $http({url: urlApi + 'User/Post',method: 'POST', data: angular.toJson(data) })
       .success(function(result) {            

             dialog({message: result});  

            $location.path('/admin/student/home.html');
        }).error(function(result) {
            dialog({message: result.Message});           
        });           
  
	}
  }]);
