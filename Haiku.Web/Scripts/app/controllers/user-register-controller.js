app.controller("UserRegisterController", ['$scope', 'UsersService', function ($scope, usersService) {

    $scope.isRegistered = false;

    $scope.register = function () {
        var hash = CryptoJS.SHA3($scope.publishCode, { outputLength: 512 });

        var data = {
            nickname: $scope.nickname,
            publishCode: hash.toString()
        };

        usersService.registerAuthor(data)
            .then(function (data) {
                $scope.isRegistered = true;
            }, function (error) {
                console.log(error);
            });
    };
}]);