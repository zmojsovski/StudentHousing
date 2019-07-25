$(document).ready(function () {
    var avgRat = $('.star-ratings-sprite').attr("id");
    $('.star-ratings-sprite-rating').attr('style', 'width:' + (avgRat / 5) * 100 + '%');
});
