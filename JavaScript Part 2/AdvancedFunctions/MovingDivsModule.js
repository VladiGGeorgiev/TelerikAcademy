var circButton = document.getElementById('circular');
var rectButton = document.getElementById('rectangular');

circButton.addEventListener("click", function () {
    var container = document.getElementById('wrapper');
    var element = addElement();
    container.appendChild(element);
    rotateElement(element);
    setInterval(function () { rotateElement(element) }, 20);
}, false);

rectButton.addEventListener("click", function () {
    var container = document.getElementById('wrapper');
    var element = addElement();
    element.style.posTop = 200;
    element.style.posLeft = 200;
    container.appendChild(element);
    setInterval(function () { rectangleMoveElement(element) }, 20);
}, false);

//Return new element with random values.
var addElement = function () {

    var div = document.createElement("div");
    div.style.backgroundColor = generateRandomColor();
    div.style.border = "4px solid " + generateRandomColor();
    div.style.fontSize = generateRandomFontSize();
    div.style.width = "20px";
    div.style.height = "20px";
    div.style.position = "absolute";
    div.style.posTop = generateRandomCenterY();
    div.style.posLeft = generateRandomCenterX();
    div.centerX = div.style.posTop + 50;
    div.centerY = div.style.posLeft + 50;
    
    return div;
}

//Random generators functions -->>
var generateRandomColor = function() {
    var red = Math.floor((Math.random()*255)+1);
    var green = Math.floor((Math.random()*255)+1);
    var blue = Math.floor((Math.random()*255)+1);

    var result = "rgb(" + red + "," + green + "," + blue + ")";
    return result;
};

var generateRandomFontSize = function () {
    var fontSize = Math.floor((Math.random() * 30) + 1);
    return fontSize;
};

var generateRandomCenterX = function () {
    return Math.floor((Math.random() * 1300) + 1);
};

var generateRandomCenterY = function () {
    return Math.floor((Math.random() * 500) + 1);
};
// <<--Random generators functions

// Moving elements functions -->>
var rotateElement = function (element) {
    var centerX = element.centerX;
    var centerY = element.centerY;
    element.style.posTop = element.style.posTop - centerX;
    element.style.posLeft = element.style.posLeft - centerY;
    var angle = Math.PI / 12;
    var newTop = Math.cos(angle) * element.style.posTop - Math.sin(angle) * element.style.posLeft;
    var newLeft = Math.sin(angle) * element.style.posTop + Math.cos(angle) * element.style.posLeft;

    element.style.posTop = newTop + centerX;
    element.style.posLeft = newLeft + centerY;
};

var rectangleMoveElement = function (element) {
    //If is in start position go right
    if (element.style.posTop == 200 && element.style.posLeft == 200) {
        element.style.posLeft += 10;
    }

    //Move right on top line
    if (element.style.posLeft < 500 && element.style.posTop == 200) {
        element.style.posLeft += 10;
    }
    //Move down on right line
    else if (element.style.posTop < 500 && element.style.posLeft == 500) {
        element.style.posTop += 10;
    }
    //Move left on bottom line
    else if (element.style.posLeft > 200) {
        element.style.posLeft -= 10;
    }
    //Move up on left line
    else if (element.style.posTop > 200) {
        element.style.posTop -= 10;
    }
};
// <<-- Moving elements functions