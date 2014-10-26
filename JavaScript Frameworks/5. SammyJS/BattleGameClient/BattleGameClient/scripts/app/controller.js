/// <reference path="persister.js" />
/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/q.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/mustache.js" />

define(["mustache", "classjs"], function(Mustache, Class) {
    var Access = Class.create({
        init: function(persister) {
            this.persister = persister;
        },

        loadUI: function(selector) {
            if (this.persister.isLoggedIn()) {
                this.loadGame(selector);
            } else {
                this.loadLogin(selector);
            }

            this.atachUIHandlers(selector);
        },

        loadLogin: function (selector) {
            var template = $("#login-template").html();
            $(selector).html(template);
        },

        loadRegister: function (selector) {
            var template = $("#register-template").html();
            $(selector).html(template);
        },

        loadGame: function(selector) {
            var nickname = this.persister.getNickname();
            
            var logoutHtml =
                '<div id="user-greeting">Hello, <span>' + nickname + '</span></div>' +
                    '<input type="submit" id="logout-button" class=btn value="Logout">';

            var homeButton = '<a href="#/" class="btn">Home</a>';
            var joinGameButtonHtml = '<a href="#/join-game" class="btn">Join games</a>';
            var createdGamesButtonHtml = '<a href="#/my-games" class="btn">My Games</a>';
            var BattleGameButtonHtml = '<a href="#/battle-game" class="btn">Battle</a>';
            $("#header").html(logoutHtml).append(homeButton + joinGameButtonHtml + createdGamesButtonHtml + BattleGameButtonHtml);

            this.loadGameUi("#content");
            
//            this.loadButtons("#header");
//            this.loadScores("#header");
//            this.loadCreateGame(selector);

//            $(selector).append('<div id="sidebar"></div>');
//            $("#sidebar").append('<div id="open-games"></div>');
//            $("#sidebar").append('<div id="active-games"></div>');
//            this.loadOpenGames("#open-games");
//            this.loadActiveGames("#active-games");
//            var self = this;
//            setInterval(function() {
//                self.loadOpenGames("#open-games");
//                self.loadActiveGames("#active-games");
//            }, 500);

           // $(selector).html('<div id="game-ui"></div>');

//            $(selector).append('<div id="messages"></div>');
//            setInterval(function() {
//                var elem = document.getElementById('messages');
//                elem.scrollTop = elem.scrollHeight;
//            }, 300);
//            $("#messages").append('<h2>Messages</h2>');
//            this.loadMessages("#messages");

        },

        loadButtons: function(selector) {
            $(selector).append('<div id="scores-wrapper"></div>');
            $(selector).append('<div id="create-game-wrapper"></div>');
            $(selector + " #scores-wrapper").load("../PartialViews/scores.html");
            $(selector + " #create-game-wrapper").load("../PartialViews/create-game.html");
        },

        loadScores: function(selector) {
            this.persister.user.scores().then(function(data) {
                var list = $('<ol></ul>');

                for (var i = 0; i < data.length; i++) {
                    list.append('<li>' + data[i].nickname + ": " + data[i].score + " points" + '</li>');
                }

                $("#scores-body").html(list);
            });
        },

        loadCreateGame: function(selector) {
            $(selector + " #create-game-wrapper").load("../PartialViews/create-game.html");
        },

        loadOpenGames: function(selector) {
            this.persister.game.open()
                .then(function(data) {
                    var html = '<h2>Open games</h2>';
                    html += '<table class="table">';
                    html += '<tr><th>Title</th><th>Creator</th><th>id</th></tr>';

                    for (var i = 0; i < data.length; i++) {
                        html += '<tr><td>' + data[i].title + '</td><td>' + data[i].creator + '</td><td>' + data[i].id + '</td></tr>';
                    }

                    html += '</table>';

                    $(selector).html(html);
                });
        },

        loadActiveGames: function(selector) {
            this.persister.game.myActive()
                .then(function(data) {
                    var html = '<h2>Active games</h2>';
                    html += '<table class="table">';
                    html += '<tr><th>Title</th><th>Creator</th><th>id</th><th>status</th></tr>';

                    for (var i = 0; i < data.length; i++) {
                        html += '<tr><td>' + data[i].title + '</td><td>' + data[i].creator + '</td><td>' + data[i].id + '</td><td>' + data[i].status + '</td></tr>';
                    }

                    html += '</table>';
                    $(selector).html(html);
                });
        },

        loadMessages: function(selector) {
            var self = this;
            setInterval(function() {
                self.persister.message.unread()
                    .then(function(data) {
                        for (var i = 0; i < data.length; i++) {
                            $(selector).append(data[i]);
                        }
                    });
            }, 2000);
        },

        loadGameUi: function (selector) {
            var template = $("#game-template").html();
            $(selector).html(template);
        },

        atachUIHandlers: function(selector) {
            var content = $(selector);
            var header = $("#header");
            var self = this;

            content.on("click", "#login-button", function () {
                var username = $(selector + " #login-username").val();
                var password = $(selector + " #login-password").val();

                self.persister.user.login(username, password)
                    .then(function() {
                        self.loadGame(selector);
                    }, function (err) {
                        console.log(err);
                        $("#login-reg-errors").html(err.responseJSON.Message);
                    });

                return false;
            });

            content.on("click", "#register-button", function () {
                var username = $(selector + " #reg-username").val();
                var nickname = $(selector + " #reg-nickname").val();
                var password = $(selector + " #reg-password").val();

                self.persister.user.register(username, nickname, password)
                    .then(function () {
                        self.loadGame(selector);
                    }, function(err) {
                        console.log(err);
                        $("#login-reg-errors").html(err.responseJSON.Message);
                    });
                return false;
            });

            header.on("click", "#logout-button", function () {
                self.persister.user.logout()
                    .then(function() {
                        self.loadUI(selector);
                        $("#header").html("");
                    });

                return false;
            });

            content.on("click", "#show-scores", function () {
                self.loadScores("#scores-body");
            });

            content.on("click", "#show-create-game", function () {
                self.loadCreateGame("#create-game-body");
            });

            content.on("click", "#create-game-button", function () {
                var name = $("#create-game-name").val();
                var password = $("#create-game-password").val();
                self.persister.game.create({
                    name: name,
                    password: password || "",
                }).then(function() {
                    $("#messages").append("<p>You are create the game " + name + "</p>");
                }, function(err) {
                    $("#messages").append("<p>" + err.responseJSON.Message + ": " + name + "</p>");
                });
            });
            
            content.on("click", "#open-games tr", function () {
                var id = $(this).children().last().text();
                var name = $(this).children().first().text();

                self.persister.game.join({ gameId: id, password: "" })
                    .then(function() {
                        $("#messages").append("<p>You are joined in game: " + name + "</p>");
                    }, function(err) {
                        $("#messages").append("<p>" + err.responseJSON.Message + ": " + name + "</p>");
                    });
            });

            content.on("click", "#active-games tr", function () {
                var gameId = $(this).children().get(2).innerText;
                var gameName = $(this).children().get(0).innerText;
                var username = $(this).children().get(1).innerText;
                var state = $(this).children().get(3).innerText;
                var myNickname = localStorage.getItem("nickname");

                if (state == "full") {
                    self.persister.game.start(gameId).then(function() {
                        $("#messages").append("<p>You are started game: " + gameName + " with: " + username + "</p>");
                    }, function(err) {
                        $("#messages").append("<p>" + err.responseJSON.Message + ": " + gameName + "</p>");
                    });
                } else if (state == "in-progress") {
                    self.persister.game.field(gameId).then(function(data) {
                        var redUnits = data.red.units;
                        for (var i = 0; i < redUnits.length; i++) {
                            var row = $("#game-ui tr").get(redUnits[i].position.x);
                            var cell = $(row).find("td").eq(redUnits[i].position.y);
                            cell.attr('class', 'red');
                            if (redUnits[i].type == "warrior") {
                                cell.text('W');
                            } else {
                                cell.text('R');
                            }
                        }

                        var blueUnits = data.blue.units;
                        for (var i = 0; i < blueUnits.length; i++) {
                            var row = $("#game-ui tr").get(blueUnits[i].position.x);
                            var cell = $(row).find("td").eq(blueUnits[i].position.y);
                            cell.attr('class', 'blue');
                            if (blueUnits[i].type == "warrior") {
                                cell.text('W');
                            } else {
                                cell.text('R');
                            }
                        }
                    });
                }
            });

            content.on("click", "#game-ui td", function () {
                if ($("#game-ui tr td").hasClass("selected") == false && ($(this).hasClass("red") || $(this).hasClass("blue"))) {

                    $("#game-ui tr td").removeClass("selected");
                    $(this).addClass("selected");
                } else if ($("#game-ui tr td").hasClass("selected") && (!$(this).hasClass("red") || !$(this).hasClass("blue"))) {
                    if (!$("#game-ui tr td").hasClass("moved-cell")) {
                        $(this).addClass("moved-cell");
                    }

                    if ($(".selected").hasClass("red")) {
                        $(".selected").removeClass("red");
                        $(".moved-cell").html($(".selected").html()).addClass("red");
                    }

                    if ($(".selected").hasClass("blue")) {
                        $(".selected").removeClass("blue");
                        $(".moved-cell").html($(".selected").html()).addClass("blue");
                    }

                    if ($(this).hasClass("moved-cell")) {
                        $(this).removeClass("moved-cell");
                    }
                    $(".selected").text("");

                    $(".selected").removeClass("selected");
                    $("#messages").append("<p>You are make move</p>");
                }

            });
        }
    });

    return {
        get: function(dataPersister) {
            return new Access(dataPersister);
        }
    };
});