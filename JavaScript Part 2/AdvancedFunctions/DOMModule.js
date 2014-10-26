var domModule = (function () {
    var element;
    var MAX_BUFFER_ELEMENTS = 100;
    var bufferElements = [];

    function getElement(selector) {
        return document.querySelector(selector);
    }

    function getElements(selector) {
        return document.querySelectorAll(selector);
    }

    function appendChild(child, selector) {
        element = getElement(selector);
        element.appendChild(child);
    }

    function removeChild(parent, selector) {
        var removeElements = getElements(parent + " " + selector);
        for (var i = 0; i < removeElements.length; i++) {
            element = removeElements[i].parentNode;
            element.removeChild(removeElements[i]);
        }
    }

    function addHandler(selector, eventType, eventHandler) {
        var elements = getElements(selector);
        for (var i = 0; i < elements.length; i++) {
            if (elements[i].addEventListener) {
                elements[i].addEventListener(eventType, eventHandler, false);
            } else {
                element[i].attachEvent("on" + eventType, eventHandler);
            }

        }
    }

    function appendToBuffer(selector, element) {
        if (!bufferElements[selector]) {
            bufferElements[selector] = document.createDocumentFragment();
        }
        bufferElements[selector].appendChild(element);
        if (bufferElements[selector].childNodes.length == MAX_BUFFER_ELEMENTS) {
            var parent = getElement(selector);
            parent.appendChild(bufferElements[selector]);
            bufferElements[selector] = null;
        }
    }

    function appendAllBufferElemends() {
        for (var item in bufferElements) {
            var parent = getElement(item);
            parent.appendChild(bufferElements[item]);
            bufferElements[item] = null;
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
        appendAllBufferElemends: appendAllBufferElemends
    };
})();

var div = document.createElement("div");
div.style.backgroundColor = "#b000be";
div.style.borderRadius = "5px";
div.style.color = "#fff";
div.style.width = "300px";
div.style.height = "20px";
div.style.marginLeft = "20px";
div.innerHTML = "Dynamic added element";
div.style.display = "inline-block";


domModule.addHandler("a.button", 'click', function () {
    domModule.appendChild(div, "#wrapper");
    domModule.appendAllBufferElemends();
    domModule.removeChild("ul", "li:first-child");
});
domModule.appendToBuffer("#main-nav ul", navItem);

var navItem = document.createElement("li");
navItem.innerHTML = "Dynamic added element";