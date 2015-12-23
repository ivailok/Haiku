app.controller("AuthorizeController", ['$scope', '$location', '$uibModalInstance', 'HaikusService', function ($scope, $location, $uibModalInstance, haikusService) {
    
    $scope.authorize = function () {
        var hash = CryptoJS.SHA3($scope.publishCode, { outputLength: 512 });

        haikusService.deleteHaiku($scope.haiku.author, $scope.haiku.id, hash.toString())
            .then(function (httpResponse) {
                $location.path("/");
                $scope.onDelete();
            });
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);