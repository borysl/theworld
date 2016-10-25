﻿// site.js

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

    var menuItems = $("ul.menu li a");
    menuItems.on("click", function () {
        var $me = $(this);
        alert("Clicked " + $me.text());
    });

    var $sidebarAndWrapper = $("#sidebar,#wrapper");

    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
    });
})();