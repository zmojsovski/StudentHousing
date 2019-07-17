$(document).ready(function () {
    var apartments = [];
    var flag = 0;
    $(".rating").hover(function () {
        flag = 1;
        var apartmentId = $(this).parent().parent().parent().parent().children(":nth-of-type(2)").children().attr("value");
        if ((jQuery.inArray(apartmentId, apartments)) == -1 && flag == 1) {
            event.preventDefault();
            var VAL = $(this).attr("value");
            var Parent = $(this).parent().parent();
            for (let i = 0; i <= VAL; i++) {
                Parent.children(":nth-of-type(" + i + ")").children().css("color", "yellow");
            }

        }
        //alert(VAL);

    },

        function () {
            var apartmentId = $(this).parent().parent().parent().parent().children(":nth-of-type(2)").children().attr("value");
            if ((jQuery.inArray(apartmentId, apartments)) == -1 && flag == 1) {
                var Parent = $(this).parent().parent();
                var VAL = $(this).attr("value");
                for (let i = 0; i <= VAL; i++) {
                    Parent.children(":nth-of-type(" + i + ")").children().css("color", "grey");
                }
            }
        });

    $(".rating").click(function () {

        event.preventDefault();
        var apartmentId = $(this).parent().parent().parent().parent().children(":nth-of-type(2)").children().attr("value");
        var ratingValueText = $(this).parent().parent().parent().children(":nth-of-type(2)").children();
        // alert(ratingValueText);
        //var apartmentId=0;
        var ratingValue = this.id;
        var Parent = $(this).parent().parent();
        for (let i = 1; i <= ratingValue; i++) {
            Parent.children(":nth-of-type(" + i + ")").children().css("color", "yellow");
        }

        flag = 0;

        $.ajax({
            url: '/Home/AddRating',
            type: 'POST',
            data: { apartmentId: apartmentId, ratingValue: ratingValue },
            dataType: 'json',
            success: function (data) {
                ratingValueText.text("Average rating: " + data.toFixed(2));
            },
            error: function (data) {
                alert("not ok");
            }
        });
        apartments.push(apartmentId);

    });


});
