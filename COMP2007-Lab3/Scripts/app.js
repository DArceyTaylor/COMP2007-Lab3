﻿$(document).ready(function () {
    console.log("App Started!");
    $("a.btn.btn-danger.btn-sm").click(function () {
        return confirm("Are you sure you want to delete this record?");
    });
});