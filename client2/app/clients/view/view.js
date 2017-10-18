(function() {
    "use strict";

    angular.module('absa').controller('ViewClientController', ['$scope', 'ClientService', '$location', '$routeParams', 
    function($scope, clientService, location, routeParams) {

        clientService.get({clientId: routeParams.clientId})
            .$promise
            .then((model) => {$scope.model = model;}, (err) => console.error('Error fetching client', err));
    }]);
})();
