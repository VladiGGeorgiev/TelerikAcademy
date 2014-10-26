/// <reference path="jquery-1.10.1.js" />
/// <reference path="ProtoClass.js" />
var Slider = Class.create({
    initialize: function(slides) {
        this.index = 0;
        this.slides = slides;
        this.slides.hide();
        this.slides.first().show();
    },
 
    addSlide: function(slide) {
        this.slides.push(slide)
    },

    showNext: function () {
        this.index++;
        if (this.index >= this.slides.length) {
            this.index = 0;
        }
        this.slides.hide();
        var nextItem = $(this.slides[this.index]);
        nextItem.show();
    },
   
    showPrevious: function prev() {
        this.index--;
        if (this.index <= 0 ) {
            this.index = this.slides.length-1;
        }
        this.slides.hide();
        var nextItem = $(this.slides[this.index]);
        nextItem.show();
    }
});
