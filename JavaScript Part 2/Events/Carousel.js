var pictures = ["images/dog.jpg", "images/jiraf.jpg", "images/pig.jpg", "images/dogs.jpg", "images/spider.jpg", "images/tigger.jpg"];

var currentImageIndex = 0;

var wrapper = document.getElementById('carousel');
var leftButton = document.getElementById('left');
var rightButton = document.getElementById('right');

leftButton.addEventListener("click", onLeftBtnClick, false);

rightButton.addEventListener("click", onRightBtnClick, false);

function onLeftBtnClick() {
    if (currentImageIndex == 0) {
        currentImageIndex = pictures.length - 1;
    }

    currentImageIndex--;
    wrapper.style.backgroundImage = "url(" + pictures[currentImageIndex] + ")";
    wrapper.style.opacity = "20%";
}

function onRightBtnClick() {
    if (currentImageIndex == pictures.length - 1) {
        currentImageIndex = 0;
    }

    currentImageIndex++;
    wrapper.style.backgroundImage = "url(" + pictures[currentImageIndex] + ")";
    wrapper.style.opacity = "20%";
}