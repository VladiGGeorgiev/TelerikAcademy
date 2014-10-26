var toDoLists = (function() {
    var ToDo = {
        initialize: function(value, type) {
            this.value = value;
            this.type = type;
        },
    }

    var ToDoLists = {
        toDoList: {},
        addToDo: function(value, todoSelector) {
            if (!this.toDoList[this.date]) {
                this.toDoList[this.date] = [];
            }

            var toDoEntry = {};
            $.extend(toDoEntry, ToDo);
            toDoEntry.initialize(value, todoSelector);
            this.toDoList[this.date].push(toDoEntry);

            if (!arguments[2]) {
                renderToDo(toDoEntry, todoSelector, this.toDoList[this.date].length - 1);
            }
        },

        clear: function() {
            this.toDoList = {};
        },

        changeDate: function(date) {
            this.date = date;
        },
        getToDoList: function() {
            return this.toDoList[this.date];
        },
    }

    var allToDoLists = {};
    $.extend(allToDoLists, ToDoLists);

    function renderToDo(todo, selector, todoIndex) {
        $(selector).append('<div class="todo" name = "' + todoIndex + '">' + '<p>' + todo.value + '</p>' + '</div>');

        //Drag-drop logic
        $(".todo").draggable({
            revert: "invalid",
            helper: "clone",
            containment: "document",
        });
    }

    function renderToDoList() {
        //$(selector).empty();
        var toDoList = allToDoLists.getToDoList();

        for (var toDo in toDoList) {
            $(toDoList[toDo].type).append('<div class="todo" name = "' + toDo + '">' + '<p>' + toDoList[toDo].value + '</p>' + '</div>');
        };

        //Drag-drop logic
        $(".todo").draggable({
            revert: "invalid",
            helper: "clone",
            containment: "document",
        });
    }

    function configureDragOpitons(todoSelector, progressSelector, doneSelector) {
        configureDrag(todoSelector);
        configureDrag(progressSelector);
        configureDrag(doneSelector);
    }

    function configureDrag(selector) {
        $(selector).droppable({
            accept: ".todo",
            drop: function(event, ui) {
                var $item = ui.draggable;
                if ($item.parent().attr('id') !== $(this).attr('id')) {
                    $item.fadeOut(function() {
                        $item
                            .appendTo($(selector))
                            .fadeIn();
                    });
                }
                allToDoLists.getToDoList()[$item.attr('name')].type = selector;
            },
            tolerance: "intersect",
        });
    }

    return {

        // The flag enableTestMode is added to test enable test for unit
        addToDo: function(value, todoSelector, enableTestMode) {
            allToDoLists.addToDo(value, todoSelector, enableTestMode);
        },
        changeDate: function(date) {
            allToDoLists.changeDate(date);
        },
        getToDoList: function() {
            return allToDoLists.getToDoList();
        },
        // Added for testing purposeses clears the current list of todos
        clear: function() {
            allToDoLists.clear();
        },
        renderToDoList: renderToDoList,
        configureDragOpitons: configureDragOpitons
    }
})();