function FillStars() {
    var Rat = $('.star-ratings-sprite').attr("id");
    $('.star-ratings-sprite-rating').attr('style', 'width:' + (Rat/5)*100 + '%');
}
