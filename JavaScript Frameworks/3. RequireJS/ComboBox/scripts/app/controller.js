/// <reference path="persister.js" />
/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/q.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/mustache.js" />

define(["app/persister", "mustache"], function(dataPersister, Mustache) {
    var renderStudents = function(container) {
        dataPersister.getStudents("http://localhost:10327/")
            .then(function (data) {
                var studentsTemplate = document.getElementById("students-template").innerHTML;
                var templateCompiled = Mustache.compile(studentsTemplate);

                var output = templateCompiled({ students: data }); //Mustache.render(studentsTemplate, { students: data });
                $(container).html(output);
            });
    };

    var renderMarks = function (container, studentId, studentName) {
        dataPersister.getMarks("http://localhost:10327/", studentId)
            .then(function (data) {
                $(container).html('<div>' + studentName + '</div>');
                var marksTemplate = document.getElementById("marks-template").innerHTML;
                //var templateCompiled = Mustache.compile(studentsTemplate);

                var output = Mustache.render(marksTemplate, { marks: data });
                $(container).append(output);
            });
    };

    return {
        renderStudents: renderStudents,
        renderMarks: renderMarks
    };
})