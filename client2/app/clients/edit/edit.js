(function() {
    "use strict";

    angular.module('absa').controller('EditClientController', ['$scope', 'ClientService', '$location', '$routeParams', 
    function($scope, clientService, location, routeParams) {

        $scope.values = [
            {name : "Select value", id : 0},
            {name : "Passport", id : 1},
            {name : "Identity book", id : 2}];

        clientService.get({clientId: routeParams.clientId})
            .$promise
            .then((model) => {
                model.dateOfBirth = new Date(model.dateOfBirth);
                $scope.model = model;
            }, (err) => console.error('Error fetching client', err));

        $scope.save = function(model) {
            clientService.update({clientId: routeParams.clientId}, model)
            .$promise
            .then(function() {
                location.path('/');
            }, (reason) => console.error('Error creating user', reason));
        };
    }]);
})();
