"use strict";

(function () {
    var ele = document.getElementById("username");
    ele.innerHTML = "Vibs Bali";

    var main = document.getElementById("main");
    main.onmouseenter = function () {
        main.style = "background-color: #888;";
    };

    main.onmouseleave = function () {
        main.style = "";
    };
}())