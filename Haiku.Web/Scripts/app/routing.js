app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/', {
            controller: 'HaikusController',
            templateUrl: '/Scripts/app/views/haikus.html'
        })
        .when('/users', {
            controller: 'UsersController',
            templateUrl: '/Scripts/app/views/users.html'
        })
        .otherwise({
            redirectTo: '/'
        });

    $locationProvider.html5Mode(true);
});