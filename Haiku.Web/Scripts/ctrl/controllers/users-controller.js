ctrl.controller("UsersController", ['$scope', '$location', '$uibModal', 'UsersService', function ($scope, $location, $uibModal, usersService) {
    $scope.dataLoaded = false;

    $scope.users = [];

    $scope.sortOptions = [
        {
            name: 'Rating'
        },
        {
            name: 'Nickname'
        }
    ];
    $scope.selectedSortOption = $scope.sortOptions[0];

    $scope.orderOptions = [
        {
            name: 'Descending'
        },
        {
            name: 'Ascending'
        }
    ];
    $scope.selectedOrderOption = $scope.orderOptions[0];

    $scope.itemsPerPage = 20;
    $scope.currentPage = 1;
    $scope.visiblePages = 5;
    $scope.lastKnownItems = 0;

    // initialize
    sendQuery();

    $scope.sendQuery = function () {
        sendQuery();
    };

    $scope.promote = function (index) {
        $uibModal.open({
            templateUrl: '/Scripts/ctrl/views/partials/authorizeForm.html',
            controller: 'AuthorizeController',
            resolve: {
                successCallback: function () {
                    return onChangeUserRole;
                },
                invoke: function () {
                    return changeUserRole(index, 'VIP');
                }
            }
        });
    }

    $scope.demote = function (index) {
        $uibModal.open({
            templateUrl: '/Scripts/ctrl/views/partials/authorizeForm.html',
            controller: 'AuthorizeController',
            resolve: {
                successCallback: function () {
                    return onChangeUserRole;
                },
                invoke: function () {
                    return changeUserRole(index, 'Author');
                }
            }
        });
    }

    $scope.delete = function (index) {
        $uibModal.open({
            templateUrl: '/Scripts/ctrl/views/partials/authorizeForm.html',
            controller: 'AuthorizeController',
            resolve: {
                successCallback: function () {
                    return onDeleteUser(index);
                },
                invoke: function () {
                    return deleteUser(index);
                }
            }
        });
    }

    function changeUserRole(index, role) {
        return function (manageToken) {
            return usersService.changeRole($scope.users[index].nickname, role, manageToken);
        }
    };

    function deleteUser(index) {
        return function (manageToken) {
            return usersService.deleteUser($scope.users[index].nickname, manageToken);
        }
    };

    function onChangeUserRole(data) {
        sendQuery();
    };

    function onDeleteUser(index) {
        return function (data) {
            $scope.users.splice(index, 1);
        }
    };

    function sendQuery() {
        $scope.dataLoaded = false;
        usersService.getUsers($scope.selectedSortOption.name, $scope.selectedOrderOption.name, ($scope.currentPage - 1) * $scope.itemsPerPage, $scope.itemsPerPage)
            .then(function (httpResponse) {
                $scope.lastKnownItems = httpResponse.data.metadata.totalCount;
                $scope.users = httpResponse.data.results;
                $scope.dataLoaded = true;
            });
    };
}]);