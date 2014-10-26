/// <reference path="libs/require.js" />
/// <reference path="app/controller.js" />
require.config({
    paths: {
        jquery: "libs/jquery-2.0.3",
        Q: "libs/q",
        controller: "app/controller",
        requester: "libs/requester",
        mustache: "libs/mustache"
    }
});

require(["jquery", "controller"], function($, controller) {
    controller.renderStudents("#wrapper");

    $("#wrapper").on("click", "li a", function() {
        controller.renderMarks("#marks", this.id, $(this).html());

        return false;
    });
});