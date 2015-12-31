services.factory('ReportsService', ['HttpService', function (httpService) {

    var service = {
        getReports: function (skip, take, manageToken) {
            return httpService.get("reports?skip=" + skip + "&take=" + take, { 'ManageToken': manageToken });
        }
    };

    return service;
}]);