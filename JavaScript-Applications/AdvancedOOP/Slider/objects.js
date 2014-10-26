var Image = {
	init: function(title, thumbUrl, imageUrl) {
		this.title = title;
		this.thumbUrl = thumbUrl;
		this.imageUrl = imageUrl;
	}
};

var Button = {
	init: function (id, title) {
		this.id = id;
		this.title = title;
	}
};

var Slider = {
	init: function (containerSelector, images, previousButton, nextButton) {
	    this.container = containerSelector;
	    this.images = images;
		this.previousButton = previousButton;
		this.nextButton = nextButton;
	},

	initializeBigImage: function () {
        
	    var bigImageWrapper = document.createElement('div');
        
	    bigImageWrapper.setAttribute("id", "big-image");

	    var defaultImage = document.createElement("img");
	    defaultImage.setAttribute("src", this.images[0].imageUrl);
	    bigImageWrapper.appendChild(defaultImage);
	    document.getElementById("wrapper").appendChild(bigImageWrapper);
	},

	initializeThumbnails: function () {
	    var thumbMenu = document.createElement("div");
	    thumbMenu.setAttribute("id", "thumbnails");
        
	    var bigImage = document.getElementById("big-image");

        for (var i = 0; i < this.images.length; i++) {
            var currentImage = document.createElement("img");
            currentImage.setAttribute("src", this.images[i].thumbUrl);
            currentImage.setAttribute("alt", this.images[i].title);
            currentImage.data = this.images[i].imageUrl;

            currentImage.addEventListener("click", function () {
                bigImage.firstElementChild.src = this.data;
            }, false);

            thumbMenu.appendChild(currentImage);
        }

        document.getElementById("wrapper").appendChild(thumbMenu);
	},

    initializeButtons: function () {
        var leftBtn = document.createElement("button");
        leftBtn.setAttribute("id", this.previousButton.id);
        leftBtn.setAttribute("title", this.previousButton.title);
        leftBtn.innerHTML = leftBtn.title;
        
        leftBtn.addEventListener("click", function () {
            var slider = document.getElementById("thumbnails");
            var firstThumb = slider.firstChild;
            slider.removeChild(firstThumb);
            slider.appendChild(firstThumb);
        }, false);

        var rightBtn = document.createElement("button");
        rightBtn.setAttribute("id", this.nextButton.id);
        rightBtn.setAttribute("title", this.nextButton.title);
        rightBtn.innerHTML = rightBtn.title;

        rightBtn.addEventListener("click", function () {
            var slider = document.getElementById("thumbnails");
            var firstThumb = slider.firstChild;
            slider.removeChild(firstThumb);
            slider.appendChild(firstThumb);
        }, false);

        var buttonswrapper = document.createElement('div');
        buttonswrapper.appendChild(leftBtn);
        buttonswrapper.appendChild(rightBtn);

        var container = document.getElementById(this.container);
        container.appendChild(buttonswrapper);
    }
};

var Controller = {
    init: function (slider) {
        this.slider = slider;
    },

    showSlider: function () {
        this.slider.initializeBigImage();
        this.slider.initializeThumbnails();
        this.slider.initializeButtons();
    },

};

var prevButton = Object.create(Button);
prevButton.init("previusButton", "Previus");
var nextButton = Object.create(Button);
nextButton.init("nextButton", "Next");
var firstImg = Object.create(Image);
firstImg.init("firstImg", "images/images1-thumb.png", "images/images1.jpg");
var secondImg = Object.create(Image);
secondImg.init("secondImg", "images/images2-thumb.png", "images/images2.jpg");
var thirdImage = Object.create(Image);
thirdImage.init("thirdImage", "images/images3-thumb.png", "images/images3.jpg");
var fourthImage = Object.create(Image);
fourthImage.init("fourthImage", "images/images4-thumb.png", "images/images4.jpg");
var fifthImage = Object.create(Image);
fifthImage.init("fifthImage", "images/images5-thumb.png", "images/images5.jpg");
var sixthImage = Object.create(Image);
sixthImage.init("sixthImage", "images/images6-thumb.png", "images/images6.jpg");


var slider = Object.create(Slider);
slider.init("wrapper", [firstImg, secondImg, thirdImage, fourthImage, fifthImage, sixthImage], prevButton, nextButton);

var sliderControler = Object.create(Controller);
sliderControler.init(slider);
sliderControler.showSlider();