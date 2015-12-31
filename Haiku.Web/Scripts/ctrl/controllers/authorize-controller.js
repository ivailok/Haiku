ctrl.controller("AuthorizeController", ['$scope', '$location', '$uibModalInstance', 'UsersService', 'invoke', 'successCallback',
function ($scope, $location, $uibModalInstance, usersService, invoke, successCallback) {
    
    $scope.manageToken = '';

    $scope.authorize = function () {
        var hash = CryptoJS.SHA3($scope.manageToken, { outputLength: 512 });

        invoke(hash.toString())
            .then(function (httpResponse) {
                successCallback(httpResponse.data);
            });
        
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);