app.factory('HaikusService', ['$http', function ($http) {
    var self = this;

    var service = {
        getHaikus: function (sortBy, orderBy, skip, take) {
            return $http.get(serverUrl + "haikus?sortBy=" + sortBy + "&order=" + orderBy + "&skip=" + skip + "&take=" + take)
                .then(function (result) {
                    return result.data;
                }, function (error) {
                    alert("Error: no data returned");
                });
        },

        getHaiku: function (id) {
            return $http.get(serverUrl + "haikus/" + id)
                .then(function (result) {
                    return result.data;
                }, function (error) {
                    alert("Error: no data returned");
                });
        },

        rateHaiku: function (id, data) {
            return $http.post(serverUrl + "haikus/" + id + "/ratings", data)
                .then(function (result) {
                    return result.data;
                }, function (error) {
                    alert("Error: no data returned");
                });
        },

        sendReport: function (id, data) {
            return $http.post(serverUrl + "haikus/" + id + "/reports", data)
                .then(function (result) {
                    return result.data;
                }, function (error) {
                    alert("Error: no data returned");
                });
        },

        saveChosenHaiku: function (haiku) {
            self.chosenHaiku = haiku;
        },

        getChosenHaiku: function () {
            return self.chosenHaiku;
        }
    };
    return service;
}]);