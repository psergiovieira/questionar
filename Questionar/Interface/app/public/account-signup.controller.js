publicModules.controller('AccountSignUp', ['$scope', '$http', 'dialog', '$location', '$rootScope' ,
  function ($scope, $http, dialog, $location, $rootScope) {

   $scope.user = {};
   $scope.save = function() {
    $rootScope.spinner = {active: true}
   	var data = $scope.user;
    data.IsTeacher = false;

       $http({url: urlApi + 'User/Post',method: 'POST', data: angular.toJson(data) })
       .success(function(result) {            
             $rootScope.spinner = {active: false}
             dialog({message: result});  

            $location.path('/admin/student/home.html');
        }).error(function(result) {
           $rootScope.spinner = {active: false}
            dialog({message: result.Message});           
        });           
  
	}
  }]);
