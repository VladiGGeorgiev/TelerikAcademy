var controls = (function () {
    function GridView(selector) {
        var gridViewHolder;

        if (selector.nodeName != "TR") {
            gridViewHolder = document.querySelector(selector);
        }
        else {
            gridViewHolder = selector;
        }

        gridViewHolder.addEventListener("click",
            function (ev) {
                if (!ev) {
                    ev = window.event;
                }
                ev.stopPropagation();
                ev.preventDefault();

                var clickedItem = ev.target;

                if (clickedItem.parentNode.nextElementSibling.firstChild.nodeName != "TABLE") {
                    return;
                }

                var sublist = clickedItem.parentNode.nextElementSibling.firstChild;

                if (sublist.hasAttribute("class")) {
                    sublist.removeAttribute("class");
                }
                else {
                    sublist.setAttribute("class", "hidden");
                }
            },
        false);

        var rows = [];
        var table = document.createElement("table");

        this.addRow = function(args) {
            var newRow = new Row(args);
            rows.push(newRow);

            if (selector.nodeName == "TR") {
                table.appendChild(newRow.render());
                gridViewHolder.appendChild(table);
            }

            return newRow;
        }

        this.addHeader = function (args) {
            var newHeader = new Header(args)
            rows.push(newHeader);

            if (selector.nodeName == "TR") {
                table.appendChild(newHeader.render());
                gridViewHolder.appendChild(table);
            }

            return newHeader;
        }

        this.render = function () {
            for (var i = 0; i < rows.length; i++) {
                var currentRow = rows[i].render();
                table.appendChild(currentRow);
            }


            gridViewHolder.appendChild(table);
        }
    }

    function Row(params) {
        var currentRow = document.createElement("tr");
        var selector = 1;
        var rows = [];
        var rowsData = params;
        var nestedTable;

        this.getNestedGridView = function () {
            var newRow = document.createElement("tr");
            document.querySelector("table").appendChild(newRow);
            var nestedGrid = controls.getGridView(newRow);
            return nestedGrid;
        }

        this.addHeader = function (args) {
            var newHeader = new Header(args)
            rows.push(newHeader);

            return newHeader;
        }

        this.addRow = function (args) {
            var newRow = new Row(args);
            rows.push(newRow);

            return newRow;
        }
        
        this.render = function () {

            for (var i = 0; i < rowsData.length; i++) {
                var data = document.createElement("td");
                data.innerHTML = rowsData[i];
                currentRow.appendChild(data);
            }


            return currentRow;
        }
    }

    function Header(params) {
        var headerData = params;
        
        this.render = function () {
            var currentHeader = document.createElement("tr");

            for (var i = 0; i < headerData.length; i++) {
                var data = document.createElement("th");
                data.innerHTML = headerData[i];
                currentHeader.appendChild(data)
            }

            return currentHeader;
        }
    }
    
    function getGridViewData() {

    }

    return {
        getGridView: function (selector) {
            return new GridView(selector);
        },
    }
}());