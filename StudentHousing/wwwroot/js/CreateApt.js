$(document).ready(function () {

    $("#AvailableFrom").datepicker({
        dateFormat: "mm-dd-yy",
        minDate: -0,
    });


    //$("#AvailableFrom").rules("add", {
    //    required: true,
    //    messages: {
    //        required: "The Available From Date is mandatory!",
    //    }
    //});
});