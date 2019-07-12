$(function () {
    $(".arrow-sort").on("click", function (event) {
        $(".arrow-logo").toggleClass(".glyphicon glyphicon-arrow-up");
        $(".arrow-logo").toggleClass(".glyphicon glyphicon-arrow-down");
    });
});