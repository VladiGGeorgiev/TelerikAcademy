/// <reference path="../libraries/jquery-2.0.3.js" />
/// <reference path="../libraries/class.js" />
/// <reference path="../libraries/sha1.js" />
/// <reference path="http-requester.js" />

window.persister = (function () {
    var sessionKey = localStorage.getItem("sessionKey");
    var username = localStorage.getItem("nickname");
    var userRole = localStorage.getItem("userRole");

    function saveUserData(data) {
        localStorage.setItem("sessionKey", data.sessionKey);
        localStorage.setItem("nickname", data.username);
        localStorage.setItem("userRole", data.role);
        username = data.username;
        sessionKey = data.sessionKey;
        userRole = data.role;
    }

    function clearUserData() {
        localStorage.removeItem("sessionKey");
        localStorage.removeItem("nickname");
        localStorage.removeItem("userRole");
        username = "";
        sessionKey = "";
        userRole = "";
    }

    var BasePersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.users = new UsersPersister(rootUrl);
            this.events = new EventsPersister(rootUrl);
        },
        getUserName: function () {
            return username;
        },
        getSessionKey: function () {
            return sessionKey;
        },
        getUserRole: function () {
            return userRole;
        }
    });

    var UsersPersister = Class.create({
        init: function (rootUrl) {
            this.usersApiUrl = rootUrl + "users";
        },

        login: function (user, password) {
            var url = this.usersApiUrl + "/login";
            var userData = {
                username: user,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return Requester.postJSON(url, userData)
                .then(function (data) {
                    saveUserData(data);
                }, function (err) {
                    console.log(err);
                });
        },

        register: function (userData) {
            var url = this.usersApiUrl + "/register";
            userData.authCode = CryptoJS.SHA1(userData.password).toString();
            return Requester.postJSON(url, userData)
                .then(function (data) {
                    saveUserData(data);
                }, function (err) {
                    return err;
                });
        },

        logout: function () {
            var url = this.usersApiUrl + "/logout";
            if (sessionKey == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-sessionKey": sessionKey
            };

            return Requester.putJSON(url, {}, headers)
                .then(function () {
                    clearUserData();
                }, function (err) {
                    console.log(err);
                });
        },
        
        getUser: function (username) {
            var url = this.usersApiUrl + "?username=" + username;

            var headers = {
                "X-sessionKey": sessionKey
            };

            return Requester.get(url, headers);
        }
    });

    var EventsPersister = Class.create({
        init: function (rootUrl) {
            this.eventsApiUrl = rootUrl + "events";
        },

        getAllEvents: function () {
            return Requester.get(this.eventsApiUrl + "/all");
        },

        getEventById: function (id) {
            var url = this.eventsApiUrl + "/get/" + id;
            return Requester.get(url);
        },

        createEvent: function (event) {
            var url = this.eventsApiUrl + "/create";

            if (sessionKey == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-sessionKey": sessionKey
            };

            return Requester.postJSON(url, event, headers);
        },

        editEvent: function (id, event) {

            var url = this.eventsApiUrl + "/edit/" + id;

            if (sessionKey == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-sessionKey": sessionKey
            };

            return Requester.putJSON(url, event, headers);
        },

        deleteEvent: function (id) {
            var url = this.eventsApiUrl + "/deleteJSON/" + id;

            if (sessionKey == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-sessionKey": sessionKey
            };

            return Requester.deleteJSON(url, headers);
        },

        joinEvent: function (id) {
            var url = this.eventsApiUrl + "/join/" + id;

            if (sessionKey == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-sessionKey": sessionKey
            };

            return Requester.putJSON(url, {}, headers);
        },

        leaveEvent: function (id) {
            var url = this.eventsApiUrl + "/leave/" + id;

            if (sessionKey == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-sessionKey": sessionKey
            };

            return Requester.putJSON(url, {}, headers);
        },

        comment: function (id, comment) {
            var url = this.eventsApiUrl + "/comment/" + id;

            if (sessionKey == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-sessionKey": sessionKey
            };

            return Requester.putJSON(url, comment, headers);
        },

        vote: function (id, vote) {
            var url = this.eventsApiUrl + "/vote/" + id;

            if (sessionKey == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-sessionKey": sessionKey
            };
            debugger;
            return Requester.putJSON(url, vote, headers);
        },

        getEventsByCategory: function (category) {

            var url = this.eventsApiUrl + "?category=" + category;

            if (sessionKey == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-sessionKey": sessionKey
            };

            return Requester.get(url, headers);
        },

        getEventsByTown: function (town) {

            var url = this.eventsApiUrl + "?town=" + town;

            if (sessionKey == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-sessionKey": sessionKey
            };

            return Requester.get(url, headers);

        }
    });

    return {
        getPersister: function (rootUrl) {
            return new BasePersister(rootUrl);
        }
    };
}());