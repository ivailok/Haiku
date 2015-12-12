app.factory("UsersService", ['HttpService', function (httpService) {
    this.chosenUser = undefined;

    var self = this;

    var service = {
        getUsers: function (sortBy, orderBy, skip, take) {
            return httpService.get("users?sortBy=" + sortBy + "&order=" + orderBy + "&skip=" + skip + "&take=" + take);
        },

        getUser: function (nickname) {
            return httpService.get("users/" + nickname);
        },

        registerAuthor: function (data) {
            return httpService.post("users", null, data);
        },

        saveChosenUser: function (user) {
            self.chosenUser = user;
        },
        getChosenUser: function () {
            return self.chosenUser;
        }
    };

    return service;
}]);