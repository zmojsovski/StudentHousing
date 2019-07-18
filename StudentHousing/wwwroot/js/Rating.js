﻿$(document).ready(function () {
    var apartments = [];
    var flag = 0;
    $(".rating").hover(function () {
        flag = 1;
        for (let i = 1; i <= 5; i++) {
            $(this).parents(".apartment-data").children(":nth-of-type(" + i + ")").css("color", "grey");
        }
        var apartmentId = $(this).parents(".apartment - box").attr("id");
        if ((jQuery.inArray(apartmentId, apartments)) == -1 && flag == 1) {
            event.preventDefault();
            var VAL = $(this).attr("value");
            for (let i = 1; i <= VAL; i++) {
                $(this).parents(".apartment-data").children(":nth-of-type(" + i + ")").css("color", "yellow");
            }
        }
    },

        function () {
            var apartmentId = $(this).parents(".apartment - box").attr("id");
            if ((jQuery.inArray(apartmentId, apartments)) == -1 && flag == 1) {
                var VAL = $(this).attr("value");
                for (let i = 1; i <= VAL; i++) {
                    $(this).parents(".apartment-data").children(":nth-of-type(" + i + ")").css("color", "grey");
                }

                var TheColor = $(this).css("color");

                if (TheColor == 'rgb(128, 128, 128)') {
                    for (i = VAL; i <= 5; i++)
                        $(this).parents(".apartment-data").children(":nth-of-type(" + i + ")").css("color", "grey");
                }
                
            }
        });

    $(".rating").click(function () {

        event.preventDefault();
        flag = 0;
        var ratingValue = $(this).attr("value");
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
