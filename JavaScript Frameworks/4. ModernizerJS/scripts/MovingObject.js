var bouncingBalls = (function () {
    var context;
    var canvas;
    var balls = [];

    var addBallButton = document.getElementById("add-ball");
    addBallButton.addEventListener("click", function () {
        var x = getRandomNumber(1, canvas.width);
        var y = getRandomNumber(1, canvas.height);
        var dx = getRandomNumber(1, 10);
        var dy = getRandomNumber(1, 10);
        var color = "rgb(" + getRandomNumber(0, 255) + ", " + getRandomNumber(0, 255) + ", " + getRandomNumber(0, 255) + ")";
        addBall(x, y, dx, dy, color);
    }, false);

    function Ball(x, y, dx, dy, color) {
        this.x = x;
        this.y = y;
        this.dx = dx;
        this.dy = dy;
        this.color = color;
    }

    function addBall(x, y, dx, dy, color) {
        var ball = new Ball(x, y, dx, dy, color);
        balls.push(ball);
    }

    function startGame(canvasID) {
        canvas = document.getElementById(canvasID);
        context = canvas.getContext("2d");

        setInterval(moveBall, 10);
    }

    function moveBall() {
        context.fillStyle = "#fff";
        context.fillRect(0, 0, canvas.width, canvas.height)
        for (var i = 0; i < balls.length; i++) {

            balls[i].x += balls[i].dx;
            balls[i].y += balls[i].dy;

            if ((balls[i].x >= canvas.width)) {
                balls[i].dx = -balls[i].dx;
            }

            if ((balls[i].y >= canvas.height)) {
                balls[i].dy = -balls[i].dy;
            }

            if (balls[i].x <= 0) {
                balls[i].dx = -balls[i].dx;
            }

            if (balls[i].y <= 0) {
                balls[i].dy = -balls[i].dy;
            }

            context.fillStyle = balls[i].color;
            context.fillRect(balls[i].x, balls[i].y, 15, 15);
        }
    }

    function getRandomNumber(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    return {
        addBall: addBall,
        startGame: startGame
    }
}())