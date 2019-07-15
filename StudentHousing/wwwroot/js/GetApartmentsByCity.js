$(document).ready(function () {
    $("#CityDDL").on("change", function () {
        var selectedValue = $("#CityDDL").val();
        console.log(selectedValue);
        

    });

    //$.ajax({
    //    method: 'GET',
    //    url: "@Url.Action("LoadListByCity")",
    //    success: function (data) {
            
    //    }

    //});
});
//function GetApartmentsByCity() {
    

//}