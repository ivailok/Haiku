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
        .when('/write', {
            controller: 'HaikuWriteController',
            templateUrl: '/Scripts/app/views/haikuWrite.html'
        })
        .when('/register', {
            controller: 'UserRegisterController',
            templateUrl: '/Scripts/app/views/userRegister.html'
        })
        .when('/haikus/:id/edit', {
            controller: 'HaikuEditController',
            templateUrl: '/Scripts/app/views/haikuEdit.html'
        })
        .otherwise({
            redirectTo: '/'
        });

    $locationProvider.html5Mode(true);
});