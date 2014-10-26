function Background() {
    this.speed = 1;
    this.draw = function() {
        this.x -= this.speed;
        this.context.drawImage(imagesRepository.background, this.x, this.y);
        this.context.drawImage(imagesRepository.background, this.x - this.canvasWidth, this.y);

        if(this.x <= 0) {
            this.x = this.canvasWidth;
        }
    }

}

Background.prototype = new Drawable();

function Game() {
    this.init = function () {
        this.bgCanvas = document.getElementById("background-canvas");
        if(this.bgCanvas.getContext) {
            this.bgContext = this.bgCanvas.getContext('2d');

            Background.prototype.context = this.bgContext;
            Background.prototype.canvasWidth = this.bgCanvas.width;
            Background.prototype.canvasHeight = this.bgCanvas.height;

            this.background = new Background();
            this.background.init(this.background.canvasWidth, 0);

            return true;
        }
        else {
            return false
        }
    };

    this.start = function () {
        animate();
    }
}

function animate() {
    requestAnimFrame(animate);
    game.background.draw();
}

window.requestAnimFrame = (function () {
    return window.requestAnimationFrame ||
        window.webkitRequestAnimationFrame ||
        window.mozRequestAnimationFrame ||
        window.oRequestAnimationFrame ||
        window.msRequestAnimationFrame ||
        function (callback, element) {
            window.setTimeout(callback, 1000 / 60);
        }
}());

var game = new Game();
function init() {
    if (game.init()) {
        game.start();
    }
}

init();