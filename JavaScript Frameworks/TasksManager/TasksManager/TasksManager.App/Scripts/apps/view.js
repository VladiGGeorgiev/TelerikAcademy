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

    function getCreateAppointment() {
        return getTemplate("create-app");
    }

    function getAllAppointments() {
        return getTemplate("all-appointments");
    }
    
    function getCommingApointmentView() {
        return getTemplate("upcomming-appointments");
    }

    function getTodayAppointmentsView() {
        return getTemplate("today-appointments");
    }

    function getCurrentAppointmentsView() {
        return getTemplate("current-appointments");
    }

    function getAppointmentByDate() {
        return getTemplate("date-appointments");
    }

    function getAllTodoListView() {
        return getTemplate("all-todos");
    }

    function getSingleTodoListView() {
        return getTemplate("single-todo");
    }

    function getCreateTodoListView() {
        return getTemplate("create-todo-list");
    }

    function getCreateTodoView() {
        return getTemplate("create-todo");
    }

    function getHomeView() {
        return getTemplate("home");
    }

    return {
        getHomeView: getHomeView,
        getHomePageView: getHomePageView,
        getLoginView: getLoginView,
        getRegisterView: getRegisterView,
        getLogoutView: getLogoutView,
        getCreateNewApp: getCreateAppointment,
        getAllAppointments: getAllAppointments,
        getCommingApointmentView: getCommingApointmentView,
        getTodayAppointmentsView: getTodayAppointmentsView,
        getCurrentAppointmentsView: getCurrentAppointmentsView,
        getAppointmentByDate: getAppointmentByDate,
        getAllTodoListView: getAllTodoListView,
        getSingleTodoListView: getSingleTodoListView,
        getCreateTodoListView: getCreateTodoListView,
        getCreateTodoView: getCreateTodoView,
    };
}());