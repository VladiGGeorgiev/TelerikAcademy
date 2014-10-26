/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/q.js" />

define(["requester"], function(httpRequester) {
    var getStudents = function(rootDomain) {
        return httpRequester.get(rootDomain + "api/students");
    };

    var getMarksByStudent = function(rootDomain, studentId) {
        return httpRequester.get(rootDomain + "api/students/" + studentId + "/marks");
    };

    return {
        getStudents: getStudents,
        getMarks: getMarksByStudent
    };
})