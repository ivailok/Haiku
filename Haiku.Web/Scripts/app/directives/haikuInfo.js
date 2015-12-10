app.directive("haikuInfo", function () {
    var controller = ['$scope', '$location', function ($scope, $location) {
        $scope.selectUser = function (nickname) {
            $location.path("/users/" + nickname);
        };
    }];

    return {
        restrict: 'E',
        scope: {
            haiku: '=',
            showAuthor: '='
        },
        templateUrl: '/Scripts/app/views/partials/haiku.html',
        controller: controller
    };
});