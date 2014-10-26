var toDoLists = (function(){
	var ToDo = {
		initialize : function(value){
			this.value = value;
		},
		checked : false
	}

	var ToDoLists = {
		toDoList : {},
		addToDo : function(date,value){
			if (!this.toDoList[date]){
				this.toDoList[date] = [];
			}

			var toDoEntry = {};
			$.extend(toDoEntry,ToDo);
			toDoEntry.initialize(value);
			this.toDoList[date].push(toDoEntry);
		},
		getToDoList : function(date){
			return this.toDoList[date];
		}
	}

	function renderToDoList(selector,date){
		$(selector).empty();
		var toDoList = allToDoLists.getToDoList(date);

		for (var toDo in toDoList) {
			var checked = '';
			if (toDoList[toDo].checked){
				checked = 'checked'
			}
			$(selector).prepend('<div class="todo">'
				+ '<div>'
				+ '<input class="check_todo" name="check_todo" id ="'+toDo+'" type="checkbox"' + checked + ' />'
				+ '<label for="'+toDo+'">'+toDoList[toDo].value+'</label>'
				+ '</div>');
		};

		//Attach event 'click' to labels
        $('.todo label').on('click',function(e){
            var index = this.htmlFor;
            markChecked(date,index);
        });
	}

	function markChecked(date,index){
		var toDoList = allToDoLists.getToDoList(date);
		for (var toDo in toDoList) {
			if (toDo === index){
				toDoList[toDo].checked = !toDoList[toDo].checked;
			}
		};
	}
	var allToDoLists = {};
	$.extend(allToDoLists,ToDoLists);

	return {
		allToDoLists : allToDoLists,
		renderToDoList : renderToDoList
	}
})();