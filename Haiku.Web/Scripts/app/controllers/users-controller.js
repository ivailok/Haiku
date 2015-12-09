app.controller("UsersController", ['$scope', 'UsersService', function ($scope, users) {
    users.success(function (data) {
        $scope.users = data;
    });
}]);