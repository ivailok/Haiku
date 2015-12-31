services.factory("UsersService", ['HttpService', function (httpService) {
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

        deleteHaikus: function (nickname, publishCode) {
            return httpService.delete("users/" + nickname + "/haikus", { PublishCode: publishCode });
        },

        changeRole: function (nickname, role, manageToken) {
            return httpService.put("users/" + nickname + "?role=" + role, { ManageToken: manageToken });
        },

        deleteUser: function (nickname, manageToken) {
            return httpService.delete("users/" + nickname, { ManageToken: manageToken });
        },

        saveChosenUser: function (user) {
            self.chosenUser = user;
        },

        getChosenUser: function () {
            return self.chosenUser;
        },

        markForUpdate: function () {
            self.chosenUser = undefined;
        }
    };

    return service;
}]);