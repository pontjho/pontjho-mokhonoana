(function() {
    "use strict";

    angular.module('absa').controller('CreateClientController', ['$scope', 'ClientService', '$location', function($scope, clientService, location) {

        $scope.model = {};

        $scope.save = function(model) {
            clientService.create({}, model)
            .$promise
            .then(function() {
                location.path('/');
            }, (reason) => console.error('Error creating user', reason));
        };
    }]);
})();
