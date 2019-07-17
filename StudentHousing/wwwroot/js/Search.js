$(document).ready(function () {
    var flagPrice = 0;
    var flagRating = 0;

    $("#sortPrice").click(function () {
        event.preventDefault();

        flagPrice = flagPrice + 1;
        flagRating = 0;

        var cityId = $("#CityDDL").val();
        var name = $("#name").val();
        var availableFrom = $("#availableFrom").val();
        var numberOfBeds = $("#numberOfBeds").val();
        $.get('home/getapartmentsbysearch', { cityId: cityId, name: name, availableFrom: availableFrom, numberOfBeds: numberOfBeds, flagPrice: flagPrice, flagRating: flagRating }).done(function (response) {
            $("#cityResults").html(response);
        });
    });

    $("#sortRating").click(function () {
        event.preventDefault();

        flagRating = flagRating + 1;
        flagPrice = 0;

        var cityId = $("#CityDDL").val();
        var name = $("#name").val();
        var availableFrom = $("#availableFrom").val();
        var numberOfBeds = $("#numberOfBeds").val();
        $.get('home/getapartmentsbysearch', { cityId: cityId, name: name, availableFrom: availableFrom, numberOfBeds: numberOfBeds, flagPrice: flagPrice, flagRating: flagRating }).done(function (response) {
            $("#cityResults").html(response);
        });
    });

    $("#CityDDL").change(function () {
        event.preventDefault();

        var cityId = $("#CityDDL").val();
        var name = $("#name").val();
        var availableFrom = $("#availableFrom").val();
        var numberOfBeds = $("#numberOfBeds").val();
        $.get('home/getapartmentsbysearch', { cityId: cityId, name: name, availableFrom: availableFrom, numberOfBeds: numberOfBeds, flagPrice: flagPrice, flagRating: flagRating }).done(function (response) {
            $("#cityResults").html(response);
        });
    });

    $("#submit").click(function () {
        event.preventDefault();

        var cityId = $("#CityDDL").val();
        var name = $("#name").val();
        var availableFrom = $("#availableFrom").val();
        var numberOfBeds = $("#numberOfBeds").val();
        $.get('home/getapartmentsbysearch', { cityId: cityId, name: name, availableFrom: availableFrom, numberOfBeds: numberOfBeds, flagPrice: flagPrice, flagRating: flagRating }).done(function (response) {
            $("#cityResults").html(response);
        });
    });






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
        var ratingValueText = $(this).parent().parent().parent().parent().children(":nth-of-type(7)").children();
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
                ratingValueText.text("Average Rating: " + data.toFixed(2));
            },
            error: function (data) {
                alert("not ok");
            }
        });
        apartments.push(apartmentId);

    });

   
});
