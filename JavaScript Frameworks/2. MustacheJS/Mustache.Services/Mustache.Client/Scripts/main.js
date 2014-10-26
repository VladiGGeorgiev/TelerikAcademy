/// <reference path="mustache.js" />
/// <reference path="requester.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.3.js" />
/// <reference path="list-view.js" />
/// <reference path="q.js" />

(function () {
    var personTemplate = document.getElementById("students-template").innerHTML;
    
    Persister.getStudents("http://localhost:3848/api/students").then(function (data) {
        var output = Mustache.render(personTemplate, { students: data });
        document.getElementById("content").innerHTML = output;
    });

    $("#content").on("click", ".marks", function () {
        var ul = $(this).children().last();

        var newWindowDocument = window.open().document;
        newWindowDocument.body.innerHTML = ul.html();
        console.log(ul);

//        if (ul.hasClass("hidden")) {
//            $(this).children().last().removeClass("hidden");
//        } else {
//            $(this).children().last().addClass("hidden");
//        }

        return false;
    });
}());