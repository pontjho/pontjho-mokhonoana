(function() {
    "use strict";

    angular.module('absa').controller('CreateClientController', ['$scope', 'ClientService', '$location', function($scope, clientService, location) {

        $scope.model = {};

        $scope.save = function(model) {
            clientService.create({}, model).then(function() {
                console.log('success');
            }, (reason) => console.error('Error creating user', reason));
        };
    }]);
})();
