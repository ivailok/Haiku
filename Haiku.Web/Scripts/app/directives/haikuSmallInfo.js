app.directive("haikuSmallInfo", function () {
    var controller = ['$scope', '$location', 'HaikusService', function ($scope, $location, haikusService) {
        $scope.selectUser = function (nickname) {
            $location.path("/users/" + nickname);
        };

        $scope.selectHaiku = function (haiku) {
            haikusService.saveChosenHaiku(haiku);
            $location.path("/haikus/" + haiku.id);
        }
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