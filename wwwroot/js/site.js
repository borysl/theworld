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

    var $sidebarAndWrapper = $("#sidebar,#wrapper");

    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $(this).text("Show sidebar");
        } else {
            $(this).text("Hide sidebar");
        }
    });
})();