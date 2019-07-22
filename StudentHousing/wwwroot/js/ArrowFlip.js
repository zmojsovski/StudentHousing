function PriceFlipOnClick() {
    event.preventDefault();
    $(".arrow-price").toggleClass(".glyphicon glyphicon-arrow-up");
    $(".arrow-price").toggleClass(".glyphicon glyphicon-arrow-down");
}
function RatingFlipOnClick() {
    event.preventDefault();
    $(".arrow-rating").toggleClass(".glyphicon glyphicon-arrow-up");
    $(".arrow-rating").toggleClass(".glyphicon glyphicon-arrow-down");
}