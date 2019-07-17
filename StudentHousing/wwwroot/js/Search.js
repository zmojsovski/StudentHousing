$(document).ready(function () {
    var sortType = null;
    var sortDirection = null;
    $("#sortPrice").click(function () {
        sortType = "price";
        sortDirection = this.className.split("-")[3];
        var cityId = $("#CityDDL").val();
        var name = $("#name").val();
        var availableFrom = $("#availableFrom").val();
        var numberOfBeds = $("#numberOfBeds").val();
        $.get('home/getapartmentsbysearch', { cityId: cityId, name: name, availableFrom: availableFrom, numberOfBeds: numberOfBeds, sortType: sortType, sortDirection: sortDirection }).done(function (response) {
            $("#cityResults").html(response);
        });
    });

    $("#sortRating").click(function () {
        sortType = "rating";
        sortDirection = this.className.split("-")[3];
        var cityId = $("#CityDDL").val();
        var name = $("#name").val();
        var availableFrom = $("#availableFrom").val();
        var numberOfBeds = $("#numberOfBeds").val();
        $.get('home/getapartmentsbysearch', { cityId: cityId, name: name, availableFrom: availableFrom, numberOfBeds: numberOfBeds, sortType: sortType, sortDirection: sortDirection }).done(function (response) {
            $("#cityResults").html(response);
        });
    });

    $("#CityDDL").change(function () {
        var cityId = $("#CityDDL").val();
        var name = $("#name").val();
        var availableFrom = $("#availableFrom").val();
        var numberOfBeds = $("#numberOfBeds").val();
        $.get('home/getapartmentsbysearch', { cityId: cityId, name: name, availableFrom: availableFrom, numberOfBeds: numberOfBeds, sortType: sortType, sortDirection: sortDirection }).done(function (response) {
            $("#cityResults").html(response);
        });
    });

    $("#submit").click(function () {
        event.preventDefault();

        var cityId = $("#CityDDL").val();
        var name = $("#name").val();
        var availableFrom = $("#availableFrom").val();
        var numberOfBeds = $("#numberOfBeds").val();
        $.get('home/getapartmentsbysearch', { cityId: cityId, name: name, availableFrom: availableFrom, numberOfBeds: numberOfBeds, sortType: sortType, sortDirection: sortDirection }).done(function (response) {
            $("#cityResults").html(response);
        });
    });
   
});
