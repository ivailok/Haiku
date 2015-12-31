ctrl.controller("AuthorizeController", ['$scope', '$location', '$uibModalInstance', 'UsersService', 'invoke', 'successCallback',
function ($scope, $location, $uibModalInstance, usersService, invoke, successCallback) {
    
    $scope.manageToken = '';

    $scope.authorize = function () {
        var hash = CryptoJS.SHA3($scope.manageToken, { outputLength: 512 });

        console.log(hash.toString());

        invoke(hash.toString())
            .then(function (httpResponse) {
                successCallback();
            });
        
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);