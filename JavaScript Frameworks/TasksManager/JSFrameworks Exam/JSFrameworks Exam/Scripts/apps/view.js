/// <reference path="../libraries/jquery-2.0.3.js" />
/// <reference path="../libraries/q.js" />
/// <reference path="../libraries/class.js" />
window.viewsFactory = (function () {
    var rootUrl = "Scripts/partialViews/";

    var templates = {};

    function getTemplate(name) {
        var deferred = Q.defer();

        if (templates[name]) {
            deferred.resolve(templates[name]);
        }
        else {
            $.get(rootUrl + name + ".html")
                .success(function (template) {
                    templates[name] = template;
                    deferred.resolve(template);
                })
                .error(function (err) {
                    deferred.reject(err);
                });
        }

        return deferred.promise;
    }

    function getHomePageView() {
        return getTemplate("home");
    }

    function getLoginView() {
        return getTemplate("login");
    }

    function getRegisterView() {
        return getTemplate("register");
    }

    function getLogoutView() {
        return getTemplate("logout");
    }

    function getUserView() {
        return getTemplate("user-profile");
    }

    function getCreateEventView() {
        return getTemplate("create-event");
    }

    function getSingleEventView() {
        return getTemplate("single-event-preview");
    }

    function getEditEventView() {
        return getTemplate("single-event-edit");
    }
   
    function getSearchEventView() {
        return getTemplate("search");
    }

    function getFilteredEventsView() {
        return getTemplate("filtered-events");
    }

    return {
        getHomePageView: getHomePageView,
        getLoginView: getLoginView,
        getRegisterView: getRegisterView,
        getLogoutView: getLogoutView,
        getUserView: getUserView,
        getCreateEventView: getCreateEventView,
        getSingleEventView: getSingleEventView,
        getSearchEventView: getSearchEventView,
        getFilteredEventsView: getFilteredEventsView,
        getEditEventView: getEditEventView
    };
}());