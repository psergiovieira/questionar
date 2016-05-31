var app = angular.module('questionar.app',
 [  
   'ui.bootstrap',
   'questionar.widgets',
   'ngRoute',
   'ngResource',
   'questionar.public',
   'questionar.private'
 ]);

var urlApi = 'http://localhost/Questionar.WebApi/api/';

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
        controller: 'HomeStudent'
      }).
      when('/admin/teacher/home.html', {
        templateUrl: 'app/admin/teacher/home.html',
        controller: 'HomeTeacher'
      }).
      when('/account-signin', {
        templateUrl: 'app/public/account-signin.html',
        controller: 'AccountSignIn'
      }).
      otherwise({
        redirectTo: '/home'
      });
  }]);