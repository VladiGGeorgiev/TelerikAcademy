/// <reference path="libs/require.js" />    
/// <reference path="libs/sammy-0.7.4.js" />
/// <reference path="app/controller.js" />

(function() {
    require.config({
        paths: {
            mustache: "libs/mustache",
            q: "libs/q",
            require: "libs/require",
            requester: "libs/requester",
            classjs: "libs/class",
            sha1: "libs/sha1",
            persister: "app/persister",
            controller: "app/controller",
            sammy: "libs/sammy-0.7.4",
            jquery: "libs/jquery-2.0.3"
        }
    });

    require(["persister", "controller", "sammy"], function (dataPersister, controller, sammy) {
        var serviceRoot = "http://localhost:22954/api/";

        var persister = dataPersister.get(serviceRoot);

        var myController = controller.get(persister);

        var app = sammy("#content", function() {
            this.get("#/", function () {
                myController.loadUI("#content");
            });

            this.get("#/register", function() {
                myController.loadRegister("#content");
            });

            this.get("#/login", function () {
                myController.loadLogin("#content");
            });

            this.get("#/join-game", function () {
                myController.loadActiveGames("#content");
            });

            this.get("#/my-games", function () {
                myController.loadOpenGames("#content");
            });

            this.get("#/battle-game", function () {
                myController.loadGameUi("#content");
            });
        });
        
        app.run("#/");
    });
}());