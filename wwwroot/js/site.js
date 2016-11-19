// site.js

(function () {
    var ele = $("#username");
    ele.text("Borys Lebeda");

    var main = $("#main");
    main.on("mouseenter", function () {
        $(this).css("background-color", "#888");
    });

    main.on("mouseleave", function () {
        $(this).css("background-color", "");
    });

    var $sidebarAndWrapper = $("#wrapper,#sidebar");

    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $(this).find("i").removeClass("glyphicon-chevron-left").addClass("glyphicon-chevron-right");
        } else {
            $(this).find("i").removeClass("glyphicon-chevron-right").addClass("glyphicon-chevron-left");
        }
    });
})();