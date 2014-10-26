var imagesRepository = (function () {
    var imagesCount = 3;
    var imagesLoadedCount = 0;

    var background = new Image();
    background.src = "images/background.png";

    var player = new Image();
    player.src = "";

    var bullet = new Image();
    bullet.src = "";

    // Ensure all images have loaded before starting the game
    function imageLoaded() {
        imagesLoadedCount++;
        if (imagesLoadedCount === imagesCount) {
            window.init();
        }
    }

    background.onload = function () {
        imageLoaded();
    }

    player.onload = function () {
        imageLoaded();
    }

    bullet.onload = function () {
        imageLoaded();
    }

    return {
        background: background,
        player: player,
        bullet: bullet
    };
}());
