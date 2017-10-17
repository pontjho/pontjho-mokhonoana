angular.module('absa', ['ngRoute', 'ngResource'])
.config(function($routeProvider) {
   
    $routeProvider
      .when('/', {
        controller:'ListClientsController as queryClients',
        templateUrl:'app/clients/list/list.html'
      })
      .when('/edit/:clientId', {
        controller:'EditClientController as editClient',
        templateUrl:'app/clients/edit/edit.html'
      })
      .when('/view/:clientId', {
        controller:'ViewClientController as viewClient',
        templateUrl:'app/clients/view/view.html'
      })
      .when('/new', {
        controller:'CreateClientController as createClient',
        templateUrl:'app/clients/edit/edit.html'
      })
      .otherwise({
        redirectTo:'/'
      });
  });
