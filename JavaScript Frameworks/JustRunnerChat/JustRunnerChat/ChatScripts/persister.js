/// <reference path="requester.js" />
/// <reference path="../Scripts/jquery-2.0.2.js" />
/// <reference path="../Scripts/class.js" />
var Chat = Chat || {};

Chat.persisters = (function () {
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
            this.channels = new Channels(rootUrl);
        },

        isLoggedIn: function () {
            var hasSessionKey = localStorage.hasOwnProperty("sessionKey");
            var hasNickname = localStorage.hasOwnProperty("nickname");
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
        }
    });

    var Channels = Class.create({
        init: function(rootUrl) {
            this.serviceUrl = rootUrl + "channel/";
        },
        
        create: function (channelName, password) {
            var url = this.serviceUrl + "create";
            var data = {
                name: channelName,
                nickname: nickname,
                password: password
            };

            return Requester.post(url, data);
        },
        
        join: function (channelName, password) {
            var url = this.serviceUrl + "join";
            var data = {
                name: channelName,
                nickname: nickname,
                password: password
            };

            return Requester.post(url, data);
        },
        
        sendMessage: function (channelName, messageText) {
            var url = this.serviceUrl + "add-message?channelName=" + channelName;
            var data = {
                name: channelName,
                nickname: nickname,
                message: messageText
            };

            return Requester.post(url, data);
        },
        
        exitChannel: function (channelName) {
            var url = this.serviceUrl + "exit";

            var data = {
                nickname: nickname,
                name: channelName
            };

            return Requester.post(url, data);
        },
        
        getAll: function () {
            var url = this.serviceUrl + "get-channels";

            return Requester.get(url);
        },
        
        getUsers: function (channelName) {
            var url = this.serviceUrl + "get-users?channelName=" + channelName;

            return Requester.get(url);
        }
    });

    return {
        get: function(url) {
            return new Base(url);
        },
    };
}());