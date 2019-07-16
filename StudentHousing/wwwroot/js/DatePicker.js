$(document).ready(function () {
    $("#AvailableFrom").rules("add", {
        required: true,
        messages: {
            required: "The Available From Date is mandatory!",
        }
    });
    $("#AvailableFrom").datepicker({
        dateFormat: "dd-mm-yy",
        minDate: -0,
    });
});