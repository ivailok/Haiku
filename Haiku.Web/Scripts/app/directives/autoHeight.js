app.directive("autoHeight", function () {
    return {
        restrict: 'A',
        link: function(scope, element, attrs) {
            element[0].style.height = (2 * element[0].scrollHeight < 30) ? 30 + "px" : 2 * element[0].scrollHeight + "px";
        }
    };
});