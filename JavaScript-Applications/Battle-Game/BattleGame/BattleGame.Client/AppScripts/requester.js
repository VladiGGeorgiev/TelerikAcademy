/// <reference path="../Scripts/jquery-2.0.2.js" />
/// <reference path="../Scripts/ProtoClass.js" />
/// <reference path="../Scripts/q.js" />
/// <reference path="dataAccess.js" />
/// <reference path="../Scripts/sha1.js" />

var Requester = (function () {
    var makeHttpRequest = function (url, type, data) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: type,
            contentType: "application/json",
            data: JSON.stringify(data),
            success: function (result) {
                deferred.resolve(result);
            },
            error: function (error) {
                deferred.reject(error);
            }
        });

        return deferred.promise;
    }

    var makeHttpGetRequest = function (url) {
        return makeHttpRequest(url, "get");
    }

    var makeHttpPostRequest = function (url, data) {
        return makeHttpRequest(url, "post", data);
    }

    return {
        post: makeHttpPostRequest,
        get: makeHttpGetRequest
    }
}());