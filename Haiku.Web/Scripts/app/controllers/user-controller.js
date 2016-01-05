app.controller("UserController", ['$scope', '$routeParams', '$uibModal', 'UsersService', function ($scope, $routeParams, $uibModal, usersService) {
    $scope.dataLoaded = false;

    $scope.user = usersService.getChosenUser();

    if ($scope.user == undefined) {
        usersService.getUser($routeParams.nickname)
            .then(function (httpResponse) {
                $scope.user = httpResponse.data;
                $scope.dataLoaded = true;
            });
    }
    else {
        $scope.dataLoaded = true;
    }

    $scope.onDelete = function () {
        $scope.user.haikus = [];
        $scope.user.rating = null;
    }

    $scope.removeHaiku = function (index) {
        $scope.user.haikus.splice(index, 1);
    }

    $scope.deleteAllHaikus = function () {
        $scope.authorizeType = 'DeleteAllHaikus';
        $uibModal.open({
            templateUrl: '/Scripts/app/views/partials/authorizeForm.html',
            controller: 'AuthorizeController',
            scope: $scope
        });
    }
}]);