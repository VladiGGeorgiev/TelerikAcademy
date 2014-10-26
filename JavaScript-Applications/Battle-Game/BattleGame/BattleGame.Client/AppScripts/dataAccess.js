/// <reference path="requester.js" />
/// <reference path="../Scripts/jquery-2.0.2.js" />
/// <reference path="../Scripts/class.js" />
var BullsAndCows = BullsAndCows || {};

BullsAndCows.persisters = (function () {
    var nickname = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveUserData(data) {
        localStorage.setItem("sessionKey", data.sessionKey);
        localStorage.setItem("nickname", data.nickname);
        nickname = data.nickname;
        sessionKey = data.sessionKey;
    }

    function clearUserData() {
        localStorage.removeItem("sessionKey");
        localStorage.removeItem("nickname");
        nickname = "";
        sessionKey = "";
    }

    var Base = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new Users(rootUrl);
            this.game = new Game(rootUrl);
            this.message = new Message(rootUrl);
            this.battle = new Battle(rootUrl);
        },

        isLoggedIn: function () {
            var hasSessionKey = localStorage.hasOwnProperty("sessionKey");
            var hasNickname = localStorage.hasOwnProperty("nickname")
            return (hasNickname && hasSessionKey) == true;
        },

        getNickname: function() {
            return nickname;
        }
    
    });

    var Users = Class.create({
        init: function (rootUrl) {
            this.serviceUrl = rootUrl + "user/";
        },

        register: function (username, nickname, password) {
            var url = this.serviceUrl + "register";
            var data = {
                username: username,
                nickname: nickname,
                authCode: CryptoJS.SHA1(username + password).toString()
            };

            return Requester.post(url, data)
                .then(function (data) {
                    saveUserData(data);
                });
        },

        login: function (username, password) {
            var url = this.serviceUrl + "login";
            var data = {
                username: username,
                authCode: CryptoJS.SHA1(username + password).toString()
            };

            return Requester.post(url, data)
                .then(function (data) {
                    console.log(data);
                    saveUserData(data);
                });
        },

        logout: function () {
            var url = this.serviceUrl + "logout/" + sessionKey;

            return Requester.get(url)
                .then(function (data) {
                    clearUserData();
                });
        },

        scores: function () {
            var url = this.serviceUrl + "scores/" + sessionKey;

            return Requester.get(url)
                .then(function (data) {
                    return data;
                });
        }
    });

    var Game = Class.create({
        init: function (rootUrl) {
            this.serviceUrl = rootUrl + "game/";
        },

        create: function (arguments) {
            var url = this.serviceUrl + "create/" + sessionKey;

            return Requester.post(url, {
                title: arguments.name,
                password: CryptoJS.SHA1(arguments.password).toString(),
            });
        },

        join: function (arguments) {
            var url = this.serviceUrl + "join/" + sessionKey;

            return Requester.post(url, {
                id: arguments.gameId,
                password: CryptoJS.SHA1(arguments.password).toString(),
            });
        },

        start: function (gameId) {
            var url = this.serviceUrl + gameId + "/start/" + sessionKey;

            return Requester.get(url);
        },

        myActive: function () {
            var url = this.serviceUrl + "my-active/" + sessionKey;

            return Requester.get(url);
        },

        open: function () {
            var url = this.serviceUrl + "open/" + sessionKey;

            return Requester.get(url);
        },

        field: function (gameId) {
            var url = this.serviceUrl + gameId + "/field/" + sessionKey;

            return Requester.get(url);
        },
    });

    var Message = Class.create({
        init: function (rootUrl) {
            this.serviceUrl = rootUrl + "messages/";
        },

        unread: function () {
            var url = this.serviceUrl + "unread/" + sessionKey;

            return Requester.get(url)
                .then(function (data) {
                    return data;
                });
        },

        all: function () {
            var url = this.serviceUrl + "all/" + sessionKey;

            return Requester.get(url)
                .then(function (data) {
                    return data;
                });
        }
    });

    var Battle = Class.create({
        init: function (rootUrl) {
            this.serviceUrl = rootUrl + "battle/";
        },
        
        move: function (gameId, unitId, position) {
            var url = this.serviceUrl + gameId + "/move/" + sessionKey;
            
            return Requester.post(url, {
                unitId: unitId,
                position: position
            })
        },

        attack: function (gameId, unitId, position) {
            var url = this.serviceUrl + gameId + "/attack/" + sessionKey;

            return Requester.post(url, {
                unitId: unitId,
                position: position
            })
        },

        defend: function(gameId, unitId) {
            var url = this.serviceUrl + gameId + "/defend/" + sessionKey;

            return Requester.post(url, unitId);
        }
    });

    return {
        get: function (url) {
            return new Base(url);
        },
    }
}());