var randomFromTo = function(from, to){
    return Math.floor(Math.random() * (to - from + 1) + from);
};

var dFrag = document.createDocumentFragment();

for (var i = 0; i < 1000; i++) {
    var div = document.createElement("div");
    var strong = document.createElement("strong");
    strong.innerHTML = "div";
    div.appendChild(strong);

    //Set random Sizes
    var randomWidthNumber = randomFromTo(20, 100);
    var randomHeightNumber = randomFromTo(20, 100);
    div.style.width = randomWidthNumber + "px";
    div.style.height = randomHeightNumber + "px";

    //Background color
    div.style.backgroundColor = getRandomColor();

    //Font color
    div.style.color = getRandomColor();

    //Border styles
    div.style.borderStyle = "solid";
    div.style.borderColor = getRandomColor();
    div.style.borderRadius = randomFromTo(1, 100) + "px";
    div.style.borderWidth = randomFromTo(1, 20) + "px";

    
    //Random position on the screen
    div.style.position = "absolute";
    div.style.top = randomFromTo(0, 600) + "px";
    div.style.left = randomFromTo(0, 1300) + "px";

    dFrag.appendChild(div);
}

document.body.appendChild(dFrag);

function getRandomColor() {
    var red = randomFromTo(0, 255);
    var green = randomFromTo(0, 255);
    var blue = randomFromTo(0, 255);

    var result = "rgb(" + red + "," + green + "," + blue + ")";
    return result;
}