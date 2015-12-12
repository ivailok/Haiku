app.controller("HaikuWriteController", ['$scope', '$location', '$cookies', 'HaikusService', function ($scope, $location, $cookies, haikusService) {
    $scope.nickname = $cookies.get("nickname");
    if ($scope.nickname === undefined) {
        $location.path('/');
    }

    $scope.isPublished = false;

    $scope.publish = function () {
        var data = {
            text: $scope.text
        };

        var hash = CryptoJS.SHA3($scope.publishCode, { outputLength: 512 }).toString();

        haikusService.publishHaiku($scope.nickname, hash, data)
            .then(function (httpResponse) {
                $scope.isPublished = true;
            })
    };
}]);