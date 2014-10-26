$(document).ready(function () {
    $("#tree_root a").each(function () {
        if ($(this).parent().find("ul").length > 0) {
            $(this).addClass("expandable").parent().children("ul").hide();
            if ($(this).hasClass("expanded")) {
                $(this).parent().children("ul").show();
            };
        };
    });
    $("#tree_root a.expandable").click(function () {
        $(this).toggleClass("expanded").parent().children("ul").toggle();
    });
});