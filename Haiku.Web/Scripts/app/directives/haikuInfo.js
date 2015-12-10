app.directive("haikuInfo", function () {
    return {
        restrict: 'E',
        scope: {
            haiku: '='
        },
        templateUrl: '/Scripts/app/views/partials/haiku.html'
    };
});