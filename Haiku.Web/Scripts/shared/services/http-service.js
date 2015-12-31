services.factory("HttpService", ['$http', function ($http) {
    //var serverUrl = "http://localhost:2950/api/";
    var serverUrl = "http://haikupub.azurewebsites.net/api/";
    
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

        get: function (resourceUrl, headers) {
            return request('Get', resourceUrl, headers);
        },

        put: function (resourseUrl, headers, data) {
            return request('Put', resourseUrl, headers, data);
        },

        delete: function (resourseUrl, headers) {
            return request('Delete', resourseUrl, headers);
        }
    };

    return service;
}]);