﻿directives.directive("selectPicker", ['$timeout', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            $timeout(function () {
                element.selectpicker();
            });
        }
    };
}]);