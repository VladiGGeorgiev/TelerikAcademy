/// <reference path="apps/data.js" />
/// <reference path="apps/viewModel.js" />
/// <reference path="apps/view.js" />
/// <reference path="libraries/kendo/2013.2.716/kendo.web.min.js" />

(function () {
    var appLayout = new kendo.Layout('<div id="main-content"></div>');

    var data = persister.getPersister("http://localhost:16183/api/");
    viewModelFactory.setPersister(data);

    var router = new kendo.Router();

    router.route("/", function () {
        var username = data.getUserName();
        if (username == null || username == "") {
            $(".logged-in").addClass("hidden");
            $(".logged-out").removeClass("hidden");
            viewsFactory.getHomeView()
                .then(function(viewHtml) {
                    var viewModel = viewModelFactory.getHomePageViewModel();
                    var view = new kendo.View(viewHtml, { model: viewModel });
                    $("#main-content").html("");
                    appLayout.showIn("#main-content", view);
                });

        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");
            viewsFactory.getHomeView()
                .then(function (viewHtml) {
                    var viewModel = viewModelFactory.getHomePageViewModel();
                    var view = new kendo.View(viewHtml, { model: viewModel });
                    $("#main-content").html("");
                    appLayout.showIn("#main-content", view);
                });
        }
    });

    router.route("/login", function () {
        viewsFactory.getLoginView()
        .then(function (viewHtml) {
            var username = data.getUserName();
            if (username == null || username == "") {
                $(".logged-out").removeClass("hidden");
                $(".logged-in").addClass("hidden");
                var loginViewModel = viewModelFactory.getLoginViewModel(function () {
                    router.navigate("/");
                    console.log("User logged in!");
                    $(".logged-out").addClass("hidden");
                    $(".logged-in").removeClass("hidden");
                    $("#main-content").html("");
                });
                var loginView = new kendo.View(viewHtml, { model: loginViewModel });
                $("#main-content").html("");
                appLayout.showIn("#main-content", loginView);
            } else {
                router.navigate("/");
            }
        });
    });

    router.route("/register", function () {
        $(".logged-out").removeClass("hidden");
        $(".logged-in").addClass("hidden");
        viewsFactory.getRegisterView()
            .then(function (viewHtml) {
                var username = data.getUserName();
                if (username == null || username == "") {
                    var registerViewModel = viewModelFactory.getRegisterViewModel(function () {
                        router.navigate("/");
                        console.log("User registered!");
                        $(".logged-out").addClass("hidden");
                        $(".logged-in").removeClass("hidden");
                    });
                    var registerView = new kendo.View(viewHtml, { model: registerViewModel });
                    $("#main-content").html("");
                    appLayout.showIn("#main-content", registerView);
                } else {
                    router.navigate("/");
                }
            });
    });

    router.route("/logout", function () {
        data.users.logout()
            .then(function () {
                router.navigate("/");
                $(".logged-out").removeClass("hidden");
                $(".logged-in").addClass("hidden");
            });
    });

    router.route("/appointments/create", function () {
        var username = data.getUserName();
        if (username == null || username == "") {
            router.navigate("/");
        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");
            viewsFactory.getCreateNewApp()
            .then(function (viewHtml) {
                var viewModel = viewModelFactory.getCreateNewAppointment(function () {
                    console.log("Appointment created!");
                    router.navigate("/");
                });

                var createAppView = new kendo.View(viewHtml, { model: viewModel });
                appLayout.showIn("#main-content", createAppView);
            });
        }
    });
    
    router.route("/appointments/all", function () {
        var username = data.getUserName();
        if (username == null || username == "") {
            router.navigate("/");
        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");
            viewsFactory.getAllAppointments()
                .then(function(appViewHtml) {
                    viewModelFactory.getAllApointments()
                        .then(function(viewModel) {
                            var appView = new kendo.View(appViewHtml, { model: viewModel });
                            appLayout.showIn("#main-content", appView);
                        }, function(err) {
                            console.log(err);
                        });
                }, function(error) {
                    console.log(error);
                });
        }
    });

    router.route("/appointments/upcomming", function () {
        var username = data.getUserName();
        if (username == null || username == "") {
            router.navigate("/");
        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");
            viewsFactory.getCommingApointmentView()
                .then(function(appViewHtml) {
                    viewModelFactory.getCommingApointments()
                        .then(function(viewModel) {
                            var appView = new kendo.View(appViewHtml, { model: viewModel });
                            appLayout.showIn("#main-content", appView);
                        }, function(err) {
                            console.log(err);
                        });
                }, function(error) {
                    console.log(error);
                });
        }
    });

    router.route("/appointments/today", function () {
        var username = data.getUserName();
        if (username == null || username == "") {
            router.navigate("/");
        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");
            viewsFactory.getTodayAppointmentsView()
                .then(function(appViewHtml) {
                    viewModelFactory.getTodayAppointments()
                        .then(function(viewModel) {
                            var appView = new kendo.View(appViewHtml, { model: viewModel });
                            appLayout.showIn("#main-content", appView);
                        }, function(err) {
                            console.log(err);
                        });
                }, function(error) {
                    console.log(error);
                });
        }
    });

    router.route("/appointments/current", function () {
        var username = data.getUserName();
        if (username == null || username == "") {
            router.navigate("/");
        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");
            viewsFactory.getCurrentAppointmentsView()
                .then(function(appViewHtml) {
                    viewModelFactory.getCurrentAppointments()
                        .then(function(viewModel) {
                            var appView = new kendo.View(appViewHtml, { model: viewModel });
                            appLayout.showIn("#main-content", appView);
                        }, function(err) {
                            console.log(err);
                        });
                }, function(error) {
                    console.log(error);
                });
        }
    });

    router.route("/appointments/date", function () {
        var username = data.getUserName();
        if (username == null || username == "") {
            router.navigate("/");
        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");
            viewsFactory.getAppointmentByDate()
                .then(function(viewHtml) {
                    var viewModel = viewModelFactory.getAppointmentsByDate();
                    var searchView = new kendo.View(viewHtml, { model: viewModel });
                    $("#main-content").html("");
                    appLayout.showIn("#main-content", searchView);
                }).done();
        }
    });

    router.route("/todo-lists", function () {
        var username = data.getUserName();
        if (username == null || username == "") {
            router.navigate("/");
        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");
            viewsFactory.getAllTodoListView()
                .then(function(appViewHtml) {
                    viewModelFactory.getAllTodoList()
                        .then(function(viewModel) {
                            var appView = new kendo.View(appViewHtml, { model: viewModel });
                            appLayout.showIn("#main-content", appView);
                        }, function(err) {
                            console.log(err);
                        });
                }, function(error) {
                    console.log(error);
                });
        }
    });

    router.route("/todo-list/:id", function (id) {
        var username = data.getUserName();
        if (username == null || username == "") {
            router.navigate("/");
        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");
            viewsFactory.getSingleTodoListView()
                .then(function(appViewHtml) {
                    viewModelFactory.getSingleTodoList(id)
                        .then(function(viewModel) {
                            var appView = new kendo.View(appViewHtml, { model: viewModel });
                            appLayout.showIn("#main-content", appView);
                        }, function(err) {
                            console.log(err);
                        });
                }, function(error) {
                    console.log(error);
                });
        }

        //TODO: Get single todo list with todos.
    });

    router.route("/todo-lists/create", function () {
        var username = data.getUserName();
        if (username == null || username == "") {
            router.navigate("/");
        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");
            viewsFactory.getCreateTodoListView()
                .then(function(viewHtml) {
                    var viewModel = viewModelFactory.getCreateTodoList();
                    var view = new kendo.View(viewHtml, { model: viewModel });
                    $("#main-content").html("");
                    appLayout.showIn("#main-content", view);
                });
        }

    });

    router.route("/todo-list/:id/create", function (id) {
        var username = data.getUserName();
        if (username == null || username == "") {
            router.navigate("/");
        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");
            viewsFactory.getCreateTodoView()
            .then(function (viewHtml) {
                var viewModel = viewModelFactory.getCreateTodo(id);

                var createAppView = new kendo.View(viewHtml, { model: viewModel });
                appLayout.showIn("#main-content", createAppView);
            });
        }
    });
    
    router.route("/todo-list/change-status/:id", function (id) {
        var username = data.getUserName();
        if (username == null || username == "") {
            router.navigate("/");
        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");
            viewModelFactory.changeStatus(id)
                .then(function(data) {
                    document.reload();
                });
            history.back();
        }
    });
    $(function () {
        appLayout.render("#body");
        router.start();
    });
}());