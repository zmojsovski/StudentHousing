$(document).ready(function () {
    $("#CityDDL").change(function () {
        var id = $("#CityDDL").val();
        $.get('home/getapartmentsbycity', { id: id }, function (response) {
            $("#cityResults").html(response);
        });
    });
});