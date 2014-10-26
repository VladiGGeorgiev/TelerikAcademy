/*Create a text area and two inputs with type="color"
Make the font color of the text area as the value of the 
first color input
Make the background color of the text area as the value
of the second input
*/

var button = document.getElementById("button");
button.addEventListener("click", function () {
    var firstInputColor = document.getElementById("first").value;
    var secondInputColor = document.getElementById("second").value;

    var textArea = document.getElementById('area');
    textArea.style.color = firstInputColor;
    textArea.style.backgroundColor = secondInputColor;
}, false);