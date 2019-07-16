$(document).ready(function () {

    $(".rating").click(function () {
        event.preventDefault();
        var apartmentId = 1;
        var ratingValue = this.id;
        var avgRating = 0;
        $.ajax({
            url: '/Home/AddRating',
            type: 'POST',
            dataType: 'json',
            data: { ApartmentId: apartmentId, RatingValue: ratingValue },
            success: function (data) {
                //alert("ok");
            },
            error: function (data) {
               // alert("not ok");
            }
        });

        //$.ajax({
        //    url: '/Home/AddRating',
        //    type: 'GET',
        //    dataType: 'json',
        //    data: { AverageRating: avgRating },
        //    success: function (data) {
        //        alert("ok");
        //    },
        //    error: function (data) {
        //        alert("not ok");
        //    }
        //});

    });
});