$(document).ready(function () {

    var aircrafts;
    var aircraft;
    var aircraftId;

    $(function () {
        rome(DepartureDate, { time: true });
        rome(ArrivalDate, { time: true });
    });

    $('#aircraftId').on("change", function (e) {
        for (var i = 0; i < 3; i++) {
            $('#rate_' + i).hide();
        }

        aircraftId = e.target.value;
        aircraft = aircrafts.find(x => x.id == aircraftId);

        defineSeats();
    });

    $('#luggage').click(function () {
        defineLuggage();
    });

    $('#food').click(function () {
        defineFood();
    });

    $.ajax({
        url: '/Flight/JsonAircraftClasses',
        success: function (response) {
            aircrafts = response;
            prepare();
        }
    });


    function prepare() {
        if (!$('#aircraftId').val()) {
            for (var i = 0; i < 3; i++) {
                $('#rate_' + i).hide();
            }
        } else {
            aircraft = aircrafts.find(x => x.id == $('#aircraftId').val());
            defineSeats();
        }

        defineLuggage();
        defineFood();
    }

    function defineLuggage() {
        if ($('#luggage').is(':checked')) {
            $('#rate_3').show();
        } else {
            $('#rate_3').hide();
            $('#rate_3').children().val(0);
        }
    }

    function defineFood() {
        if ($('#food').is(':checked')) {
            $('#rate_4').show();
        } else {
            $('#rate_4').hide();
            $('#rate_4').children().val(0);
        }
    }

    function defineSeats() {
        if (aircraft.economyClassSeats > 0) {
            $('#rate_0').show();
        } else {
            $('#rate_0').hide();
            $('#rate_0 input').val(0);
        }

        if (aircraft.businessClassSeats > 0) {
            $('#rate_1').show();
        } else {
            $('#rate_1').hide();
            $('#rate_1 input').val(0);
        }

        if (aircraft.firstClassSeats > 0) {
            $('#rate_2').show();
        } else {
            $('#rate_2').hide();
            $('#rate_2 input').val(0);
        }
    }
});