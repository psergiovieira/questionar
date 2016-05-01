var app = angular.module('app', ['ngRoute', 'public']);

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
      otherwise({
        redirectTo: '/home'
      });
  }]);