$(function () {
    $("#findBusStopAutoComplete").each(function () {
        var target = $(this);
        target.autocomplete({
            source: target.attr("data-autocomplete-source"),
            select: function (event, ui) {
                $("#idBusStop").val(ui.item.id);
            }
        });
    });
    $("#busStopDeparture").autocomplete({
        source: function (request, response) {
            var autocompleteUrl = '/api/values/' + request.term;
            $.ajax({
                url: autocompleteUrl,
                type: "GET",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (data, id) {
                        return {
                            label: data.Name,
                            value: data.Name,
                            ValueId: data.Id
                        };
                    }));
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    console.log('some error occured', textStatus, errorThrown);
                }
            });
        },
        minLength: 1,
        select: function (event, ui) {
            $("#resultValueDeparture").val(ui.item.ValueId);
        }
    });
    $("#busStopArrival").autocomplete({
        source: function (request, response) {
            var idDeparture = $('#resultValueDeparture').val();
            var autocompleteUrl = '/api/values/' + request.term + '/' + idDeparture;
            $.ajax({
                url: autocompleteUrl,
                type: "GET",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (data, id) {
                        return {
                            label: data.BusStopArrival.Name,
                            value: data.BusStopArrival.Name,
                            ValueId: data.BusStopArrival.Id,
                            VoyageNumber: data.VoyageNumber
                        };
                    }));
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    console.log('some error occured', textStatus, errorThrown);
                }
            });
        },
        minLength: 1,
        select: function (event, ui) {

            $("#resultValueArrival").val(ui.item.ValueId);

            $("li").remove();

            var link = '/api/values/getdatetime/' + ui.item.VoyageNumber;
            $.ajax({
                url: link,
                type: "GET",
                dataType: "json",
                success: function (data) {
                    $.each(data, function (index, item) {
                        $('#list-time').append("<li><a href='/VoyageDatas/BuyOrReserv/" + item.Id + "'>" + item.DepartureDateAndTime + " " + item.ArrivalDateAndTime + "</a></li>");
                    });
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    console.log('some error occured', textStatus, errorThrown);
                }
            });
        }
    });
});