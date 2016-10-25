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
})();