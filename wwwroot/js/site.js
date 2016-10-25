// site.js

var ele = document.getElementById("username");
ele.innerHTML = "Borys Lebeda";

var main = document.getElementById("main");
main.onmouseenter = function () {
    main.style.background = "#888";
};

main.onmouseleave = function () {
    main.style.background = "";
};