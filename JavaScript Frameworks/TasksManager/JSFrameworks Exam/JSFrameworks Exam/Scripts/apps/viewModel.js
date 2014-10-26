/// <reference path="../libraries/_references.js" />
/// <reference path="../libraries/q.js" />
window.viewModelFactory = (function () {
    var dataPersister = null;
    var defaultUserImageUrl = "http://i.imgur.com/hDFGIkE.png";
    var defaultEventImageUrl = "http://i.imgur.com/d76xRl4.png";

    var minUsernameLength = 6;
    var maxUsernameLength = 30;
    var minAddressLength = 6;
    var maxAddressLength = 30;
    var minEventTitleLength = 4;
    var maxEventTitleLength = 50;
    var minEventDetailsLength = 50;
    var maxEventDetailsLength = 1000;

    var getLoginViewModel = function (successCallback) {
        var viewModel = new kendo.observable({
            username: "",
            password: "",
            infoMessage: "",
            login: function () {
                var self = this;
                var username = this.get("username");
                var password = this.get("password");

                if (!username || username.length < minUsernameLength || username.length > maxUsernameLength) {
                    self.set("infoMessage", "Username must be between " + minUsernameLength + " and " + maxUsernameLength + " characters!");
                } else if (!password) {
                    self.set("infoMessage", "Password cannot be empty!");
                } else {
                    dataPersister.users.login(username, password)
                        .then(function () {
                            if (successCallback) {
                                successCallback();
                            }
                        }), function (err) {
                            var response = JSON.parse(err.responseText);
                            self.set("infoMessage", response.Message);
                        };
                }
            }
        });

        return viewModel;
    };

    var getRegisterViewModel = function (successCallback) {
        var viewModel = {
            username: "",
            fullname: "",
            password: "",
            email: "",
            age: "",
            facebook: "",
            aboutMe: "",
            town: "",
            gender: "",
            image: null,
            infoMessage: "",
            getImage: function (e) {
                this.set("image", e.target.files[0]);
            },
            register: function () {
                var self = this;
                var img = this.get("image");

                var user = {
                    username: self.get("username"),
                    fullname: self.get("fullname"),
                    password: self.get("password"),
                    email: self.get("email"),
                    facebook: self.get("facebook"),
                    aboutMe: self.get("aboutMe"),
                    town: self.get("town"),
                    gender: self.get("gender")
                };

                if (!user.username || user.username.length < minUsernameLength || user.username.length > maxUsernameLength) {
                    self.set("infoMessage", "Username must be between " + minUsernameLength + " and " + maxUsernameLength + " characters!");
                } else if (!user.fullname || user.fullname.length < minUsernameLength || user.fullname.length > maxUsernameLength) {
                    self.set("infoMessage", "Fullname must be between " + minUsernameLength + " and " + maxUsernameLength + " characters!");
                } else if (!user.password) {
                    self.set("infoMessage", "Password cannot be empty!");
                } else if (!user.email) {
                    self.set("infoMessage", "Email cannot be empty!");
                } else if (self.get("age") > new Date()) {
                    self.set("infoMessage", "Date of birth must be a past date!");
                } else if (user.town == null || user.town == "") {
                    self.set("infoMessage", "Town cannot be empty!");
                } else {
                    uploadImageToImgur(img, defaultUserImageUrl)
                        .then(function (link) {
                            user.avatarUrl = link;
                            user.age = new Date().getYear() - self.get("age").getYear();

                            dataPersister.users.register(user).then(function () {
                                if (successCallback) {
                                    successCallback();
                                }
                            }, function (err) {
                                var response = JSON.parse(err.responseText);
                                self.set("infoMessage", response.Message);
                            });
                        });
                }
            }
        };

        return new kendo.observable(viewModel);
    };

    var getLogoutViewModel = function (successCallback) {

        var viewModel = {
            logout: function () {
                dataPersister.users.logout()
                    .then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    });
            }
        };
        return new kendo.observable(viewModel);

    };

    var getUserViewModel = function (username) {
        return dataPersister.users.getUser(username)
            .then(function (user) {
                if (!user.facebookLink) {
                    user.facebookLink = "#/user/" + user.username;
                }

                return new kendo.observable({
                    user: user
                });
            }, function (err) {
                var response = JSON.parse(err.responseText);
                self.set("infoMessage", response.Message);
            });
    };

    function uploadImageToImgur(image, defaultImage) {
        var deferred = Q.defer();

        if (!image || !image.type.match(/image.*/)) {
            deferred.resolve(defaultImage);
        } else {
            var fd = new FormData();
            var xhr = new XMLHttpRequest();

            fd.append("image", image);
            xhr.open("POST", "https://api.imgur.com/3/image.json");
            xhr.onload = function () {
                var imgLink = JSON.parse(xhr.responseText).data.link;
                deferred.resolve(imgLink);
            };
            xhr.setRequestHeader('Authorization', 'Client-ID 366a0ada01a7ec6');
            xhr.send(fd);
        }
        return deferred.promise;
    }

    return {
        getLoginViewModel: getLoginViewModel,
        getRegisterViewModel: getRegisterViewModel,
        getLogoutViewModel: getLogoutViewModel,
        getUserViewModel: getUserViewModel,
        getCreateEventViewModel: getCreateEventViewModel,
        getEventsViewModel: getEventsViewModel,
        getSingleEventViewModel: getSingleEventViewModel,
        getSearchEventViewModel: getSearchEventViewModel,
        getEditEventViewModel: getEditEventViewModel,

        setPersister: function (pers) {
            dataPersister = pers;
        }
    };
}());
