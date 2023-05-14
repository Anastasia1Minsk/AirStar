$(document).ready(function() {
    $(function () {
        rome(DepartureDate, { time: false, weekStart: 1, min: new Date(), initialValue: currentDate, inputFormat: "MM.DD.YYYY" })
            .on('data', function (value) {
                location.href = 'FlightSchedule?date=' + value;
                //http://localhost:4965/Search/FlightSchedule?date=06%2F19%2F2023%2000%3A00%3A00
        });
        
    });

});