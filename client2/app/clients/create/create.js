(function() {
    "use strict";

    angular.module('absa').controller('CreateClientController', ['$scope', 'ClientService', '$location', function($scope, clientService, location) {

        $scope.model = {};
        
        $scope.values = [
            {name : "Select value", id : 0},
            {name : "Passport", id : 1},
            {name : "Identity book", id : 2}];

        $scope.save = function(model) {
            clientService.create({}, model)
            .$promise
            .then(function() {
                location.path('/');
            }, (reason) => console.error('Error creating user', reason));
        };
    }]);
})();
