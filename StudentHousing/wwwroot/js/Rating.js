//$(document).ready(function () {
//    var apartmentId = 1;
//    $('.rating').on('click', function () {
//        //var a = $(this).val();
//        var value = (".rating").attr("value");
//        alert(value);
//    })
//});


$(document).ready(function () {

    $(".rating").click(function () {
        
        var apartmentId = 1;
        var ratingValue = this.id;

        $.ajax({
            url: '/Home/AddRating',
            type: 'POST',
            dataType: 'json',
            data: { ApartmentId: apartmentId, RatingValue: ratingValue },
            success: function (data) {
                alert("ok");
            },
            error: function (data) {
                alert("not ok");
            }
        });
    });
});