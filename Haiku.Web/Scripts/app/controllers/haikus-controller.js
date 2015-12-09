app.controller('HaikusController', ['$scope', 'HaikusService', function ($scope, haikus) {
    haikus.success(function (data) {
        $scope.haikus = data;
    });
}]);