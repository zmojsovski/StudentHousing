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
        var ratingValue = $(this).attr("id");
        var apartmentId = $(this).parents('.apartment-box').attr("id");
        var avgRatingText = $(this).parents('.apartment-box').find('.totalAverage');
        var ESlabel = $(this).parents('.apartment-box').children().find('#success-error-message');
        $.ajax({
            url: '/Home/AddRating',
            type: 'POST',
            data: { apartmentId: apartmentId, ratingValue: ratingValue },
            dataType: 'json',
            success: function (data) {
                if (data != null && data.success == true) {
                    avgRatingText.text(data.avgRating);
                    ESlabel.text("Successfully rated").css("color", "forestgreen");
                }
            },
            error: function (data) {
                ESlabel.text("Error").css("color", "red");
            }
        });
    });
});
