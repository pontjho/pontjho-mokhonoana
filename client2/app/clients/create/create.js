(function() {
    "use strict";

    angular.module('absa').controller('CreateClientController', ['$scope', 'ClientService', '$location', function($scope, clientService, location) {

        $scope.model = {};

        $scope.save = function(model) {
            clientService.save({}, clientService).then(function() {
                
            });
        };
    }]);
})();
