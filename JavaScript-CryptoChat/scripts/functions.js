var serviceUrl = "http://cryptochat.apphb.com/CryptoChatService.svc/";
$.support.cors = true;

var sessionID;
var Username;
var randomNumber = Math.floor(Math.random() * 999999999);
var secretKey;
//var userData;

// On buttons click do some function
$(document).ready(function () {
    //Login.NavButtonClick();
    $("#reg-nav-btn").on("click", Register.NavButtonClick);
    $("#login-nav-btn").on("click", Login.NavButtonClick);
    $("#logout-nav-btn").on("click", Logout.NavButtonClick);
    $("#input-msg-box").on("click", Message.Send);
    //checkLogin;
});
$(document).keyup(function (e) {
    if ($("#input-msg").is(":focus") && (e.keyCode == 13)) {
        Message.Send();
    }
    $("#msg").submit(function () { return false; });
});


//Call function on every 1 second.
var interval = setInterval(getServerMessage, 1000);

    //Listen for server messages.
    function getServerMessage() {
        if (sessionID != null && sessionID !=  "logout") {
            performGetRequest(serviceUrl + "get-next-message/" + sessionID,
                proccessServerMsg,
                function (err) {
                    var error = JSON.parse(err.responseText);

                    if (error.errorCode == "ERR_SESSIONID") {
                        DisplayErrorMessage("Can not connect to server! Maybe you are logout!");
                        Logout.NavButtonClick();
                        interval = window.clearInterval(interval);
                    }
                    else if (error.errorCode == "ERR_GENERAL") {
                        DisplayErrorMessage("Server error. Can not connect to server!");
                        interval = window.clearInterval(interval);
                    }
                }
            );
        };
    }

    //Proccess diferent server messages
    function proccessServerMsg(data) {
        var challenge = data.msgText;
        var username = data.username;
        var messageType = data.msgType;

        //Go down only when we have a message from server
        if (challenge != null) {
            //If user is going online or offline we reefresh user list.
            if (messageType == "MSG_USER_ONLINE") {
                DisplayInfoMessage("<span>" + username + "</span> logged in the system.");
                UsersList.Refresh();
            }
            else if (messageType == "MSG_USER_OFFLINE") {
                DisplayInfoMessage("<span>" + username + "</span> logged out the system.");
                UsersList.Refresh();
            }
            else if (messageType == "MSG_CHALLENGE") {
                var choice = confirm("Do you want to chat with " + username);
                if (choice) {
                    Username = username;
                    Chat.ResponseInvite(username, challenge);
                }
                else {
                    Chat.Cancel(username);
                }
            }
            else if (messageType == "MSG_RESPONSE") {
                Username = username;
                var decNumber = GibberishAES.dec(challenge, secretKey);

                if (decNumber == (999999999 - randomNumber)) {
                    Chat.Start(username);
                }
                else {
                    Chat.Cancel(username);
                }
            }
            else if (messageType == "MSG_START_CHAT") {
                DisplayInfoMessage("You are starting chat with: " + "<span>" + username + "</span>");
                $("#close-chat-session").removeClass("hidden");
                $("#close-chat-session").on("click", Chat.Cancel);
            }
            else if (messageType == "MSG_CANCEL_CHAT") {
                DisplayInfoMessage(data.msgText + "by: " + "<span>" + username + "</span>");
                $("#close-chat-session").addClass("hidden");
            }
            else if (messageType == "MSG_CHAT_MESSAGE") {
                Message.Recieve(data);
            }
        }
    };

    var Chat = new Object();

    //Send request to start chat
    Chat.Start = function (username) {
        var user = {
            "sessionID": sessionID,
            "recipientUsername": username
        }

        performPostRequest(serviceUrl + "start-chat",
            user,
            function () {
                DisplayInfoMessage("You are start chat with: " + "<span>" + username + "</span>");

                $("#close-chat-session").removeClass("hidden");
                $("#close-chat-session").on("click", Chat.Cancel);
                document.getElementById("chat-messages").innerHTML = "";
            },
            Chat.StartErrors
        );
    }

    //Catch and display possible error on start-chat request
    Chat.StartErrors = function (err) {
        var error = JSON.parse(err.responseText);

        DisplayErrorMessage("You can't start chat. " + error.errorMsg);
    }

    //Send request to cancel chat
    Chat.Cancel = function (username) {
        var data = {
            "sessionID": sessionID,
            "recipientUsername": Username
        };

        performPostRequest(serviceUrl + "cancel-chat",
            data,
            function () {
                DisplayInfoMessage("You are cancel chat with: " + "<span>" + Username + "</span>")
                $("#close-chat-session").addClass("hidden");
            },
            Chat.CancelErrors
        );
    }

    //Catch and display possible error on start-chat request
    Chat.CancelErrors = function (err) {
        var error = JSON.parse(err.responseText);

        if (error.errorCode == "ERR_SESSIONID") {
            DisplayErrorMessage("There is a error with canceling chat. " + error.errorMsg);
        }
        else if (error.errorCode == "ERR_BAD_USER") {
            DisplayErrorMessage("You can't cancel chat with this user. " + error.errorMsg);
        }
        else if (error.errorCode == "ERR_USER_OFF") {
            DisplayErrorMessage( Username + " is offline!");
        }
        else if (error.errorCode == "ERR_GENERAL") {
            DisplayErrorMessage("Can not cancel chat. There is a server error. Please try again.");
        }
    }

    //Get challenge code from user who invite you, decrypting it, crypt again and send it back.
    Chat.ResponseInvite = function (username, challenge) {
        secretKey = prompt("Enter " + username + " secret key:");
        if (R > 999999999 || R < 0) {
            DisplayErrorMessage("The key with " + username + " is wrong!");
        }
        var R = GibberishAES.dec(challenge, secretKey);
        var response = GibberishAES.enc((999999999 - R), secretKey);

        var responseAnswer = {
            "sessionID": sessionID,
            "recipientUsername": username,
            "response": response
        };

        performPostRequest(serviceUrl + "response-chat-invitation",
            responseAnswer,
            function () { console.log("Response send!") },
            Chat.ResponseInviteErrors
        );
    }

    //Catch and display possible errors on cancel chat request.
    Chat.ResponseInviteErrors = function (err) {
        var error = JSON.parse(err.responseText);

        DisplayErrorMessage("You can't send invitation response. " + error.errorMsg);
    }

    //Send invite with secret key when click on some user.
    function onUserClickSendInvite(e) {
        $(".selected").removeClass("selected");
        $(this).addClass("selected");

        secretKey = prompt("Enter your secret key:");

        var challenge = GibberishAES.enc(randomNumber, secretKey);
        var invitedUser = document.querySelector(".selected");
        invitedUser = invitedUser.innerHTML;

        var user = {
            sessionID: sessionID,
            recipientUsername: invitedUser,
            challenge: challenge
        };

        performPostRequest(serviceUrl + "invite-user",
            user,
            DisplayInfoMessage("You are send invite to: " + "<span>" + invitedUser + "</span>"),
            function (err) {
                var error = JSON.parse(err.responseText);
                if (error.errorCode == "ERR_AUTO_CHAT") {
                    DisplayErrorMessage("You can not chat with yourself!");
                }
                else if (error.errorCode == "ERR_USER_OFF") {
                    DisplayErrorMessage("The user is offline!");
                }
                else if (error.errorCode == "ERR_BAD_USER") {
                    DisplayErrorMessage(error.errorMsg);
                }
                else if (error.errorCode == "ERR_SESSIONID") {
                    DisplayErrorMessage(error.errorMsg);
                }
                else if (error.errorCode == "ERR_BAD_CHALL") {
                    DisplayErrorMessage(error.errorMsg);
                }
            }
        );
    }

    var Message = new Object();

    //Get message from input field, encrypt it and send it.
    Message.Send = function () {
        var message = $("#input-msg").val();

        var inputField = document.getElementById("chat-messages");
        inputField.scrollTop = inputField.scrollHeight;
        inputField.innerHTML += '<p class="msg-send"><span>Me: </span>' + message + '</p>';

        var encryptedMessage = GibberishAES.enc(message, secretKey);

        var msgRequest = {
            "sessionID": sessionID,
            "recipientUsername": Username,
            "encryptedMsg": encryptedMessage
        };

        performPostRequest(serviceUrl + "send-chat-message",
            msgRequest,
            function () {},
            Message.SendErrors
        );

        document.getElementById("input-msg").value = "";

    }

    //Recieve message when server have message for me. Decrypt it and display.
    Message.Recieve = function (data) {
        var message = data.msgText;
        var username = data.username;

        var realMessage = GibberishAES.dec(message, secretKey);

        var inputField = document.getElementById("chat-messages");
        inputField.scrollTop = inputField.scrollHeight;
        inputField.innerHTML += '<p class="msg-recieve"><span>' + username + ': </span>' + realMessage + '</p>';
    }

    //Catch and display possible errors on send message request.
    Message.SendErrors = function (err) {
        var error = JSON.parse(err.responseText);

        if (error.errorCode == "ERR_BAD_USER") {
            DisplayErrorMessage("You can't send message. " + error.errorMsg);
        }
        else if (error.errorCode == "ERR_USER_OFF") {
            DisplayErrorMessage("You can't send message. " + error.errorMsg);
        }
        else if (error.errorCode == "ERR_BAD_MSG") {
            DisplayErrorMessage("You can't send message. Maybe message is to long.");
        }
        else if (error.errorCode == "ERR_INVALID_STATE") {
            DisplayErrorMessage("You can't send message. " + error.errorMsg);
        }
        else if (error.errorCode == "ERR_GENERAL") {
            DisplayErrorMessage("You can't send message. Sever error. Maybe you have no active chat session.");
        }
    }

    var UsersList = new Object();

    UsersList.Refresh = function () {
        performGetRequest(serviceUrl + "list-users/" + sessionID,
            UsersList.onLoad,
            UsersList.Errors
        );
    }

    //Display list of online users.
    UsersList.onLoad = function (users) {
        var usersListHTML = '<ul>';

        for (var i = 0; i < users.length; i++) {
            var user = users[i];
            usersListHTML +=
            '<li>' +
                '<a href="#" class="user">' +
                    user +
                '</a>' +
            '</li>';
        }

        usersListHTML += '</ul>';

        $("#users-wrapper").html(usersListHTML);
        $("#users-wrapper ul a").on("click", onUserClickSendInvite);
    }

    //Catch and display possible errors on users list request.
    UsersList.Errors = function (err) {
        var error = JSON.parse(err.responseText);
        if (error.errorCode == "ERR_SESSIONID") {
            DisplayErrorMessage("Can not load the users. Invalid sessionID");
        }
        else {
            DisplayErrorMessage("Can not load the users. There is a server error. Please try again.");
        }
    }

    var Logout = new Object();
    //Hide and show some button on logout
    Logout.NavButtonClick = function () {
        performGetRequest(serviceUrl + "logout/" + sessionID,
            function () {
                $("#logout-nav-btn").addClass("hidden");
                $("#reg-nav-btn").removeClass("hidden");
                $("#login-nav-btn").removeClass("hidden");
                $("#close-chat-session").addClass("hidden");

                var onLoginHTML = '<p>Have a nice day!</p>'

                $("#main-content").html(onLoginHTML);
                $("#users-wrapper").html("");
                $("#msg").addClass("hidden");
                $("aside").addClass("hidden");
                $("footer").addClass("hidden");
                $("#info-messages").addClass("hidden");

                sessionID = "logout";
            },
            Logout.Errors
        );
    }

    //Catch and display possible errors on logout request.
    Logout.Errors = function (err) {
        var error = JSON.parse(err.responseText);

        if (error.errorCode == "ERR_SESSIONID") {
            DisplayErrorMessage("Can not logout. Invalid sessionID");
        }
        else if (error.errorCode == "ERR_GENERAL") {
            DisplayErrorMessage("Can not logout. There is a server error. Please try again.");
        }
    }

    var Login = new Object();
    //Show register form and hide some buttons and fields on register.
    Login.NavButtonClick = function () {
        var loginHTML =
        '<form id="login-form">' +
            '<label for="tb-username">Username:</label>' +
            '<input id="tb-username" type="text" autofocus="autofocus" /><br />' +
            '<label for="tb-pass">Password:</label>' +
            '<input id="tb-pass" type="password" /><br />' +
            '<button id="login-button">Login</button>' +
        '</form>';

        $("#main-content").html(loginHTML);
        $("#login-button").on("click", Login.ButtonClick);
        $("#msg").addClass("hidden");
        $("aside").addClass("hidden");
        $("footer").addClass("hidden");
        $("#info-messages").addClass("hidden");
    }

    //Hash username and password and send request.
    Login.ButtonClick = function (e) {
        var username = $("#tb-username").val();
        var password = $("#tb-pass").val();

        myUsername = username;
        var hashData = CryptoJS.SHA1(username + password);

        var user = {
            "username": username,
            "authCode": hashData.toString()
        }

        //var string = JSON.stringify(user);
        //userData = sessionStorage.setItem("sessionID", string);
        //console.log(userData);

        performPostRequest(serviceUrl + "login",
            user,
            Login.Success,
            Login.Errors
        );
        e.preventDefault();
    }

    //On login display chat and users and some buttons.
    Login.Success = function (data) {
        sessionID = data.sessionID;

        $("#logout-nav-btn").removeClass("hidden");
        $("#reg-nav-btn").addClass("hidden");
        $("#login-nav-btn").addClass("hidden");

        var onLoginHTML = '<div id="chat-messages"></div>';

        $("#main-content").removeClass("hidden");
        $("#msg").removeClass("hidden");
        $("aside").removeClass("hidden");
        $("footer").removeClass("hidden");
        $("#info-messages").removeClass("hidden");
        $("#main-content").html('<header>Çhat with:</header>' + onLoginHTML);
        UsersList.Refresh();

        document.getElementById("chat-messages").value = "";
        document.getElementById("info-msg-container").value = "";
    
    }

    //Catch and display possible errors on login request.
    Login.Errors = function (err) {
        var error = JSON.parse(err.responseText);

        if (error.errorCode == "ERR_INV_LOGIN") {
            DisplayLoginErrors(error.errorMsg);
        }
        else if (error.errorCode == "ERR_GENERAL") {
            DisplayLoginErrors("There is a server error. Please try again later.");
        }
        else if (error.errorCode == "ERR_AUTH_CODE") {
            DisplayLoginErrors(error.errorMsg);
        }
        else if (error.errorCode == "ERR_USR_NAME") {
            DisplayLoginErrors("Invalid username!");
        }

        setTimeout(Login.NavButtonClick, 2000);
    }

    var Register = new Object();
    //Show register form and hide some buttons and fields on register.
    Register.NavButtonClick = function () {
        var regFormHTML =
        '<form id="reg-form">' +
            '<label for="tb-username">Username:</label>' +
            '<input id="tb-username" type="text" autofocus="true"/><br />' +
            '<label for="tb-pass">Password:</label>' +
            '<input id="tb-pass" type="password" /><br />' +
            '<label for="tb-repeat-pass">Repeat Password:</label>' +
            '<input id="tb-repeat-pass" type="password" /><br />' +
            '<button id="reg-button">Register</button>' +
        '</form>';

        $("#main-content").html(regFormHTML);
        $("#reg-button").on("click", Register.SendRegistration);
        $("#msg").addClass("hidden");
        $("aside").addClass("hidden");
        $("footer").addClass("hidden");
        $("#info-messages").addClass("hidden");
    }

    //Hash username and password and send request.
    Register.SendRegistration = function (e) {
        var username = $("#tb-username").val();
        var pass = $("#tb-pass").val();

        if (pass != $("#tb-repeat-pass").val()) {
            DisplayRegisterErrors("Passwords do not match!");
            return;
        }
        if (pass == "") {
            DisplayRegisterErrors("Passwords can't be empty!");
            return;
        }
        if (username == "" || username.length > 30) {
            DisplayRegisterErrors("Username can not be empty or more than 30 symbols!");
            return;
        }

        var hashData = CryptoJS.SHA1(username + pass);

        var user = {
            username: username,
            authCode: hashData.toString()
        }

        performPostRequest(serviceUrl + "register",
            user,
            Login.Success,
            Register.Errors
        );
        e.preventDefault();
    }

    //Catch and display possible errors on register request.
    Register.Errors = function (err) {
        var error = JSON.parse(err.responseText);

        if (error.errorCode == "ERR_DUPLICATE") {
            DisplayRegisterErrors("The username is already taken!");
        }
        else if (error.errorCode == "ERR_USR_NAME") {
            DisplayRegisterErrors("Please insert a valid username!");
        }
        else if (error.errorCode == "ERR_GENERAL") {
            DisplayRegisterErrors("There is a server error. Please try again later.");
        }
        else if (error.errorCode == "ERR_AUTH_CODE") {
            DisplayRegisterErrors(error.errorMsg);
        }

        setTimeout(Register.NavButtonClick, 2000);
    }

    //Display different types of messages.
    function DisplayErrorMessage(message) {
        var infoMsgContainer = document.getElementById("info-msg-container");
        infoMsgContainer.scrollTop = infoMsgContainer.scrollHeight;
        infoMsgContainer.innerHTML += '<p class="error-msg"><span>Error: </span>' + message + '</p>';
    }
    function DisplayInfoMessage(message) {
        var infoMsgContainer = document.getElementById("info-msg-container");
        infoMsgContainer.scrollTop = infoMsgContainer.scrollHeight;
        infoMsgContainer.innerHTML += '<p class="info-msg">Information: ' + message + '</p>';
    }
    function DisplayLoginErrors(message) {
        var errMsgContainer = document.getElementById("login-form");
        errMsgContainer.innerHTML += '<p class="error-msg"><span>Error: </span>' + message + '</p>';
    }
    function DisplayRegisterErrors(message) {
        var errMsgContainer = document.getElementById("reg-form");
        errMsgContainer.innerHTML += '<p class="error-msg"><span>Error: </span>' + message + '</p>';
    }

    //Ajax request to server.
    function performPostRequest(serviceUrl, data, onSuccess, onError) {
        $.ajax({
            url: serviceUrl,
            type: "POST",
            contentType: "application/json",
            timeout: 5000,
            dataType: "json",
            data: JSON.stringify(data),
            success: onSuccess,
            error: onError
        });
    }
    function performGetRequest( serviceUrl, onSuccess, onError) {
        $.ajax({
            url: serviceUrl,
            type: "GET",
            timeout: 5000,
            dataType: "json",
            success: onSuccess,
            error: onError
        });
    }
