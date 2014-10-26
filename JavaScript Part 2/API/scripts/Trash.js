var miliseconds = 0;
var milisecInterval;
var seconds = 0;
var minutes = 0;
var timeElapsed;
function startChronometer() {
    milisecInterval = setInterval(chronometer, 10);
}

function chronometer() {
    if (miliseconds == 100) {
        seconds++;
        miliseconds = 0;
    }

    miliseconds++;
    document.getElementById('time').value = seconds + " : " + miliseconds;
}

function resetChronometer() {
    miliseconds = 0;
}

function stopChronometer() {
    clearInterval(milisecInterval);
    timeElapsed = seconds * 100 + miliseconds;
}
//---------------------------------------------------------------
var numberOfGarbage = 9;
var trashedGarbage = 0;
var endGame = false;
var dFrag = document.createDocumentFragment();

for (var i = 1; i <= numberOfGarbage; i++) {
    var currentImage = document.createElement("img");

    currentImage.id = "img" + i;
    currentImage.src = "images/money.png";

    currentImage.setAttribute("draggable", "true");
    currentImage.addEventListener("dragstart", drag, false);

    currentImage.style.position = "absolute";
    currentImage.style.top = i * 40 + "px";
    currentImage.style.left = 250 + "px";
    currentImage.style.width = "70px";

    dFrag.appendChild(currentImage);
}

var trash = document.getElementById("trash");
trash.addEventListener("drop", drop, false);
trash.addEventListener("dragover", onDragOver, false);
trash.addEventListener("dragleave", onDragLeave, false);

document.getElementById("wrapper").appendChild(dFrag);

function drag(ev) {
    //Put id of current dragged element in dataTransfer
    ev.dataTransfer.setData("dragged-id", ev.target.id);
}

function drop(ev) {
    ev.preventDefault();

    var draggedElementId = ev.dataTransfer.getData("dragged-id");
    var currentDraggedElement = document.getElementById(draggedElementId);
    var wrapper = document.getElementById("wrapper");

    wrapper.removeChild(currentDraggedElement);

    ev.target.style.backgroundImage = "url(images/trash-closed.png)";
    trashedGarbage++;
    if (trashedGarbage == 1) {
        startChronometer();
    }
    if (trashedGarbage == numberOfGarbage) {
        stopChronometer();
        //var endTime = (new Date()).getSeconds();
        //var interval = endTime - beginTime;
        addResult(timeElapsed);
    }
}

function onDragOver(ev) {
    ev.preventDefault();
    ev.target.style.backgroundImage = "url(images/trash-open.png)";
    ev.target.style.backgroundSize = "230px";
    ev.target.style.backgroundRepeat = "no-repeat";
}

function onDragLeave(ev) {
    ev.target.style.backgroundImage = "url(images/trash-closed.png)";
}

var getResultsButton = document.getElementById('show-results');
getResultsButton.addEventListener("click", showResults, false);
var resultsContainer = document.getElementById('results');

function showResults() {
    if (!localStorage.length || localStorage.length == 0) {
        resultsContainer.innerHTML = "No results!";
    }

    var resultsArr = [];

    for (var i = 0; i < localStorage.length; i++) {
        var curKey =  localStorage.key(i);
        resultsArr.push([curKey, localStorage.getItem(curKey)]);
    }

    resultsArr.sort(function (a, b) {
        var key1 = parseInt(a[1]);
        var key2 = parseInt(b[1]);
        return key1 - key2;
    })

    var result = "<ol>";
    
    for (var i = 0; i < resultsArr.length; i++) {
        result += 
            '<li>' +
                '<strong>name: </strong>' + resultsArr[i][0] + ', ' + '<strong>points: </strong>' + resultsArr[i][1] + "ms" + 
            '</li>';
    }

    result += '</ol>';
    resultsContainer.innerHTML = result;
}

function addResult(interval) {
    var name = prompt("Your name: ");
    var time = interval;
    localStorage.setItem(name, time);
    showResults();
}

// StopWatch --------------------------------------------------------
