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
    $scope.lastKnownItems = 0;

    // initialize
    sendQuery();

    $scope.sendQuery = function () {
        sendQuery();
    };

    $scope.removeHaiku = function (index) {
        $scope.haikus.splice(index, 1);
    }

    function sendQuery () {
        haikusService.getHaikus($scope.selectedSortOption.name, $scope.selectedOrderOption.name, ($scope.currentPage - 1) * $scope.itemsPerPage, $scope.itemsPerPage)
            .then(function (httpResponse) {
                $scope.lastKnownItems = httpResponse.data.metadata.totalCount;
                $scope.haikus = httpResponse.data.results;
            });
    };
}]);