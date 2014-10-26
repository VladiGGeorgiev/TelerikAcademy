/// <reference path="jquery-2.0.3.js" />
/// <reference path="requester.js" />
/// <reference path="q.js" />

var Persister = (function() {
    function getStudents (url) {
        var students = Requester.get(url);
        return students;
    }

    return {
        getStudents: getStudents
    };
}());