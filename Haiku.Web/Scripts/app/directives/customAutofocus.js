﻿app.directive('customAutofocus', [function () {
    return {
        restrict: 'A',
        link: function (scope, element) {
            element[0].focus();
        }
    }
}])