$(document).ready(function () {

    $("#CityDDL").change(function () {
        var id = $("#CityDDL").val();
        var cityId = $("#CityDDL").val();
        var name = $("#name").val();
        var availableFrom = $("#availableFrom").val();
        var numberOfBeds = $("#numberOfBeds").val();
        $.get('home/getapartmentsbysearch', { cityId: cityId, name: name, availableFrom: availableFrom, numberOfBeds: numberOfBeds }).done(function (response) {
            $("#cityResults").html(response);
        });
    });

    $("#submit").click(function () {
        var cityId = $("#CityDDL").val();
        var name = $("#name").val();
        var availableFrom = $("#availableFrom").val();
        var numberOfBeds = $("#numberOfBeds").val();
        $.get('home/getapartmentsbysearch', { cityId: cityId, name: name, availableFrom: availableFrom, numberOfBeds: numberOfBeds }).done(function (response) {
            $("#cityResults").html(response);
        });
    });
});
