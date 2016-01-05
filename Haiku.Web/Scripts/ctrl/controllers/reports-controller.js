ctrl.controller("ReportsController", ['$scope', '$window', '$uibModal', 'ReportsService', 'HaikusService', function ($scope, $window, $uibModal, reportsService, haikusService) {
    $scope.dataLoaded = false;
    
    $scope.reports = [];
    $scope.itemsPerPage = 20;
    $scope.currentPage = 1;
    $scope.visiblePages = 5;
    $scope.lastKnownItems = 0;

    sendQuery();

    function getReports (manageToken) {
        return reportsService.getReports(($scope.currentPage - 1) * $scope.itemsPerPage, $scope.itemsPerPage, manageToken);
    }

    function onGetReports (data) {
        $scope.reports = data;
        $scope.dataLoaded = true;
    }

    function sendQuery() {
        $scope.dataLoaded = false;
        $uibModal.open({
            templateUrl: '/Scripts/ctrl/views/partials/authorizeForm.html',
            controller: 'AuthorizeController',
            resolve: {
                successCallback: function () {
                    return onGetReports;
                },
                invoke: function () {
                    return getReports;
                }
            }
        });
    };

    $scope.sendQuery = function () {
        sendQuery();
    };

    $scope.viewHaiku = function (index) {
        $window.open('/haikus/' + $scope.reports[index].haikuId, '_blank');
    };

    $scope.deleteHaiku = function (index) {
        $uibModal.open({
            templateUrl: '/Scripts/ctrl/views/partials/authorizeForm.html',
            controller: 'AuthorizeController',
            resolve: {
                successCallback: function () {
                    return onDeleteHaiku(index);
                },
                invoke: function () {
                    return deleteHaiku(index);
                }
            }
        });
    };

    function deleteHaiku(index) {
        return function (manageToken) {
            return haikusService.deleteHaikuAdmin($scope.reports[index].haikuId, manageToken);
        }
    };

    function onDeleteHaiku(index) {
        return function (data) {
            $scope.reports.splice(index, 1);
        }
    }
}])