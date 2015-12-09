app.controller("UsersController", ['$scope', '$location', 'UsersService', function ($scope, $location, usersService) {
    $scope.users = [];

    $scope.sortOptions = [
        {
            name: 'Nickname'
        },
        {
            name: 'Rating'
        }
    ];
    $scope.selectedSortOption = $scope.sortOptions[0];

    $scope.orderOptions = [
        {
            name: 'Ascending'
        },
        {
            name: 'Descending'
        }
    ];
    $scope.selectedOrderOption = $scope.orderOptions[0];

    $scope.itemsPerPage = 20;
    $scope.currentPage = 1;
    $scope.visiblePages = 5;
    $scope.lastKnownItems = $scope.visiblePages * $scope.itemsPerPage;

    usersService.getUsers($scope.sortOptions[0].name, $scope.orderOptions[0].name, 0, $scope.itemsPerPage)
        .then(function (data) {
            $scope.users = data;
        });

    $scope.pageChanged = function () {
        usersService.getUsers($scope.selectedSortOption.name, $scope.selectedOrderOption.name, ($scope.currentPage - 1) * $scope.itemsPerPage, $scope.itemsPerPage)
            .then(function (data) {
                $scope.users = data;
            });
    };

    $scope.selectUser = function (index) {
        usersService.saveChosenUser($scope.users[index]);
        $location.path("/users/" + $scope.users[index].nickname);
    };
}]);