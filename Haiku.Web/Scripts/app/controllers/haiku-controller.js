app.controller("HaikuController", ['$scope', '$routeParams', '$location', '$uibModal', 'HaikusService', function ($scope, $routeParams, $location, $uibModal, haikusService) {
    $scope.haiku = haikusService.getChosenHaiku();

    if ($scope.haiku === undefined) {
        haikusService.getHaiku($routeParams.id)
            .then(function (httpResponse) {
                $scope.haiku = httpResponse.data;
            });
    }

    $scope.myRating = 0;

    $scope.$watch('myRating', function (newValue, oldValue) {
        if (newValue === oldValue) {
            return;
        }

        var data = {
            rating: newValue,
        };
        haikusService.rateHaiku($scope.haiku.id, data)
            .then(function (httpResponse) {
                $scope.haiku.rating = httpResponse.data.haikuRating;
            });
    });

    $scope.selectUser = function (nickname) {
        $location.path("/users/" + nickname);
    };

    $scope.report = function () {
        $uibModal.open({
            templateUrl: '/Scripts/app/views/partials/reportForm.html',
            controller: 'ReportController',
            resolve: {
                id: function () {
                    return $scope.haiku.id
                }
            }
        });
    };
}]);