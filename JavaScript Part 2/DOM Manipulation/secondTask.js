var x0 = 500;
var y0 = 200;
var radius = 50;
var dFrag = document.createDocumentFragment();

for (var i = 0; i <= 20; i+= 5) {
    var currentDiv = document.createElement('div');
    currentDiv.id = i / 5;
    var x = x0 + radius * Math.cos(i);
    var y = y0 + radius * Math.sin(i);

    currentDiv.style.position = "absolute";
    //currentDiv.style.top = y + "px";
    //currentDiv.style.left = x + "px";

    currentDiv.style.width = "20px";
    currentDiv.style.height = "20px";
    currentDiv.style.backgroundColor = "red";
    
    dFrag.appendChild(currentDiv);
}

document.body.appendChild(dFrag);

setInterval(moveDivs, 100);

var angle = 0;

var allDivs = document.getElementsByTagName('div');

setInterval(moveDivs, 100);
function moveDivs() {
    for (i = 0; i < 5; i++) {
        allDivs[i].style.left = Math.cos(angle + 2 * Math.PI / allDivs.length * i) / radius * 5000 + 100 + 'px';
        allDivs[i].style.top = Math.sin(angle + 2 * Math.PI / allDivs.length * i) / radius * 5000 + 100 + 'px';
    }

    angle = angle + 0.1;
}