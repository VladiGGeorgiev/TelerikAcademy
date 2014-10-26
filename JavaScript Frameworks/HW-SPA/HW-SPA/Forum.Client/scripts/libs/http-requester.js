var httpRequester = (function () {
    function getJSON(serviceUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            jQuery.ajax({
                url: serviceUrl,
                type: "GET",
                headers: headers,
                dataType: "json",
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });

        return promise;
    }

    function postJSON(serviceUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            jQuery.ajax({
                url: serviceUrl,
                dataType: "json",
                type: "POST",
                headers: headers,
                contentType: "application/json",
                data: JSON.stringify(data),
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });

        return promise;
    }

    function putJSON(serviceUrl, headers, data) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            jQuery.ajax({
                url: serviceUrl,
                dataType: "json",
                type: "PUT",
                headers: headers,
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function () {
                    resolve();
                },
                error: function () {
                    reject();
                }
            });
        });

        return promise;
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON,
        putJSON: putJSON
    }
}());
