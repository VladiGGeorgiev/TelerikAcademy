/// <reference path="../libs/_references.js" />
window.dataPersister = (function () {
    var nickname = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveLoginData(data) {
        localStorage.setItem("nickname", data.nickname);
        localStorage.setItem("sessionKey", data.sessionKey);
        nickname = data.nickname;
        sessionKey = data.sessionKey;
    }

    function clearLoginData() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        nickname = null;
        sessionKey = null;
    }

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.users = new UsersPersister(rootUrl);
            this.posts = new PostsPersister(rootUrl);
            this.tags = new TagsPersister(rootUrl);
        },
        hasUser: function () {
            return nickname != null && sessionKey != null;
        },
        getNickname: function () {
            return nickname;
        }
    });

    var UsersPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "users/"
        },
        login: function (username, password) {
            var url = this.rootUrl + "login";
            var user = {
                username: username,
                authenticationCode: CryptoJS.SHA1(password).toString()
            };

            return httpRequester.postJSON(url, user)
                .then(function (data) {
                    saveLoginData(data);
                    return data;
                }, function (err) {
                    return err;
                });
        },
        register: function (username, nickname, password) {
            var url = this.rootUrl + "register";
            var user = {
                username: username,
                nickname: nickname,
                authenticationCode: CryptoJS.SHA1(password).toString()
            };

            return httpRequester.postJSON(url, user)
                .then(function (data) {
                    saveLoginData(data);
                    return data;
                });
        },
        logout: function () {
            var url = this.rootUrl + "logout";
            var headers = {
                "X-sessionKey": sessionKey
            };

            return httpRequester.putJSON(url, headers)
                .then(function () {
                    clearLoginData();
                });
        }
    });

    var PostsPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "posts"
        },
        all: function () {
            var url = this.rootUrl;
            var headers = {
                "X-sessionKey": sessionKey
            };

            return httpRequester.getJSON(url, headers);
        },
        getById: function (id) {
            var url = this.rootUrl + "/" + id;

            var headers = {
                "X-sessionKey": sessionKey
            };

            return httpRequester.getJSON(url, headers);
        },
        comment: function (id, comment) {
            var url = this.rootUrl + "/" + id + "/comment";
            var headers = {
                "X-sessionKey": sessionKey
            };

            return httpRequester.putJSON(url, headers, comment);
        },
        getByTags: function (tags) {
            var url = this.rootUrl + "?tags=" + tags;
            var headers = {
                "X-sessionKey": sessionKey
            };

            return httpRequester.getJSON(url, headers);
        }
    });

    var TagsPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "tags/"
        },
        all: function () {
            var url = this.rootUrl;
            var headers = {
                "X-sessionKey": sessionKey
            };

            return httpRequester.getJSON(url, headers);
        }
    });

    return {
        get: function (rootUrl) {
            return new MainPersister(rootUrl);
        }
    }


}());