$(document).ready(function () {
    $("#AvailableFrom").datepicker({
        dateFormat: "mm-dd-yy",
        minDate: -0,
    });
    
});
$("body").on("submit", "#Form1", function () {
    var modal = document.getElementById("myModal");
    var btn = document.getElementById("apartmentcreate");
    var span = document.getElementsByClassName("close")[0];
    btn.onclick = function () {
        modal.style.display = "block";
    }

    span.onclick = function () {
        modal.style.display = "none";
        return false;
    }
    //function AreYouSure(value) {
    //    return value;
    //}
    //window.onclick = function (event) {
    //    if (event.target == modal) {
    //        modal.style.display = "none";
    //    }
    //}
    //return AreYouSure(this.val());
    $("#no").onclick = function () {
        return false;
    }
    $("#yes").onclick = function () {
        return true;
    }
    });

 
$("#description-area").keyup(function () {
    var text = $("#description-area").val();
    var counterot = text.toString().length;
    if (counterot == 500){
        $("#counter").addClass("descriptionwarning");
    }
    else if (counterot < 500) {
        $("#counter").removeClass("descriptionwarning");
    }
    var counterfield = $("#counter").html("Characters: " + counterot +"/500");
});



