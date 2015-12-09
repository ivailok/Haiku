app.factory("UsersService", ['$http', function ($http) {
    return $http.get(serverUrl + "users?sortBy=Rating&order=Descending&skip=0&take=10")
        .success(function (data) {
            return data;
        })
        .error(function (error) {
            return error;
        });
}]);