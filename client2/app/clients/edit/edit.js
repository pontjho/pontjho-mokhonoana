(function() {
    "use strict";

    angular.module('absa').controller('EditClientController', ['$scope', 'ClientService', '$location', '$routeParams', 
    function($scope, clientService, location, routeParams) {

        console.log(routeParams);
        clientService.get({clientId: routeParams.clientId})
            .$promise
            .then((model) => {$scope.model = model;}, (err) => console.error('Error fetching client', err));

        $scope.save = function(model) {
            clientService.update({clientId: routeParams.clientId}, model)
            .$promise
            .then(function() {
                location.path('/');
            }, (reason) => console.error('Error creating user', reason));
        };
    }]);
})();
