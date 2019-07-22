$(document).ready(function () {
    var flag = 0;
    $(".rating").hover(function () {
        $(this).parent().children().removeClass("yellow").addClass("grey");
        flag = 0;
        $(this).prevUntil().addBack().addClass("yellow");
        $(this).prevUntil().addBack().removeClass("grey");
    },

        function () {
            if (flag == 0) {
                $(this).prevUntil().addBack().toggleClass("yellow");
                $(this).prevUntil().addBack().toggleClass("grey");
            }                                                                    
        });

    $(".rating").click(function () {
        event.preventDefault();
        flag = 1;
        var ratingValue = $(this).attr("value");
        var apartmentId = $(this).parents('.apartment-box').attr("id");
        var avgRatingText = $(this).parents('.apartment-box').find('.totalAverage');
        var ESlabel = $(this).parents('.apartment-box').find('#success-error-message');
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
