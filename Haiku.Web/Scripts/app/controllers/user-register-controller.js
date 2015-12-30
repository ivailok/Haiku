app.controller("UserRegisterController", ['$scope', 'UsersService', function ($scope, usersService) {

    $scope.receivedResponse = false;
    $scope.responseType = '';
    $scope.responseMessage = '';

    $scope.register = function () {
        var hash = CryptoJS.SHA3($scope.publishCode, { outputLength: 512 });

        var data = {
            nickname: $scope.nickname,
            publishCode: hash.toString()
        };

        usersService.registerAuthor(data)
            .then(function (httpResponse) {
                $scope.receivedResponse = true;
                $scope.responseType = 'success';
                $scope.responseMessage = 'Successfully registered!';
            }, function (httpResponse) {
                $scope.receivedResponse = true;
                $scope.responseType = 'danger';
                $scope.responseMessage = httpResponse.data.message;
            });
    };
}]);