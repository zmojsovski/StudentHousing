//$(document).ready(function () {
//    var apartmentId = 1;
//    $('.rating').on('click', function () {
//        //var a = $(this).val();
//        var value = (".rating").attr("value");
//        alert(value);
//    })
//});



function Test(a) {

    var apartmentId = 1;

    var ratings = {
        ApartmentId: apartmentId,
        RatingValue: a,
    };

    $.ajax({
        type: 'POST',
        url: '/home/addrating',
        headers: {
            'ratings-Requested-With': 'XMLHttpRequest'
        },
        data: ratings,
        contentType: 'application/json',
        success: function (a) {
            alert(a);
        },
        error: function () {
            alert("error");
        }
    })
}