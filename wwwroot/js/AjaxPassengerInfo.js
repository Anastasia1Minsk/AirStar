$(document).ready(function () {

    var idFlight = $('#flightId').val();
    var idClass = $('#classId').val() * 1;

    var rates;
    var passengerCount = 0;
    var foodCount = 0;
    var luggageCount = 0;

    passengerCount = $('.addFood').length;

    $('.addFood').click(function () {
        if ($(this).is(':checked')) {
            foodCount++;
        } else {
            foodCount--;
        }
        renderCalculate();
    });

    $('.addLuggage').click(function () {
        if ($(this).is(':checked')) {
            luggageCount++;
        } else {
            luggageCount--;
        }
        renderCalculate();
    });

    var renderCalculate = function () {
        var ticketPrice = rates.find(x => x.id == idClass).price;
        var ticketRender = ticketPrice + ' x ' + passengerCount + ' = ' + (ticketPrice * passengerCount);
        $('#ticket-render').text(ticketRender);

        var foodPrice = rates.find(x => x.rateType == 9).price;
        var foodRender = foodPrice + ' x ' + foodCount + ' = ' + (foodPrice * foodCount);
        $('#food-render').text(foodRender);

        var luggagePrice = rates.find(x => x.rateType == 10).price;
        var luggageRender = luggagePrice + ' x ' + luggageCount + ' = ' + (luggagePrice * luggageCount);
        $('#luggage-render').text(luggageRender);

        var totalTicketPrice = ticketPrice * passengerCount;
        var totalFoodPrice = foodPrice * foodCount;
        var totalLuggagePrice = luggagePrice * luggageCount;
        var totalSum = totalTicketPrice + totalFoodPrice + totalLuggagePrice;
        var totalRender = totalTicketPrice + ' + ' + totalFoodPrice + ' + ' + totalLuggagePrice + ' = ' + totalSum;
        $('#total-render').text(totalRender);
    }

    $.ajax({
        url: '/Reservation/JsonPassengerInformation',
        data: { flightId: idFlight, classId: idClass},
        success: function (response) {
            rates = response;
            renderCalculate();
        }
    });

});