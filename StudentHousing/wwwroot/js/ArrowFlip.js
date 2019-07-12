$(function () {
    $(".glyphicon glyphicon-arrow-down").on("click", function () {
        $(this).toggleClass(".glyphicon glyphicon-arrow-up");
        $(this).toggleClass(".glyphicon glyphicon-arrow-down");
    });
});