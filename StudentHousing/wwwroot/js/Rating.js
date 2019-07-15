$(document).ready(function getRating(a) {

    //var apartmentId = 1;
    //var data = { "ApartmentId": apartmentId, "RatingValue": a };
    //$.ajax({
    //    method: 'POST',
    //    url: 'home/addrating',
    //    data: { ApartmentId: apartmentId, RatingValue: a },           
    //    success: function (data) {
              
    //    },
    //    error: function (error) {
    //        console.log('An error accured!')
    //        console.log(error);
    //    }
    //})
    //alert(a);
    event.preventDefault();

    var apartmentId = 1;
    var data = { "ApartmentId": apartmentId, "RatingValue": a };



    $.ajax({
        method: 'POST',
        url: 'home/addrating',
        data: JSON.stringify(gdata),
        contentType: "application/json",
        success: function (data) {
            console.log("Success");
        },
        error: function (error) {
            console.log('An error accured!')
            console.log(error);
        }
    })
})