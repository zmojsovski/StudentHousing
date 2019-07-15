function CreateApt() {
    var serviceUrl = '/Apartment/Create'
    $.ajax({
        type: "POST",
        url: serviceUrl,
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#apsuccmsg").html(data.Message);
            $("#apsuccmsg").removeClass("hidden");
        },
        accept: 'application/json'
    });

}