ctrl.controller("SideBarController", ['$scope', function ($scope) {
    $scope.tabs = [
        { title: 'Users', to: '/manage/users', img: 'users' },
        { title: 'Reports', to: '/manage/reports', img: 'archive' }]
}]);