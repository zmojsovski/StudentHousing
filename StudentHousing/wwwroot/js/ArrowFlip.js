function PriceFlipOnClick() {
    //$(".arrow-sort").on("click", function (event) {
    //    $(".arrow-logo").toggleClass(".glyphicon glyphicon-arrow-up");
    //    $(".arrow-logo").toggleClass(".glyphicon glyphicon-arrow-down");
    //});
    event.preventDefault();

    $(".arrow-price").toggleClass(".glyphicon glyphicon-arrow-up");
    $(".arrow-price").toggleClass(".glyphicon glyphicon-arrow-down");
}
function RatingFlipOnClick() {
    //$(".arrow-sort").on("click", function (event) {
    //    $(".arrow-logo").toggleClass(".glyphicon glyphicon-arrow-up");
    //    $(".arrow-logo").toggleClass(".glyphicon glyphicon-arrow-down");
    //});
    event.preventDefault();

    $(".arrow-rating").toggleClass(".glyphicon glyphicon-arrow-up");
    $(".arrow-rating").toggleClass(".glyphicon glyphicon-arrow-down");
}