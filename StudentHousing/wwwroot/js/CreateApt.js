$(document).ready(function () {
    //document.getElementById("coonfirmBox").attr("hidden", "hidden");
    $('#numberofbeds option[value=0]').each(function () {
        $(this).attr("hidden", "hidden");
    });

    $("#AvailableFrom").datepicker({
        dateFormat: "mm-dd-yy",
        minDate: -0,
    });

    $("form").submit(function (e) {

        e.preventDefault();
        var form = this;



        

        if ($('.text-danger').text()=="") {
            doConfirm("Are you ready to submit your Apartment?", function yes() {
                form.submit();
            }, function no() {
                // do nothing
            });
        }
    });

});


//$("body").on("submit", "#Form1", function () {

//    return confirm("Are you ready to submit your Apartment?");
//});

function doConfirm(msg, yesFn, noFn) {
    var confirmBox = $("#confirmBox");
    confirmBox.find(".message").text(msg);
    confirmBox.find(".yes,.no").unbind().click(function () {
        confirmBox.hide();
    });
    confirmBox.find(".yes").click(yesFn);
    confirmBox.find(".no").click(noFn);
    confirmBox.show();
}


$("#description-area").keyup(function () {
    var text = $("#description-area").val();
    var counterot = text.toString().length;
    if (counterot == 500) {
        $("#counter").addClass("descriptionwarning");
    }
    else if (counterot < 500) {
        $("#counter").removeClass("descriptionwarning");
    }
    $("#counter").html("Characters: " + counterot + "/500");
});



