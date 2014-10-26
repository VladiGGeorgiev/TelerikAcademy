/// <reference path="../libraries/class.js" />
/// <reference path="../libraries/q.js" />
/// <reference path="../libraries/jquery-2.0.3.js" />

var Requester = (function () {
    var makeHttpGetRequest = function (url, headers) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: "get",
            contentType: "application/json",
            headers: headers,
            success: function (result) {
                deferred.resolve(result);
            },
            error: function (error) {
                deferred.reject(error);
            }
        });

        return deferred.promise;
    };
    
    var makeHttpPostRequest = function (url, data, headers) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: "postJSON",
            contentType: "application/json",
            data: JSON.stringify(data),
            headers: headers,
            success: function (result) {
                deferred.resolve(result);
            },
            error: function (error) {
                deferred.reject(error);
            }
        });

        return deferred.promise;
    };

    var makeHttpPutRequest = function (url, data, headers) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: "putJSON",
            contentType: "application/json",
            data: JSON.stringify(data),
            headers: headers,
            success: function (result) {
                deferred.resolve(result);
            },
            error: function (error) {
                deferred.reject(error);
            }
        });

        return deferred.promise;
    };

    var makeHttpDeleteRequest = function (url, headers) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: "deleteJSON",
            contentType: "application/json",            
            headers: headers,
            success: function (result) {
                deferred.resolve(result);
            },
            error: function (error) {
                deferred.reject(error);
            }
        });

        return deferred.promise;
    };

    return {
        postJSON: makeHttpPostRequest,
        get: makeHttpGetRequest,
        putJSON: makeHttpPutRequest,
        deleteJSON: makeHttpDeleteRequest 
    };
}());