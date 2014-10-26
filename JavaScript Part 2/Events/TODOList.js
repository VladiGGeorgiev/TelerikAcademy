var addButton = document.getElementById('add-button');
addButton.addEventListener("click", addNote, false);

var showListButton = document.getElementById('show-list');
showListButton.addEventListener("click", showList, false);

var deleteButton = document.getElementById('delete-button');
deleteButton.addEventListener("click", deleteNote, false);

var hideButton = document.getElementById('hide-item');
hideButton.addEventListener("click", hideSelectedNotes, false);

function addNote() {
    var addInputText = document.getElementById('add-input').value;
    if (addInputText == "") {
        throw new Error("Add note in input field!")
    }

    var checkbox = document.createElement('input');
    checkbox.setAttribute("type", "checkbox");

    var span = document.createElement('span');
    span.innerHTML = addInputText;

    var li = document.createElement("li");
    li.appendChild(checkbox);
    li.appendChild(span);

    document.getElementById('result').appendChild(li);
}

function showList() {
    var curNotes = document.querySelectorAll("#result input");

    for (var i = 0; i < curNotes.length; i++) {
        if (curNotes[i].parentNode.hasAttribute("class")) {
            curNotes[i].parentNode.removeAttribute("class");
            curNotes[i].checked = false;
        }
    }
}

function deleteNote() {
    var selectedNotes = document.querySelectorAll("#result input");

    for (var i = 0; i < selectedNotes.length; i++) {
        if (selectedNotes[i].checked == true) {
            var deletedNote = selectedNotes[i].parentNode;
            document.getElementById('result').removeChild(deletedNote);
        }
    }
}

function hideSelectedNotes () {
    var selectedNotes = document.querySelectorAll("#result input");

    for (var i = 0; i < selectedNotes.length; i++) {
        if (selectedNotes[i].checked == true) {
            selectedNotes[i].parentNode.setAttribute("class", "hidden");
        }
    }
    
}
