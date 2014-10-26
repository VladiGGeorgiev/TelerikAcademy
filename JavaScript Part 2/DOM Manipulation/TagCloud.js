var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress",
    "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript",
    "js", "cms", "html", "javascript", "http", "http", "CMS"]

var tagObjects = [];

for (var i = 0; i < tags.length; i++) {
    var currentTag = {
        name: tags[i],
        repeatsCounter: 1
    };

    var searchResult = searchExistingTag(currentTag.name);

    if (searchResult == -1) {
        tagObjects.push(currentTag);
    }
    else {
        tagObjects[searchResult].length++;
    }
}

tagObjects.sort(function (x, y) {
    if (x.length < y.length) {
        return 1;
    }
    if (x.length > y.length) {
        return -1;
    }
    return 0;
});

var button = document.getElementById("btn");
button.addEventListener("click", 
    function () {
        var minSize = document.getElementById("minFontSize").value;
        var maxSize = document.getElementById("maxFontSize").value;

        generateTagCloud(tagObjects, minSize, maxSize);
    }, false
);

function generateTagCloud(finalTags, minFont, maxFont) {
    var documentFragmenter = document.createDocumentFragment();
    var container = document.getElementById("tags");
    var font = maxFont;

    for (var i = 0; i < finalTags.length; i++) {
        var currentSpan = document.createElement("span");
        currentSpan.innerHTML = finalTags[i].name;
        currentSpan.style.fontSize = font + "px";
        if (font > minFont) {
            font -= 2;
        }
        documentFragmenter.appendChild(currentSpan);
        documentFragmenter.appendChild(document.createElement("br"));
    }

    container.appendChild(documentFragmenter);
}


function searchExistingTag(tagName) {
    for (var i = 0; i < tagObjects.length; i++) {
        if (tagName == tagObjects[i].name) {
            return i;
        }
    }

    return -1;
}
