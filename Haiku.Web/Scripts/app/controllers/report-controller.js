﻿app.controller("ReportController", ['$scope', '$uibModalInstance', 'HaikusService', 'id', function ($scope, $uibModalInstance, haikusService, id) {
    $scope.text = '';

    $scope.report = function () {
        haikusService.sendReport(id, {
            reason: $scope.text
        });
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);