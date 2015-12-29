app.controller("HaikuEditController", ['$scope', '$routeParams', '$window', '$uibModal', 'HaikusService', function ($scope, $routeParams, $window, $uibModal, haikusService) {
    $scope.haiku = haikusService.getChosenHaiku();
    if ($scope.haiku === undefined) {
        haikusService.getHaiku($routeParams.id)
            .then(function (httpResponse) {
                $scope.haiku = httpResponse.data;
            });
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
}]);