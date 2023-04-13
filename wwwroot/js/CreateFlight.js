$(document).ready(function () {

    var aircrafts;
    $('#rate_0').hide();
    $('#rate_1').hide();
    $('#rate_2').hide();

    $('#aircraftId').on("change", function (e) {
        var aircraftId = e.target.value;
        $('#rate_0').show();
        debugger;
    });
    

    $.ajax({
        url: '/Flight/JsonAircraftClasses',
        success: function (response) {
            aircrafts = response;
        }
    });

});