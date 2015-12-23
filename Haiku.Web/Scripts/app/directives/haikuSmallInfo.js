app.directive("haikuSmallInfo", function () {
    var controller = ['$scope', '$location', '$uibModal', 'HaikusService', function ($scope, $location, $uibModal, haikusService) {
        $scope.selectUser = function (nickname) {
            $location.path("/users/" + nickname);
        };

        $scope.selectHaiku = function (haiku) {
            haikusService.saveChosenHaiku(haiku);
            $location.path("/haikus/" + haiku.id);
        }

        $scope.deleteHaiku = function () {
            $uibModal.open({
                templateUrl: '/Scripts/app/views/partials/authorizeForm.html',
                controller: 'AuthorizeController',
                scope: $scope
            });
        }
    }];

    return {
        restrict: 'E',
        scope: {
            haiku: '=',
            showAuthor: '=',
            onDelete: '&'
        },
        templateUrl: '/Scripts/app/views/partials/haikuSmall.html',
        controller: controller
    };
});