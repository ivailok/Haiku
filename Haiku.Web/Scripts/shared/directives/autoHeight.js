﻿directives.directive('autoHeight', ['$timeout', function ($timeout) {
    return {
        restrict: 'A',
        link: function ($scope, element, attrs) {
            $scope.initialHeight = $scope.initialHeight || element[0].style.height;
            var resize = function () {
                element[0].scrollTop = element[0].scrollHeight;
                element[0].style.height = $scope.initialHeight;
                element[0].style.height = "" + element[0].scrollHeight + "px";
            };
            element.on("input change", resize);
            $timeout(resize, 0);
        }
    };
}]);