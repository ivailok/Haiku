app.factory("UsersService", ['$http', function ($http) {
    var chosenUser;

    var service = {
        getUsers: function (sortBy, orderBy, skip, take) {
            return $http.get(serverUrl + "users?sortBy=" + sortBy + "&order=" + orderBy + "&skip=" + skip + "&take=" + take)
                .then(function (result) {
                    return result.data;
                },
                function (error) {
                    alert(error.message);
                });
        },
        getUser: function (nickname) {
            return $http.get(serverUrl + "users/" + nickname)
                .then(function (result) {
                    return result.data;
                },
                function (error) {
                    alert(error.message)
                });
        },
        saveChosenUser: function (user) {
            chosenUser = user;
        },
        getChosenUser: function () {
            return chosenUser;
        }
    };

    return service;
}]);