$(document).ready(function () {
    $("#AvailableFrom").datepicker({
        dateFormat: "mm-dd-yy",
        minDate: -0,
    });
    
});
    $("body").on("submit", "#Form1", function () {
    return confirm("Are you sure you want to create the apartment?");
      
    });