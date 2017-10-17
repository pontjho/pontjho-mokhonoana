(function() {
    "use strict";

    angular.module('absa').controller('ListClientsController', ['$scope', 'ClientService', function($scope, clientService) {

        clientService.query()
        .$promise.then(function(clients) {
          $scope.clients = clients;
        });
    }]);
})();
