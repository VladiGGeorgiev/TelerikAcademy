/// <reference path="libs/_references.js" />
(function () {
    var data = dataPersister.get("http://localhost:33389/api/");
    var router = new kendo.Router();
    var layout = new kendo.Layout("<div id='wrapper'></div>");

    viewModels.setData(data);

    router.route("/login", function () {
        if (data.hasUser()) {
            router.navigate("/home");
        } else {
            views.getLoginView()
                .then(function (loginView) {
                    var viewModel = viewModels.getLoginViewModel(function () {
                        router.navigate("/home");
                    });

                    var view = new kendo.View(loginView, { model: viewModel });
                    layout.showIn("#wrapper", view);

                    $("#login-register").kendoTabStrip({
                        animation: {
                            open: {
                                effects: "fadeIn"
                            }
                        }
                    });
                });
        }
    });

    router.route("/home", function () {
        if (!data.hasUser()) {
            router.navigate("/login");
            return;
        }

        views.getHomeView()
            .then(function (homeView) {
                var viewModel = viewModels.getHomeViewModel(function () {
                    router.navigate("/login");
                });

                var view = new kendo.View(homeView, { model: viewModel });
                layout.showIn("#wrapper", view);
                $("#main-menu").kendoMenu();
            });

    });

    router.route("/posts", function () {
        if (!data.hasUser()) {
            router.navigate("/login");
            return;
        }

        views.getPostsView()
            .then(function (postsView) {
                viewModels.getPostsViewModel(function (tags) {
                    var url = "/posts?tags=" + tags;
                    router.navigate(url);
                })
                    .then(function (viewModel) {
                        var view = new kendo.View(postsView, { model: viewModel });
                        $("#content").html("");
                        layout.showIn("#content", view);
                    })
            });
    });

    router.route("/posts/:postId", function (postId) {
        if (!data.hasUser()) {
            router.navigate("/login");
            return;
        }

        views.getPostByIdView()
            .then(function (postByIdView) {
                viewModels.getPostByIdViewModel(postId)
                    .then(function (viewModel) {
                        var view = new kendo.View(postByIdView, { model: viewModel });
                        $("#content").html("");
                        layout.showIn("#content", view);
                    });
            });

    });

    router.route("/posts/:postId/comment", function (postId) {
        if (!data.hasUser()) {
            router.navigate("/login");
            return;
        }

        views.getPostCommentView()
            .then(function (postCommentView) {
                var viewModel = viewModels.getPostCommentViewModel(postId, function () {
                    router.navigate("/posts/" + postId);
                });

                var view = new kendo.View(postCommentView, { model: viewModel });
                $("#content").html("");
                layout.showIn("#content", view);
            });
    });

    router.route("/posts?tags=:tags", function (tags) {
        if (!data.hasUser()) {
            router.navigate("/login");
            return;
        }

        views.getSearchResultsView()
            .then(function (searchResultsView) {
                viewModels.getPostsByTagsViewModel(tags)
                    .then(function (viewModel) {
                        var view = new kendo.View(searchResultsView, { model: viewModel });
                        $("#content").html("");
                        layout.showIn("#content", view);
                    });
            });

    });

    $(function () {
        router.start();
        layout.render($("#application"));

        if (data.hasUser()) {
            router.navigate("/home");
        } else {
            router.navigate("/login");
        }
    });
}());