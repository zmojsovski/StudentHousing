$(document).ready(function () {
    $("#AvailableFrom").datepicker({
        dateFormat: "mm-dd-yy",
        minDate: -0,
    });
    
});
    $("body").on("submit", "#Form1", function () {
    return confirm("Are you sure you want to create the apartment?");
    });
 
$("#description-area").keyup(function () {
    var text = $("#description-area").val();
    var counterot = text.toString().length;
    if (counterot > 500){
        $("#counter").addClass("descriptionwarning");
    }
    else if (counterot <= 500) {
        $("#counter").removeClass("descriptionwarning");
    }
    var counterfield = $("#counter").html("Characters: " + counterot +"/500");
});