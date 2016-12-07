// site.js

(function () {
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
            $(this).find("i.fa").removeClass("fa-angle-left").addClass("fa-angle-right");
        } else {
            $(this).find("i.fa").removeClass("fa-angle-right").addClass("fa-angle-left");
        }
    });
})();