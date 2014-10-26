var addSomeNode = function () {
    this.appendChild("li");
}

HTMLDivElement.prototype.addNode = addSomeNode;

var controls = (function () {
    function treeView(selectors) {
        var currentSelectors;
        var element;
        var base = this;

        if (selectors.indexOf('.') >= 0) {
            currentSelectors = selectors.split('.');
            element = document.createElement(currentSelectors[0]);
            element.setAttribute('class', currentSelectors[1]);
        }
        else if (selectors.indexOf('#') >= 0) {
            currentSelectors = selectors.split('#');
            element = document.createElement(currentSelectors[0]);
            element.setAttribute('id', currentSelectors[1]);
        }
        else {
            element = document.createElement(currentSelectors[0]);
        }

        var list = document.createElement('ul');
        element.appendChild(list);
        document.body.appendChild(element);

        function addNode() {
            base.treeView.node
        }

        return element;
    }

    

    return {
        treeView: treeView,
    };
})();

var treeView = controls.treeView("div.tree-view");
var jsnode = treeView.addNode();
//jsnode.content("JavaScript");
//var js1subnode = jsnode.addNode();
//js1subnode.content("JavaScript - part 1");
//var js2subnode = jsnode.addNode();
//hs2subnode.content("JavaScript - part 2");
//var jslibssubnode = jsnode.addNode();
//jslibssubnode.content("JS Libraries");
//var jsframeworksnode = jsnode.addNode();
//jsframeworksnode.content("JS Frameworks and UI");

//var webnode = treeView.addNode();
//Webnode.content("Web");