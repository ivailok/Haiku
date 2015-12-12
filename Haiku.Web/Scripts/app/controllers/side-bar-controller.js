app.controller("SideBarController", ['$scope', '$location', '$cookies', function ($scope, $location, $cookies) {
    var nickname = $cookies.get("nickname");

    $scope.tabs = [{ title: 'Haikus', to: '/' }, { title: 'Users', to: '/users' }, { } ];

    composeDynamicTabs(nickname);

    $scope.$on('nickname', function (ev, args) {
        nickname = args.nickname;
        composeDynamicTabs(nickname);
    });

    function composeDynamicTabs (nickname) {
        if (nickname === undefined) {
            $scope.tabs[2].title = 'Join us';
            $scope.tabs[2].to = "/register"
        }
        else {
            $scope.tabs[2].title = 'Write';
            $scope.tabs[2].to = "/write"
        }
    }
}]);