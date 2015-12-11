app.factory("HttpService", ['$http', function ($http) {
    var serverUrl = "http://localhost:2950/api/";
    
    function attachThenBehaviour (fn)
    {
        return fn.then(function (response) {
            return response.data;
        }, function (errorResponse) {
            alert(errorResponse.data.message);
        });
    }

    var service = {
        post: function (resourceUrl, data) {
            var fn = $http.post(serverUrl + resourceUrl, data);
            return attachThenBehaviour(fn);
        },

        get: function (resourceUrl) {
            var fn = $http.get(serverUrl + resourceUrl);
            return attachThenBehaviour(fn);
        },

        put: function (resourseUrl, data) {
            var fn = $http.put(serverUrl + resourseUrl, data);
            return attachThenBehaviour(fn);
        },

        delete: function (resourseUrl) {
            var fn = $http.delete(serverUrl + resourseUrl);
            return attachThenBehaviour(fn);
        }
    };

    return service;
}]);