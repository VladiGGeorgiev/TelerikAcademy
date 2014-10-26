/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
	var ListView = Class.create({
		init: function (itemsSource) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a ListView must be an array!";
			}
			this.itemsSource = itemsSource;
		},
		render: function (template) {
		    var list = document.createElement("table");
		    var listItem = document.createElement("tr");
		    for (var i = 0; i < this.itemsSource.length; i++) {
		        var cell = document.createElement("td");
				var item = this.itemsSource[i];
				cell.innerHTML = template(item);
				listItem.appendChild(cell);
		    }
		    list.appendChild(listItem);
			return list.outerHTML;
		}
	});

    c.getListView = function(itemsSource) {
        return new ListView(itemsSource);
    };
}(controls || {})); 