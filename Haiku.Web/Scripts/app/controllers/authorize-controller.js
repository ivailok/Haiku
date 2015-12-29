app.controller("AuthorizeController", ['$scope', '$location', '$uibModalInstance', 'HaikusService', 'UsersService',
function ($scope, $location, $uibModalInstance, haikusService, usersService) {
    
    $scope.authorize = function () {
        var hash = CryptoJS.SHA3($scope.publishCode, { outputLength: 512 });

        if ($scope.authorizeType === 'DeleteSingleHaiku') {
            haikusService.deleteHaiku($scope.haiku.author, $scope.haiku.id, hash.toString())
                .then(function (httpResponse) {
                    $scope.onDelete();
                });
        }
        else if ($scope.authorizeType === 'DeleteAllHaikus') {
            usersService.deleteHaikus($scope.user.nickname, hash.toString())
                .then(function (httpResponse) {
                    $scope.onDelete();
                });
        }
        else if ($scope.authorizeType === 'EditHaiku') {
            var data = {
                text: $scope.haiku.text
            };
            haikusService.modifyHaiku($scope.haiku.author, $scope.haiku.id, hash.toString(), data);
        }
        
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);