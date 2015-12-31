ctrl.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/manage', {
            controller: 'UsersController',
            templateUrl: '/Scripts/ctrl/views/users.html'
        })
        .when('/manage/users', {
            controller: 'UsersController',
            templateUrl: '/Scripts/ctrl/views/users.html'
        })
        .when('/manage/reports', {
            controller: 'ReportsController',
            templateUrl: '/Scripts/ctrl/views/reports.html'
        })
        .otherwise({
            redirectTo: '/manage'
        });

    $locationProvider.html5Mode(true);
});