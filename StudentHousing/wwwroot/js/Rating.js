$(document).ready(function () {

    //$(".rating").hover(function () {
    //    rated = false;

    //    var id = $(this).parent().parent().parent().parent().children(":nth-of-type(2)").children().attr("value");

    //    if (this.id == "1") {
    //        $(this).css("color", "yellow");
    //    }
    //    else if (this.id == "2") {
    //        $("#1").css("color", "yellow");
    //        $(this).css("color", "yellow");
    //    }
    //    else if (this.id == "3") {
    //        $("#1").css("color", "yellow");
    //        $("#2").css("color", "yellow");
    //        $(this).css("color", "yellow");
    //    }
    //    else if (this.id == "4") {
    //        $("#1").css("color", "yellow");
    //        $("#2").css("color", "yellow");
    //        $("#3").css("color", "yellow");
    //        $(this).css("color", "yellow");
    //    }
    //    else if (this.id == "5") {
    //        $("#1").css("color", "yellow");
    //        $("#2").css("color", "yellow");
    //        $("#3").css("color", "yellow");
    //        $("#4").css("color", "yellow");
    //        $(this).css("color", "yellow");
    //    }
    //},
    //    function () {
    //        if (rated == false) {
    //            $("#1").css("color", "grey");
    //            $("#2").css("color", "grey");
    //            $("#3").css("color", "grey");
    //            $("#4").css("color", "grey");
    //            $("#5").css("color", "grey");
    //        }
    //    });

    $(".rating").click(function () {
        event.preventDefault();
        var apartmentId = $(this).parent().parent().parent().parent().children(":nth-of-type(2)").children().attr("value");
        var ratingValueText = $(this).parent().parent().parent().parent().children(":nth-of-type(7)").children();
       // alert(ratingValueText);
        //var apartmentId=0;
        var ratingValue = this.id;
        var avgRating = 0;

        $.ajax({
            url: '/Home/AddRating',
            type: 'POST',
            data: { apartmentId: apartmentId, ratingValue: ratingValue },
            dataType: 'json',
            success: function (data) {
                ratingValueText.text("Average Rating: " + data.toFixed(2));
            },
            error: function (data) {
                alert("not ok");
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