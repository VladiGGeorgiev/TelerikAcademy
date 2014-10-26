/// <reference path="../libs/_references.js" />
window.views = (function () {
    var templateBasicUrl = "scripts/partials/";
    var templates = {};

    function getTemplate(name) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates[name]) {
                resolve(templates[name]);
            } else {
                jQuery.ajax({
                    url: templateBasicUrl + name + "-partial.html",
                    type: "GET",
                    success: function (data) {
                        templates[name] = data;
                        resolve(data);
                    },
                    error: function (err) {
                        reject(err);
                    }
                });
            }
        });

        return promise;
    }

    function getLoginView() {
        return getTemplate("login");
    }

    function getHomeView() {
        return getTemplate("home");
    }

    function getPostsView() {
        return getTemplate("posts");
    }

    function getPostByIdView() {
        return getTemplate("post-by-id");
    }

    function getPostCommentView() {
        return getTemplate("post-comment");
    }

    function getSearchResultsView() {
        return getTemplate("search-results");
    }

    return {
        getLoginView: getLoginView,
        getHomeView: getHomeView,
        getPostsView: getPostsView,
        getPostByIdView: getPostByIdView,
        getPostCommentView: getPostCommentView,
        getSearchResultsView: getSearchResultsView
    }
}());