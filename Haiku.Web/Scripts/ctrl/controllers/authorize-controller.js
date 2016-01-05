ctrl.controller("AuthorizeController", ['$scope', '$location', '$uibModalInstance', 'UsersService', 'invoke', 'successCallback',
function ($scope, $location, $uibModalInstance, usersService, invoke, successCallback) {
    
    $scope.manageToken = '';

    $scope.unauthorized = false;
    $scope.responseMessage = '';

    $scope.authorize = function () {
        var hash = CryptoJS.SHA3($scope.manageToken, { outputLength: 512 });

        invoke(hash.toString())
            .then(function (httpResponse) {
                $uibModalInstance.close();
                successCallback(httpResponse.data);
            }, function (httpResponse) {
                $scope.unauthorized = true;
                $scope.responseMessage = httpResponse.data.message;
            });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);