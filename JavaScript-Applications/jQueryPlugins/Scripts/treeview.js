/// <reference path="jquery-2.0.2.js" />
(function ($) {
    $.fn.treeView = function () {
        var ul = $(this);

        this.find("li>ul").hide();

        ul.on("click", "li", function (ev) {
            ev.stopPropagation();
            $(this).find(">ul").toggle(1000);
        });

        return $(this);
    }
})(jQuery);

$(".treeview").treeView();
$(".sub-treeview").treeView();

//(function ($) {
//    $.fn.treeView = function () {
//        $("a").on("click", function () {
//            $(this).next("ul").toggle();
//        });
//        return $(this);
//    }
//})(jQuery);
//$(document).ready(function () {
//    $("ul").hide();
//    $('#treeView').treeView().show();
//    $("ul").parent().children("a").css("color", "red");
//});