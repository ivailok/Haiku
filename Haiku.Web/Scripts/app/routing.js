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
        .when('/users/:nickname', {
            controller: 'UserController',
            templateUrl: '/Scripts/app/views/user.html'
        })
        .when('/haikus/:id', {
            controller: 'HaikuController',
            templateUrl: '/Scripts/app/views/haikuDetails.html'
        })
        .otherwise({
            redirectTo: '/'
        });

    $locationProvider.html5Mode(true);
});