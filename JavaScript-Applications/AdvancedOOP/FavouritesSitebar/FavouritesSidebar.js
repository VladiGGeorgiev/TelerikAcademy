/// <reference path="../Scripts/jquery-2.0.2.js" />
/// <reference path="SchoolRepository/class-create.js" />

var Url = Class.create({
    init: function (title, url) {
        this.title = title;
        this.url = url;
    }
});

var Folder = Class.create({
    init: function (title, urls) {
        this.title = title;
        this.urls = urls;
    }
});

var FavouriteSiteBar = Class.create({
    init: function (folders, urls) {
        this.folders = folders;
        this.urls = urls;
    },

    display: function (containerSelector) {
        var list = document.createElement("ul");
        
        for (var i = 0; i < this.folders.length; i++) {
            var listItem = document.createElement("li");
            listItem.innerHTML = this.folders[i].title;
            
            var subList = document.createElement("ul");
            for (var j = 0; j < this.folders[i].urls.length; j++) {
                var url = this.folders[i].urls[j];
                var subListItem = document.createElement("li");
                var link = document.createElement("a");
                link.setAttribute("href", url.url);
                link.setAttribute("target", "_blank");
                link.innerHTML = url.title;

                subListItem.appendChild(link);
                subList.appendChild(subListItem);
            }

            listItem.appendChild(subList);
            list.appendChild(listItem);
        }

        for (var u = 0; u < this.urls.length; u++) {
            var urlListItem = document.createElement("li");
            var a = document.createElement("a");
            a.setAttribute("href", this.urls[u].url);
            a.innerHTML = this.urls[u].title;
            a.setAttribute("target", "_blank")

            urlListItem.appendChild(a);
            list.appendChild(urlListItem);
        }

        var container = document.getElementById(containerSelector);
        container.appendChild(list);
    },
});