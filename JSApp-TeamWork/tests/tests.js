"use strict";

module('todos.js tests');

test('todos.addToDo and todos.getToDoList is correct count added', function() {
	var fixture = $("#fixture");
	var toDo = createToDo("todo-container");
	fixture.append(toDo);
	toDoLists.addToDo("todo 1", "#todo-container", 'test');
	toDoLists.addToDo("todo 2", "#todo-container", 'test');
	toDoLists.addToDo("todo 3", "#todo-container", 'test');
	var actual = toDoLists.getToDoList().length;
	var expected = 3;
	equal(expected, actual);
	toDoLists.clear();
});

test('todos.addToDo and todos.getToDoList is check is correct value added', function() {
	var fixture = $("#fixture");
	var toDo = createToDo("another-todo-container");
	fixture.append(toDo);

	var toDos = ['todo 1', 'todo 24', 'todo 3'];

	for (var i = 0, len = toDos.length; i < len; i++) {
		toDoLists.addToDo(toDos[i], "#another-todo-container", "test");
	}

	var actual = toDos;
	var expected = toDoLists.getToDoList();
	var areWithSameValues = compareToDosValue(expected, actual);
	ok(areWithSameValues);
	toDoLists.clear();
});

function createToDo(toDosContainerId) {
	var toDosAsString = '<div id="' + toDosContainerId + '" class="ui-droppable"><h1><span>ToDo</span></h1>';
	var toDosAsJQuery = $(toDosAsJQuery);

	return toDosAsJQuery;
}

function compareToDosValue(expected, actual) {
	if (actual.length != expected.length) {
		return false;
	}

	for (var i = 0, len = actual.length; i < len; i++) {
		console.log(expected[i].value);
		if (actual[i] != expected[i].value) {
			return false;
		}
	}

	return true;
}