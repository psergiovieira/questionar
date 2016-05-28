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
        controller: 'Account'
      }).
      when('/admin/student/home.html', {
        templateUrl: 'app/admin/student/home.html',
        controller: 'HomeStudent'
      }).
      otherwise({
        redirectTo: '/home'
      });
  }]);