/// <reference path="online-map.js" />
/// <reference path="external/jquery-2.0.2.js" />

var helper = (function () {
    var BASE_API_PATH = 'plus/v1/';

    return {
        /**
         * Hides the sign in button and starts the post-authorization operations.
         *
         * @param {Object} authResult An Object which contains the access token and
         *   other authentication information.
         */
        onSignInCallback: function (authResult) {
            gapi.client.load('plus', 'v1', function () {
                if (authResult['access_token']) {
                    $('#authOps').show('slow');
                    $('#gConnect').hide();
                    helper.profile();
                    $('#profile').show('slow');
                    $('#YouTube').show(1000);
                } else if (authResult['error']) {
                    // There was an error, which means the user is not signed in.
                    // As an example, you can handle by writing to the console:
                    console.log('There was an error: ' + authResult['error']);
                    $('#authResult').append('Logged out');
                    $('#authOps').hide('slow');
                    $('#profile').hide('slow');
                    $('#gConnect').show();
                    $('#YouTube').hide('slow');
                }
            });
        },

        /**
         * Calls the OAuth2 endpoint to disconnect the app for the user.
         */
        disconnect: function () {
            // Revoke the access token.
            $.ajax({
                type: 'GET',
                url: 'https://accounts.google.com/o/oauth2/revoke?token=' +
                    gapi.auth.getToken().access_token,
                async: false,
                contentType: 'application/json',
                dataType: 'jsonp',
                success: function (result) {
                    console.log('revoke response: ' + result);
                    $('#authOps').hide();
                    $('#authResult').empty();
                    $('#profile').hide('slow');
                    $('#gConnect').show();
                    $('#YouTube').hide('slow');
                },
                error: function (e) {
                    console.log(e);
                }
            });
        },

        /**
         * Gets and renders the currently signed in user's profile data.
         */
        profile: function () {
            var request = gapi.client.plus.people.get({ 'userId': 'me' });
            request.execute(function (profile) {
                $('#profile').empty();
                if (profile.error) {
                    $('#profile').append(profile.error);
                    return;
                }
                $('#profile').append(
                    $('<p><img src=\"' + profile.image.url + '\"></p>'));
                $('#profile').append(
                    $('<p>' + profile.displayName + '</p>'));

                console.log("Profile");
                console.log(profile);
            });
        }
    };
})();