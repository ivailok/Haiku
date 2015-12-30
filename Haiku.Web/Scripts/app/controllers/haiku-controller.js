/// <reference path="haiku-controller.js" />
app.controller("HaikuController", ['$scope', '$routeParams', '$location', '$uibModal', 'HaikusService', 'UsersService', function ($scope, $routeParams, $location, $uibModal, haikusService, usersService) {
    $scope.haiku = haikusService.getChosenHaiku();

    if ($scope.haiku === undefined) {
        haikusService.getHaiku($routeParams.id)
            .then(function (httpResponse) {
                $scope.haiku = httpResponse.data;
            });
    }

    $scope.selectUser = function (nickname) {
        $location.path("/users/" + nickname);
    };

    $scope.report = function () {
        $uibModal.open({
            templateUrl: '/Scripts/app/views/partials/reportForm.html',
            controller: 'ReportController',
            resolve: {
                id: function () {
                    return $scope.haiku.id;
                }
            }
        });
    };

    $scope.rate = function () {
        var modalInstance = $uibModal.open({
            templateUrl: '/Scripts/app/views/partials/rateForm.html',
            controller: 'RateController',
            resolve: {
                id: function () {
                    return $scope.haiku.id;
                }
            }
        })

        modalInstance.result.then(function (haikuRating) {
            $scope.haiku.rating = haikuRating;
            usersService.markForUpdate();
        });
    };
}]);