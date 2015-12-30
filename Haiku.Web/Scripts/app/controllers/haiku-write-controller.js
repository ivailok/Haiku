app.controller("HaikuWriteController", ['$scope', '$location', 'HaikusService', function ($scope, $location, haikusService) {
    $scope.receivedResponse = false;
    $scope.responseType = '';
    $scope.responseMessage = '';

    $scope.publish = function () {
        var data = {
            text: $scope.text
        };

        var hash = CryptoJS.SHA3($scope.publishCode, { outputLength: 512 }).toString();

        haikusService.publishHaiku($scope.nickname, hash, data)
            .then(function (httpResponse) {
                $scope.receivedResponse = true;
                $scope.responseType = 'success';
                $scope.responseMessage = 'Successfully published!';
            }, function (httpResponse) {
                $scope.receivedResponse = true;
                $scope.responseMessage = httpResponse.data.message;
                $scope.responseType = 'danger';
            });
    };

    $scope.writeAnother = function () {
        $scope.text = '';
        $scope.receivedResponse = false;
        $scope.responseType = '';
        $scope.responseMessage = '';
    };
}]);