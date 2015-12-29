app.directive("haikuSmallInfo", function () {
    var controller = ['$scope', '$location', '$uibModal', 'HaikusService', 'UsersService', function ($scope, $location, $uibModal, haikusService, usersService) {
        $scope.selectUser = function (nickname) {
            usersService.saveChosenUser(undefined);
            $location.path("/users/" + nickname);
        };

        $scope.selectHaiku = function (haiku) {
            haikusService.saveChosenHaiku(haiku);
            $location.path("/haikus/" + haiku.id);
        }

        $scope.deleteHaiku = function () {
            $scope.authorizeType = 'DeleteSingleHaiku';
            $uibModal.open({
                templateUrl: '/Scripts/app/views/partials/authorizeForm.html',
                controller: 'AuthorizeController',
                scope: $scope
            });
        }

        $scope.editHaiku = function () {
            haikusService.saveChosenHaiku($scope.haiku);
            $location.path("/haikus/" + $scope.haiku.id + "/edit")
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