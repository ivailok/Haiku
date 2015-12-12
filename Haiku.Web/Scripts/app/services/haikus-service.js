app.factory('HaikusService', ['HttpService', function (httpService) {
    var self = this;

    var service = {
        getHaikus: function (sortBy, orderBy, skip, take) {
            return httpService.get("haikus?sortBy=" + sortBy + "&order=" + orderBy + "&skip=" + skip + "&take=" + take);
        },

        getHaiku: function (id) {
            return httpService.get("haikus/" + id);
        },

        rateHaiku: function (id, data) {
            return httpService.post("haikus/" + id + "/ratings", {}, data);
        },

        sendReport: function (id, data) {
            return httpService.post("haikus/" + id + "/reports", {}, data);
        },

        publishHaiku: function (nickname, publishCode, data) {
            return httpService.post("users/" + nickname + "/haikus", { 'PublishCode': publishCode }, data);
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