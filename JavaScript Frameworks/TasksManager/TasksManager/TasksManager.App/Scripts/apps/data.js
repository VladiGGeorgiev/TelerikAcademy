/// <reference path="../libraries/jquery-2.0.3.js" />
/// <reference path="../libraries/class.js" />
/// <reference path="../libraries/sha1.js" />
/// <reference path="http-requester.js" />

window.persister = (function() {
    var accessToken = localStorage.getItem("accessToken");
    var username = localStorage.getItem("username");

    function saveUserData(data) {
        localStorage.setItem("accessToken", data.accessToken);
        localStorage.setItem("username", data.username);
        username = data.username;
        accessToken = data.accessToken;
    }

    function clearUserData() {
        localStorage.removeItem("accessToken");
        localStorage.removeItem("username");
        username = "";
        accessToken = "";
    }

    var BasePersister = Class.create({
        init: function(rootUrl) {
            this.rootUrl = rootUrl;
            this.users = new UsersPersister(rootUrl);
            this.appointments = new AppointmentsPersister(rootUrl);
            this.lists = new ListsPersister(rootUrl);
            this.todos = new TodosPersister(rootUrl);
        },

        getUserName: function() {
            return username;
        },

        getAccessToken: function() {
            return accessToken;
        },
    });

    var UsersPersister = Class.create({
        init: function(rootUrl) {
            this.usersApiUrl = rootUrl + "users";
            this.authToken = rootUrl + "auth/token";
        },

        login: function(user, password, email) {
            var url = this.authToken;
            var userData = {
                username: user,
                authCode: CryptoJS.SHA1(password).toString(),
                email: email
            };

            return Requester.postJSON(url, userData)
                .then(function(data) {
                    saveUserData(data);
                }, function(err) {
                    console.log(err);
                });
        },

        register: function(userData) {
            var url = this.usersApiUrl + "/register";

            var user = {
                username: userData.username,
                authCode: CryptoJS.SHA1(userData.password).toString(),
                email: userData.email
            };

            return Requester.postJSON(url, user)
                .then(function(data) {
                    saveUserData(data);
                }, function(err) {
                    console.log(err);
                });
        },

        logout: function() {
            var url = this.usersApiUrl;
            if (accessToken == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-accessToken": accessToken
            };

            return Requester.putJSON(url, {}, headers)
                .then(function() {
                    clearUserData();
                }, function(err) {
                    console.log(err);
                });
        }
    });

    var AppointmentsPersister = Class.create({
        init: function(rootUrl) {
            this.appointmentsApiUrl = rootUrl + "appointments";
        },

        createAppointmet: function(appointment) {
            var url = this.appointmentsApiUrl;

            if (accessToken == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-accessToken": accessToken
            };

            return Requester.postJSON(url, appointment, headers);
        },

        getAllAppointments: function() {
            var url = this.appointmentsApiUrl + "/all";

            if (accessToken == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-accessToken": accessToken
            };

            return Requester.get(url, headers);
        },

        getUpcommingAppointments: function() {
            var url = this.appointmentsApiUrl + "/comming";

            if (accessToken == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-accessToken": accessToken
            };

            return Requester.get(url, headers);
        },

        getAppointmentsByDate: function(date) {
            var url = this.appointmentsApiUrl + "?date=" + date;

            if (accessToken == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-accessToken": accessToken
            };

            return Requester.get(url, headers);
        },

        getTodayAppointments: function() {
            var url = this.appointmentsApiUrl + "/today";

            if (accessToken == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-accessToken": accessToken
            };

            return Requester.get(url, headers);
        },

        getCurrentAppointments: function() {
            var url = this.appointmentsApiUrl + "/current";


            if (accessToken == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-accessToken": accessToken
            };

            return Requester.get(url, headers);
        }
    });

    var ListsPersister = Class.create({
        init: function(rootUrl) {
            this.listsApiUrl = rootUrl + "lists";
        },

        createTodoList: function(todo) {
            var url = this.listsApiUrl;

            if (accessToken == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-accessToken": accessToken
            };

            return Requester.postJSON(url, todo, headers);
        },

        getAllTodoLists: function() {
            var url = this.listsApiUrl;

            if (accessToken == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-accessToken": accessToken
            };

            return Requester.get(url, headers);
        },

        getSingleTodoList: function(id) {
            var url = this.listsApiUrl + "/" + id + "/todos";

            if (accessToken == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-accessToken": accessToken
            };
            return Requester.get(url, headers);
        },

        createNewTodo: function(id, data) {
            var url = this.listsApiUrl + "/" + id + "/todos";

            if (accessToken == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-accessToken": accessToken
            };

            return Requester.postJSON(url, data, headers);
        },
    });

    var TodosPersister = Class.create({
        init: function (rootUrl) {
            this.todosApiUrl = rootUrl + "todos/";
        },

        changeStatus: function(id) {
            var url = this.todosApiUrl + id;

            if (accessToken == "") {
                throw "User is not authorized!";
            }

            var headers = {
                "X-accessToken": accessToken
            };

            return Requester.putJSON(url, {}, headers);
        }
    });

    return {
        getPersister: function (rootUrl) {
            return new BasePersister(rootUrl);
        }
    };
}());