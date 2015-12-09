app.factory('HaikusService', ['$http', function ($http) {
    var service = {
        getHaikus : function (sortBy, orderBy, skip, take) {
            return $http.get(serverUrl + "haikus?sortBy=" + sortBy + "&order=" + orderBy + "&skip=" + skip + "&take=" + take)
                .then(function (result) {
                    return result.data;
                },
                function (error) {
                    alert("Error: no data returned");
                });
        }
    };
    return service;
}]);