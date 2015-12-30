app.controller("RateController", ['$scope', '$uibModalInstance', 'HaikusService', 'id', function ($scope, $uibModalInstance, haikusService, id) {
    $scope.rating = 0;

    $scope.$watch('rating', function (newValue, oldValue) {
        if (newValue === oldValue) {
            return;
        }

        var data = {
            rating: newValue,
        };
        haikusService.rateHaiku(id, data)
            .then(function (httpResponse) {
                $uibModalInstance.close(httpResponse.data.haikuRating);
            }, function (httpResponse) {
                // handle potential error here
                $uibModalInstance.close();
            });
    });

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);