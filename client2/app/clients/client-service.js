angular.module('absa').factory('ClientService', ['$resource', function($resource) {
    return $resource('http://localhost:5000/api/clients/:clientId', {clientId:'@id'},
    {
        'update': { method:'PUT' }
    });
  }]);
