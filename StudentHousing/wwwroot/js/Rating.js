$(document).ready(function () {
    var apartments = [];
    var flag = 0;
    var change = true;
    $(".rating").hover(function () {
        flag = 1;
        if (change == true) {
            for (let i = 1; i <= 5; i++) {
                $(this).parents(".apartment-data").children(":nth-of-type(" + i + ")").css("color", "grey");
            }
        }
        var apartmentId = $(this).parents(".apartment - box").attr("id");
        if ((jQuery.inArray(apartmentId, apartments)) == -1 && flag == 1) {
            event.preventDefault();
            $(this).css("color", "yellow");
            $(this).prevUntil().css("color", "yellow");
        }
    },

        function () {
            var apartmentId = $(this).parents(".apartment - box").attr("id");
            if ((jQuery.inArray(apartmentId, apartments)) == -1 && flag == 1) {
                var VAL = $(this).attr("value");
                $(this).css("color", "grey");
                $(this).prevUntil().css("color", "grey");

                var TheColor = $(this).css("color");

                if (TheColor == 'rgb(128, 128, 128)') {
                    $(this).css("color", "grey");
                    $(this).prevUntil().css("color", "grey");
                }    
            }
            change = true;
        });

    $(".rating").click(function () {
        event.preventDefault();
        change = false;
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

    $(".details").click(function () {
        event.preventDefault();
        var id = $(this).parents('.apartment-box').attr("id");
        $.get('home/details', { id: id }).done(function (response) {
            $("html").html(response);
        });
    });
});
