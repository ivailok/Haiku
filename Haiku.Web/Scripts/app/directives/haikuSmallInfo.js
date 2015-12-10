app.directive("haikuSmallInfo", function () {
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
        templateUrl: '/Scripts/app/views/partials/haikuSmall.html',
        controller: controller
    };
});