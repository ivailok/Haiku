app.controller("AuthorizeController", ['$scope', '$location', '$uibModalInstance', 'HaikusService', 'UsersService',
function ($scope, $location, $uibModalInstance, haikusService, usersService) {
    
    $scope.publishCode = '';

    $scope.unauthorized = false;
    $scope.responseMessage = '';

    $scope.authorize = function () {
        var hash = CryptoJS.SHA3($scope.publishCode, { outputLength: 512 });

        if ($scope.authorizeType === 'DeleteSingleHaiku') {
            haikusService.deleteHaiku($scope.haiku.author, $scope.haiku.id, hash.toString())
                .then(function (httpResponse) {
                    $uibModalInstance.close();
                    $scope.onDelete();
                }, function (httpResponse) {
                    $scope.unauthorized = true;
                    $scope.responseMessage = httpResponse.data.message;
                });
        }
        else if ($scope.authorizeType === 'DeleteAllHaikus') {
            usersService.deleteHaikus($scope.user.nickname, hash.toString())
                .then(function (httpResponse) {
                    $uibModalInstance.close();
                    $scope.onDelete();
                }, function (httpResponse) {
                    $scope.unauthorized = true;
                    $scope.responseMessage = httpResponse.data.message;
                });
        }
        else if ($scope.authorizeType === 'EditHaiku') {
            var data = {
                text: $scope.haiku.text
            };
            haikusService.modifyHaiku($scope.haiku.author, $scope.haiku.id, hash.toString(), data)
                .then(function (httpResponse) {
                    $uibModalInstance.close();
                    $scope.onModified();
                }, function (httpResponse) {
                    $scope.unauthorized = true;
                    $scope.responseMessage = httpResponse.data.message;
                });
        }
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);