var app = angular.module('questionar.app',
 [  
   'ui.bootstrap',
   'questionar.widgets',
   'treasure-overlay-spinner',
   'ngRoute',
   'ngResource',
   'questionar.public',
   'questionar.private'
 ]);

var urlApi = 'http://localhost/Questionar.WebApi/api/';
angular.module('questionar.app').run(Run);
Run.$inject = ['$rootScope', '$http', '$location'];
function Run($rootScope, $http, $location) {        
        var history = [];

        $rootScope.isAuthenticate = false;
        $rootScope.clear = function() {
            $rootScope.isAuthenticate = false;
            $rootScope.user = undefined;
            $rootScope.type = undefined;
            sessionStorage["accessToken"] = undefined;
            localStorage["accessToken"] = undefined;
            $location.path("/account-signin")
        };



        var studentInfo = function() {
            $http.get(urlApi + 'User/UserInfo').success(function(data) {
                $rootScope.isAuthenticate = true;
                $rootScope.user = data;
                $rootScope.type = data.type;
                $rootScope.initial = data.numberCourse == 0;
                if(data.IsTeacher)
                  $rootScope.clear();
            }).error(function(data) {
                $rootScope.clear();
            });
        };

        var teacherInfo = function() {
            $http.get(urlApi + 'User/UserInfo').success(function(data) {
                $rootScope.isAuthenticate = true;
                $rootScope.user = data;
                $rootScope.type = data.type;
                $rootScope.initial = data.numberCourse == 0;
                if(!data.IsTeacher)
                  $rootScope.clear();

            }).error(function(data) {
                $rootScope.clear();
            });
        };

        $rootScope.logout = function() {
            $http({url: urlApi + 'User/LogOut',method: 'POST'}).success(function(resposta) {  

                $rootScope.clear();              
                $location.path('/#');
                
            }).error(function() {
                $rootScope.clear();
            });
        };

        $rootScope.$on('$routeChangeSuccess', function(next, current, previous) {
          history.push($location.$$path);
          $rootScope.spinner = {active: false};
            if (current.$$route) {
                $rootScope.title = current.$$route.title;
                if (current.$$route.authenticateStudent) {
                    studentInfo();
                }
                if (current.$$route.authenticateTeacher) {
                    teacherInfo();
                }
            }
        });

         $rootScope.back = function () {
            var prevUrl = history.length > 1 ? history.splice(-2)[0] : "/";
            $location.path(prevUrl);
         };

        $rootScope.$on('$routeChangeStart', function() {
            $rootScope.spinner = {active: true};
        });
    
        $rootScope.$on('$routeChangeError', function() {
          $scope.isViewLoading = false;
        });
    }

app.config(['$routeProvider',
  function($routeProvider) {
    $routeProvider.
      when('/home', {
        templateUrl: 'app/public/landing.html',
        controller: 'Home'        
      }).
      when('/account-signup', {
        templateUrl: 'app/public/account-signup.html',
        controller: 'AccountSignUp'
      }).
      when('/teacher-signup', {
        templateUrl: 'app/public/teacher-signup.html',
        controller: 'TeacherSignUp'
      }).
      when('/admin/student/home.html', {
        templateUrl: 'app/admin/student/home.html',
        controller: 'HomeStudent',
        authenticateStudent: true       
      }).
      when('/admin/student/subscribe/:id', {
        templateUrl: 'app/admin/student/subscribe.html',
        controller: 'Subscribe',
        authenticateStudent: true       
      }).
      when('/admin/teacher/home.html', {
        templateUrl: 'app/admin/teacher/home.html',
        controller: 'HomeTeacher',
        authenticateTeacher: true        
      }).
      when('/account-signin', {
        templateUrl: 'app/public/account-signin.html',
        controller: 'AccountSignIn'
      }).
      when('/admin/teacher/course', {
        templateUrl: 'app/admin/teacher/course/course.create.html',
        controller: 'CreateCourse',
        authenticateTeacher: true   
      }).
       when('/admin/teacher/course/list', {
        templateUrl: 'app/admin/teacher/course/course.list.html',
        controller: 'ListCourse',
        authenticateTeacher: true         
      }).
       when('/admin/teacher/course/view/:id', {
        templateUrl: 'app/admin/teacher/course/course.view.html',
        controller: 'ViewCourse',
        authenticateTeacher: true   
      }).
       when('/admin/teacher/question/create', {
        templateUrl: 'app/admin/teacher/question/question.create.html',
        controller: 'CreateQuestion',
        authenticateTeacher: true         
      }).
       when('/admin/teacher/question/list', {
       templateUrl: 'app/admin/teacher/question/question.list.html',
       controller: 'ListQuestion',
       authenticateTeacher: true         
      }).
        when('/admin/teacher/question/answer/list/:id', {
        templateUrl: 'app/admin/teacher/question/answer/answer.list.html',
        controller: 'ListAnswer',
        authenticateTeacher: true   
      }).
      otherwise({
        redirectTo: '/home'
      });
  }]);