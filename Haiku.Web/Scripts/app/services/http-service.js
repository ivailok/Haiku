app.factory("HttpService", ['$http', function ($http) {
    var serverUrl = "http://localhost:2950/api/";
    
    function request (method, url, headers, data)
    {
        if (headers === undefined || headers === null) {
            headers = {};
        }

        headers['Content-Type'] = 'application/json';
        headers['Accept'] = 'application/json';

        var req = {
            method: method,
            url: serverUrl + url,
            headers: headers,
            data: data
        };

        return $http(req);
    }

    var service = {
        post: function (resourceUrl, headers, data) {
            return request('Post', resourceUrl, headers, data);
        },

        get: function (resourceUrl) {
            return request('Get', resourceUrl);
        },

        put: function (resourseUrl, data) {
            return request('Put', resourseUrl);
        },

        delete: function (resourseUrl) {
            return request('Delete', resourseUrl);
        }
    };

    return service;
}]);