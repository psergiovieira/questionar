publicModules.controller('AccountSignIn', ['$scope', '$http', 'dialog', '$location' ,'$rootScope',
  function ($scope, $http, dialog, $location, $rootScope) {

   $scope.user = {};
   $scope.login = function() {
    $rootScope.spinner = {active: true}
   	var data = $scope.user;

      $http({url: urlApi + 'User/Login',method: 'POST', data: angular.toJson(data) })
       .success(function(result) {     
            $rootScope.spinner = {active: false}

             //dialog({message: "Usuário autenticado com sucesso"});  

            if(result.IsTeacher) 
              $location.path('/admin/teacher/home.html');
            else
              $location.path('/admin/student/home.html');
        }).error(function(result) {
            $rootScope.spinner = {active: false}
            dialog({message: result.Message});           
        });
	}

  }]);
