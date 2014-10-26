/// <reference path="app/data.js" />
/// <reference path="app/viewModel.js" />
/// <reference path="app/view.js" />
/// <reference path="libraries/kendo/2013.2.716/kendo.web.min.js" />

(function () {
    var appLayout = new kendo.Layout('<div id="main-content"></div>');

    var data = persister.getPersister("http://localhost:38780/api/");
    viewModelFactory.setPersister(data);

    var router = new kendo.Router();

    router.route("/", function () {
        if (localStorage.getItem("userRole") == "Administrator" && $("#admin-button").length == 0) {
            $("#menu").append('<li id="admin-button"><a href="/#/administration">Admin panel</a></li>');
        } else if (localStorage.getItem("userRole") != "Administrator") {
            $("#admin-button").remove();
        }
        
        var username = data.getUserName();
        if (username == null || username == "") {
            $(".logged-in").addClass("hidden");
            $(".logged-out").removeClass("hidden");
            
            viewsFactory.getHomePageView()
            .then(function (eventsViewHtml) {
                viewModelFactory.getEventsViewModel()
                    .then(function (viewModel) {
                        var view = new kendo.View(eventsViewHtml, { model: viewModel });
                        $("#main-content").html("");
                        appLayout.showIn("#main-content", view);
                    }).done();
            }, function (error) {
                console.log(error);
            });
        } else {
            $("#user-profile-link").attr("href", "#/user/" + data.getUserName());
            viewsFactory.getHomePageView()
            .then(function (eventsViewHtml) {
                viewModelFactory.getEventsViewModel()
                    .then(function (viewModel) {
                        var view = new kendo.View(eventsViewHtml, { model: viewModel });
                        $("#main-content").html("");
                        appLayout.showIn("#main-content", view);
                        $(".logged-out").addClass("hidden");
                        $(".logged-in").removeClass("hidden");
                    }).done();
            }, function(error) {
                console.log(error);
            });

        }
    });

    router.route("/search", function () {
        viewsFactory.getSearchEventView()
            .then(function (viewHtml) {
                var viewModel = viewModelFactory.getSearchEventViewModel();
                var searchView = new kendo.View(viewHtml, { model: viewModel });
                $("#main-content").html("");
                appLayout.showIn("#main-content", searchView);
            }).done();
    });

    router.route("/login", function () {
        if (localStorage.getItem("userRole") != "Administrator") {
            $("#admin-button").remove();
        }
        viewsFactory.getLoginView()
        .then(function (viewHtml) {
            var username = data.getUserName();
            if (username == null || username == "") {
                $(".logged-out").removeClass("hidden");
                $(".logged-in").addClass("hidden");
                var loginViewModel = viewModelFactory.getLoginViewModel(function () {
                    router.navigate("/");
                    $(".logged-out").addClass("hidden");
                    $(".logged-in").removeClass("hidden");
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

    router.route("/create-event", function () {
        viewsFactory.getCreateEventView()
            .then(function (viewHtml) {
                var createEventViewModel = viewModelFactory.getCreateEventViewModel(function (url) {
                    router.navigate(url);
                });
                var createEventView = new kendo.View(viewHtml, { model: createEventViewModel });
                $("#main-content").html("");
                appLayout.showIn("#main-content", createEventView);
            });
    });

    router.route("/events/:id", function (id) {

        viewsFactory.getSingleEventView()
            .then(function (singleEventView) {
                viewModelFactory.getSingleEventViewModel(id, function (url) {
                    router.navigate(url);
                })
                    .then(function (viewModel) {
                        var view = new kendo.View(singleEventView, { model: viewModel });
                        $("#main-content").html("");
                        appLayout.showIn("#main-content", view);
                    });
            });
    });

    router.route("/user/:username", function (username) {
        var username = data.getUserName();
        if (username == null || username == "") {
            router.navigate("/");
        } else {
            $(".logged-out").addClass("hidden");
            $(".logged-in").removeClass("hidden");

            viewsFactory.getUserView()
                .then(function (viewHtml) {
                    viewModelFactory.getUserViewModel(username)
                    .then(function (viewModel) {
                        var userView = new kendo.View(viewHtml, { model: viewModel });
                        $("#main-content").html("");
                        appLayout.showIn("#main-content", userView);
                    });
                });
        }
    });

    router.route("/events/:id/edit", function (id) {
        viewsFactory.getEditEventView()
            .then(function (editEventView) {
                viewModelFactory.getEditEventViewModel(id, function () {
                    router.navigate("/events/" + id);
                })
                    .then(function (viewModel) {
                        var view = new kendo.View(editEventView, { model: viewModel });
                        $("#main-content").html("");
                        appLayout.showIn("#main-content", view);
                    });
            });
    });

    router.route("/administration/", function() {
        $(".logged-out").addClass("hidden");
        $(".logged-in").removeClass("hidden");
    });

    router.route("/administration/events", function () {
        $(".logged-out").addClass("hidden");
        $(".logged-in").removeClass("hidden");
    });
    
    router.route("/administration/users", function () {
        $(".logged-out").addClass("hidden");
        $(".logged-in").removeClass("hidden");
    });
    
    $(function () {
        appLayout.render("#body");
        router.start();
    });
}());