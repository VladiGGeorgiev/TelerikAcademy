/// <reference path="../libraries/_references.js" />
/// <reference path="../libraries/kendo.web.min.js" />
/// <reference path="../libraries/q.js" />
/// <reference path="data.js" />
window.viewModelFactory = (function () {
    var dataPersister = null;

    var minUsernameLength = 6;
    var maxUsernameLength = 30;
    
    var getHomePageViewModel = function(successCallback) {
        return kendo.observable({
            username: dataPersister.getUserName()
        });
    };
    var getLoginViewModel = function (successCallback) {
        var viewModel = new kendo.observable({
            username: "",
            password: "",
            email: "",
            infoMessage: "",
            login: function () {
                var self = this;
                var username = this.get("username");
                var password = this.get("password");
                var email = this.get("email");

                dataPersister.users.login(username, password, email)
                    .then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    }), function (err) {
                        var response = JSON.parse(err.responseText);
                        console.log(response);
                        self.set("infoMessage", response.Message);
                    };
            }
        });

        return viewModel;
    };

    var getRegisterViewModel = function (successCallback) {
        var viewModel = {
            username: "",
            password: "",
            email: "",
            infoMessage: "",
            register: function () {
                var self = this;

                var user = {
                    username: self.get("username"),
                    password: self.get("password"),
                    email: self.get("email"),
                };
                
                dataPersister.users.register(user)
                    .then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    }, function (err) {
                        var response = JSON.parse(err.responseText);
                        console.log(response);
                        self.set("infoMessage", response.Message);
                    });

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

    var getCreateNewAppointment = function(successCallback) {
        var viewModel = {
            subject: "",
            description: "",
            appointmentDate: "",
            duration: "",
            infoMessage: "",
            createAppointment: function() {
                var self = this;

                var appointment = {
                    subject: self.get("subject"),
                    description: self.get("description"),
                    appointmentDate: self.get("appointmentDate"),
                    duration: self.get("duration"),
                };

                dataPersister.appointments.createAppointmet(appointment)
                    .then(function() {
                        if (successCallback) {
                            successCallback();
                        }
                    }, function(err) {
                        var response = JSON.parse(err.responseText);
                        console.log(response);
                        self.set("infoMessage", response.Message);
                    });

            }
        };

        return new kendo.observable(viewModel);
    };

    var getAllApointments = function(successCallback) {
        return dataPersister.appointments.getAllAppointments()
            .then(function(appointments) {

                var appViewModel = {
                    appointments: appointments
                };
                return new kendo.observable(appViewModel);
            });
    };

    var getCommingApointments = function (successCallback) {
        return dataPersister.appointments.getUpcommingAppointments()
            .then(function (appointments) {
                var appViewModel = {
                    appointments: appointments
                };
                return new kendo.observable(appViewModel);
            });
    };
    
    var getTodayAppointments = function(successCallback) {
        return dataPersister.appointments.getTodayAppointments()
            .then(function (appointments) {
                var appViewModel = {
                    appointments: appointments
                };
                return new kendo.observable(appViewModel);
            });
    };

    var getCurrentAppointments = function (successCallback) {
        return dataPersister.appointments.getCurrentAppointments()
            .then(function (appointments) {
                var appViewModel = {
                    appointments: appointments
                };
                return new kendo.observable(appViewModel);
            });
    };
    
    var getAppointmentsByDate = function(successCallback) {
        var viewModel = new kendo.observable({
            model: null,
            appointments: [],
            date: "",
            infoMessage: "",
            getAppointments: function() {
                var self = this;
                return dataPersister.appointments.getAppointmentsByDate(this.get("date"))
                     .then(function (appointments) {
                         if (appointments == null || appointments.length == 0) {
                             self.set("infoMessage", "No results");
                         } else {
                             self.set("infoMessage", "");
                             self.set("appointments", appointments);
                         }
                     });
            }
        });

        return viewModel;
    };
    var getAllTodoList = function(successCallback) {
        return dataPersister.lists.getAllTodoLists()
            .then(function(todoLists) {

                var todoViewModel = {
                    todoLists: todoLists
                };
                return new kendo.observable(todoViewModel);
            });
    };

    var getSingleTodoList = function (id) {
        return dataPersister.lists.getSingleTodoList(id)
            .then(function (todoList) {
                var todoViewModel = {
                    todoList: todoList,
                    changeStatus: function(id) {
                        console.log(id);
                    }
                };
                return new kendo.observable(todoViewModel);
            });
    };

    var getCreateTodoList = function(successCallback) {
        var viewModel = {
            title: "",
            todos: "",
            infoMessage: "",
            createTodoList: function() {
                var self = this;

                var todosString = this.get("todos");
                var todosArr = todosString.split(',');
                var todosToSend = [];

                for (var i = 0; i < todosArr.length; i++) {
                    todosToSend.push({
                        text: todosArr[i]
                    });
                }

                var todo = {
                    title: this.get("title"),
                    todos: todosToSend
                };

                dataPersister.lists.createTodoList(todo)
                    .then(function() {
                        if (successCallback) {
                            successCallback();
                        }
                    }, function(err) {
                        var response = JSON.parse(err.responseText);
                        console.log(response);
                        self.set("infoMessage", response.Message);
                    });

            }
        };

        return new kendo.observable(viewModel);
    };
    
    var getCreateTodo = function (id) {
        var viewModel = {
            text: "",
            infoMessage: "",
            createTodo: function () {
                var self = this;

                var todo = {
                    text: self.get("text"),
                };

                dataPersister.lists.createNewTodo(id, todo)
                    .then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    }, function (err) {
                        var response = JSON.parse(err.responseText);
                        console.log(response);
                        self.set("infoMessage", response.Message);
                    });

            }
        };

        return new kendo.observable(viewModel);
    };
    var changeStatus = function(id) {
        return dataPersister.todos.changeStatus(id);
    };
    return {
        getHomePageViewModel: getHomePageViewModel,
        getLoginViewModel: getLoginViewModel,
        getRegisterViewModel: getRegisterViewModel,
        getLogoutViewModel: getLogoutViewModel,
        getCreateNewAppointment: getCreateNewAppointment,
        getAllApointments: getAllApointments,
        getCommingApointments: getCommingApointments,
        getTodayAppointments: getTodayAppointments,
        getCurrentAppointments: getCurrentAppointments,
        getAppointmentsByDate: getAppointmentsByDate,
        getAllTodoList: getAllTodoList,
        getSingleTodoList: function(id) {
            return getSingleTodoList(id);
        },
        getCreateTodoList: getCreateTodoList,
        getCreateTodo: getCreateTodo,
        changeStatus: changeStatus,

        setPersister: function (pers) {
            dataPersister = pers;
        }
    };
}());
