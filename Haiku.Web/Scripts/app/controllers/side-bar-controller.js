app.controller("SideBarController", ['$scope', function ($scope) {
    $scope.tabs = [
        { title: 'Haikus', to: '/', img: 'commenting' },
        { title: 'Users', to: '/users', img: 'users' },
        { title: 'Join us', to: '/register', img: 'random' },
        { title: 'Write', to: '/write', img: 'pencil' }];
}]);