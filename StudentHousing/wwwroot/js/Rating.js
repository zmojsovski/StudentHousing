$(document).ready(function () {
    $(".rating").hover(function () {
        event.preventDefault();
        var VAL = $(this).attr("value");
        var Parent = $(this).parent().parent();
        for (let i = 0; i <= VAL; i++) {
            Parent.children(":nth-of-type(" + i + ")").children().css("color", "yellow");
        }
        //alert(VAL);

    },
        function () {
            var Parent = $(this).parent().parent();
            var VAL = $(this).attr("value");
            for (let i = 0; i <= VAL; i++) {
                Parent.children(":nth-of-type(" + i + ")").children().css("color", "grey");
            }
        });

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