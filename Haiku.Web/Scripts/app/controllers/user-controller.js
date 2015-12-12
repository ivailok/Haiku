app.controller("UserController", ['$scope', '$routeParams', 'UsersService', function ($scope, $routeParams, usersService) {
    $scope.user = usersService.getChosenUser();

    if ($scope.user == undefined) {
        usersService.getUser($routeParams.nickname)
            .then(function (httpResponse) {
                $scope.user = httpResponse.data;
            });
    }
}]);