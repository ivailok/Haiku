app.controller("UserRegisterController", ['$scope', '$location', '$cookies', '$rootScope', 'UsersService', function ($scope, $location, $cookies, $rootScope, usersService) {
    if ($cookies.get('nickname') !== undefined) {
        $location.path('/');
    }
    
    $scope.isRegistered = false;

    $scope.register = function () {
        var hash = CryptoJS.SHA3($scope.publishCode, { outputLength: 512 });

        var data = {
            nickname: $scope.nickname,
            publishCode: hash.toString()
        };

        usersService.registerAuthor(data)
            .then(function (data) {
                // this will set the expiration to 12 months
                var now = new Date();
                var exp = new Date(now.getFullYear() + 1, now.getMonth(), now.getDate());
                $cookies.put('nickname', $scope.nickname, { expires: exp });

                $scope.isRegistered = true;

                $rootScope.$broadcast('nickname', { nickname: $scope.nickname });
            }, function (error) {
                console.log(error);
            });
    };
}]);