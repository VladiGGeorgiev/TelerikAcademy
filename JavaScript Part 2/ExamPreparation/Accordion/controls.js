var controls = (function () {
    function Accordion(selector) {
        var items = [];
        var accHolder = document.querySelector(selector);

        accHolder.addEventListener("click",
            function (ev) {
                if (!ev) {
                    ev = window.event;
                }
                ev.stopPropagation();
                ev.preventDefault();

                var clickedItem = ev.target;
                if (!(clickedItem instanceof HTMLAnchorElement)) {
                    return;
                }
                
                var sublist = clickedItem.nextElementSibling;
                if (!sublist) {
                    return;
                }

                if (sublist.hasAttribute("class")) {
                    sublist.removeAttribute("class");
                }
                else {
                    sublist.setAttribute("class", "hidden");
                }

                var liItem = clickedItem.parentNode;
                hideAllSiblingsWithoutCurrent(liItem);
            },
        false);

        var itemsList = document.createElement("ul");

        this.add = function (name) {
            var newItem = new Item(name);
            items.push(newItem);
            return newItem;
        }

        this.renderAll = function () {
            while (accHolder.firstChild) {
                accHolder.removeChild(accHolder.firstChild);
            }

            while (itemsList.firstChild) {
                itemsList.removeChild(itemsList.firstChild);
            }

            for (var i = 0, itemsLen = items.length; i < itemsLen; i++) {
                var currentItem = items[i].render();
                itemsList.appendChild(currentItem);
            }

            accHolder.appendChild(itemsList);
            return this;
        };

        this.serialize = function () {
            var serializedItems = [];
            for (var i = 0; i < items.length; i++) {
                serializedItems.push(items[i].serialize());
            }

            return serializedItems;
        }

        var hideAllSiblingsWithoutCurrent = function(currentElement) {
            var list = currentElement.parentNode;

            var liItems = list.childNodes;

            for (var i = 0; i < liItems.length; i++) {
                var a = liItems[i].firstChild;
                if (a.nextElementSibling != null) {
                    if (a.nextElementSibling.nodeName == "UL") {
                        a.nextElementSibling.setAttribute("class", "hidden");
                    }
                }
            }

            currentElement.firstChild.nextElementSibling.removeAttribute("class");
        }
    }

    function Item(name) {
        var items = [];

        this.add = function (name) {
            var newItem = new Item(name)
            items.push(newItem);

            return newItem;
        }

        this.render = function () {
            var currentItem = document.createElement("li");

            currentItem.innerHTML = '<a href="#">' + name + '</a>';
            //var anchor = document.createElement("a");
            //anchor.setAttribute("href", "#");
            //anchor.innerHTML = name;
            //currentItem.appendChild(anchor);

            if (items.length > 0) {
                var subList = document.createElement("ul");
                subList.setAttribute("class", "hidden");

                for (var i = 0, itemsLen = items.length; i < itemsLen; i++) {
                    var subItem = items[i].render();
                    subList.appendChild(subItem);
                }
                currentItem.appendChild(subList);
            }

            return currentItem;
        }

        this.serialize = function () {
            var thisItem = {
                name: name
            };

            if (items.length > 0) {
                var serializedItems = [];
                for (var i = 0; i < items.length; i++) {
                    var serItem = items[i].serialize();
                    serializedItems.push(serItem);
                }

                thisItem.items = serializedItems;
            }

            return thisItem;
        }
    }

    return {
        getAccordion: function (selector) {
            return new Accordion(selector);
        }
    }
}())