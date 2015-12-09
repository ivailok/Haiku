app.controller('HaikusController', ['$scope', 'HaikusService', function ($scope, haikusService) {
    $scope.haikus = [];

    $scope.sortOptions = [
        {
            name: 'Date'
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

    haikusService.getHaikus($scope.sortOptions[0].name, $scope.orderOptions[0].name, 0, $scope.itemsPerPage)
        .then(function (data) {
            $scope.haikus = data;
        });

    $scope.pageChanged = function () {
        haikusService.getHaikus($scope.selectedSortOption.name, $scope.selectedOrderOption.name, ($scope.currentPage - 1) * $scope.itemsPerPage, $scope.itemsPerPage)
            .then(function (data) {
                $scope.haikus = data;
            });
    };
}]);