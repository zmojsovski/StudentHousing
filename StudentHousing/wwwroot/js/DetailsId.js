$(document).ready(function () {
    $(".details").click(function () {
        event.preventDefault();
        var id = $(this).parents('.apartment-box').attr("id");
        $.get('home/details', { id: id }).done(function (response) {
            $("html").html(response);
        });
    });
});