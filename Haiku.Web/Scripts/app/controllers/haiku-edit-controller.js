app.controller("HaikuEditController", ['$scope', '$routeParams', '$window', '$uibModal', 'HaikusService', function ($scope, $routeParams, $window, $uibModal, haikusService) {
    $scope.dataLoaded = false;
    $scope.edited = false;

    $scope.haiku = haikusService.getChosenHaiku();
    if ($scope.haiku === undefined) {
        haikusService.getHaiku($routeParams.id)
            .then(function (httpResponse) {
                $scope.haiku = httpResponse.data;
                $scope.dataLoaded = true;
            });
    }
    else {
        $scope.dataLoaded = true;
    }

    $scope.save = function () {
        $scope.authorizeType = 'EditHaiku';
        $uibModal.open({
            templateUrl: '/Scripts/app/views/partials/authorizeForm.html',
            controller: 'AuthorizeController',
            scope: $scope
        });
    };

    $scope.cancel = function () {
        $window.history.back();
    };

    $scope.onModified = function () {
        $scope.edited = true;
    };

    $scope.closeAlert = function () {
        $scope.edited = false;
    };
}]);