app.factory('HaikusService', ['$http', function ($http) {
    return $http.get(serverUrl + "haikus?sortBy=Date&order=Descending&skip=0&take=20")
        .success(function (data) {
            return data;
        })
        .error(function (error) {
            return error;
        });
}]);