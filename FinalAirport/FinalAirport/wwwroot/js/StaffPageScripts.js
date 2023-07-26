
var loadStaffPageDataIfAuthorised = function () {

    if (isAuthorised()) {
        var tabler = new InterFaceTable();
        tabler.loadAirportsTable();
        tabler.loadTerminalsTable();
        tabler.loadGatesTable();
        tabler.loadFlightStatuses();
        tabler.loadPriceClasses();
        tabler.loadPassengers();
        tabler.loadTickets();

        hideShowStaffInfornmation(false);
    }
};

var requestErrorHandler = function (textStatus, jqXHRstatus, elementName, operationName) {

    let message = textStatus + " " + jqXHRstatus + " occur during " + operationName + ", try again later";

    if (elementName) {
        var content = document.querySelector('#' + elementName);
        content.textContent = message;
        return
    }

    alert(message);
};

var saveUpdateAirportButtonHandler = function () {

    var modalBody = document.getElementById('airportAddEditModal');
    var id = modalBody.querySelector('.airport-id').value;
    var name = modalBody.querySelector('.airport-name').value;
    var city = modalBody.querySelector('.airport-city').value;
    var country = modalBody.querySelector('.airport-country').value;

    let url = "/Airports/CreateNewAirport";

    if (id) {
        url = "/Airports/UpdateAirport";
    }
    else { id = 0 };

    var ajaxParameters = {
        url: url,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: JSON.stringify({
            "id":id,
            "name" : name,
            "city" : city,
            "country" : country
        }),
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                let myModal = new bootstrap.Modal(document.getElementById('airportAddEditModal'), {});
                myModal.toggle();
                return;
            }

            clearModalInputs('airportAddEditModal', ['.airport-id', '.airport-name', '.airport-city', '.airport-country'])

            var tabler = new InterFaceTable();
            tabler.loadAirportsTable();
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'adding/updatinng airport');
        }
    };

    $.ajax(ajaxParameters);
};

var removeAirport = function (id) {

    let data = JSON.stringify({
        "id" : id
    });

    var ajaxParameters = {
        url: "/Airports/RemoveAirport",
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: data,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                return;
            }

            var tabler = new InterFaceTable();
            tabler.loadAirportsTable();
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'removing airport');
        }
    };

    $.ajax(ajaxParameters);
}

var editAirport = function (id, name, city, country) {

    var modalBody = document.getElementById('airportAddEditModal');
    modalBody.querySelector('.airport-id').value = id;
    modalBody.querySelector('.airport-name').value = name;
    modalBody.querySelector('.airport-city').value = city;
    modalBody.querySelector('.airport-country').value = country;

    var myModal = new bootstrap.Modal(modalBody);
    myModal.toggle();
};

var setButtonHandlerWithIDParameter = function (content, buttonSearchID, handler) {

    var buttons = content.querySelectorAll(buttonSearchID);

    for (var button of buttons) {
        let row = button.closest('tr');
        let id = row.getAttribute("id");
        button.onclick = () => handler(id);
    }
};

var setButtonHandlerWithIDAndParameters = function (content, buttonSearchID, handler, handlerParameters) {

    var buttons = content.querySelectorAll(buttonSearchID);

    for (var button of buttons) {
        let row = button.closest('tr');
        let id = row.getAttribute("id");

        let expression = "button.onclick = () => handler(id,";

        if (handlerParameters) {

            let counter = 0;

            for (let par of handlerParameters) {

                counter++;

                if (par.index != undefined)
                    expression += "row.childNodes[" + par.index + "].innerText";
                else 
                    expression += 'row.getAttribute("' + par.name + '")';

                if (counter != (handlerParameters.length)) {
                    expression += ',';
                }
            }
        }

        expression += ");"

        eval(expression);
    }
};

var clearModalInputs = function (modalName, inputs) {

    var modalBody = document.getElementById(modalName);

    for (let inputField of inputs) {

        let input = modalBody.querySelector(inputField);

        if (input.type == 'select-one')
            input.value = 0;
        else
            input.value = "";
    };
};

var fillAirportsDropDownList = function (data, menuId) {

    var menu = document.getElementById(menuId);

    let menuHtml = "";

    menuHtml += '<option value="0">Not selected</option>';

    for (let airportItem of data) {
        menuHtml += '<option value="' + airportItem.id + '">' + airportItem.name + ' (' + airportItem.city + ', ' + airportItem.country + ')</option>';
    }

    menu.innerHTML = menuHtml;
};

var saveUpdateTerminalButtonHandler = function () {

    var modalBody = document.getElementById('terminal-add-edit-modal');
    var id = modalBody.querySelector('.terminal-id').value;
    var name = modalBody.querySelector('.terminal-name').value;
    var airport = modalBody.querySelector('#terminal-airports-selection-list');
    var airportId = airport.value;
    var airportName = airport.options[airport.selectedIndex].text;

    let url = "/Terminals/CreateNewTerminal";

    if (id)
        url = "/Terminals/UpdateTerminal";
    else id = 0;

    let terminal = {
        id,
        name,
        airportId,
        airportName
    };

    var ajaxParameters = {
        url: url,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: JSON.stringify(terminal),
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                let myModal = new bootstrap.Modal(document.getElementById('terminal-add-edit-modal'), {});
                myModal.toggle();
                return;
            }

            clearModalInputs('terminal-add-edit-modal', ['.terminal-id', '.terminal-name']);

            var tabler = new InterFaceTable();
            tabler.loadTerminalsTable();
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'adding/updatinng terminal');
        }
    };

    $.ajax(ajaxParameters);
};

var removeTerminal = function (id) {

    let data = JSON.stringify({
        "id": id
    });

    var ajaxParameters = {
        url: "/Terminals/RemoveTerminal",
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: data,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                return;
            }

            var tabler = new InterFaceTable();
            tabler.loadTerminalsTable();
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'removing terminal');
        }
    };

    $.ajax(ajaxParameters);

};

var editTerminal = function (id, name, airportId) {

    var modalBody = document.getElementById('terminal-add-edit-modal');
    modalBody.querySelector('.terminal-id').value = id;
    modalBody.querySelector('.terminal-name').value = name;
    modalBody.querySelector('#terminal-airports-selection-list').value = airportId;

    var myModal = new bootstrap.Modal(modalBody);
    myModal.toggle();
};

var fillTerminalsDropDownList = function (data, menuId, selectedValue) {

    var menu = document.getElementById(menuId);

    let menuHtml = "";

    menuHtml += '<option value="0">Not selected</option>';

    for (let terminalItem of data) {
        menuHtml += '<option value="' + terminalItem.id + '">' + terminalItem.name + ' (' + terminalItem.airportName + ')</option>';
    }

    menu.innerHTML = menuHtml;

    if (selectedValue != undefined)
        menu.value = selectedValue;
};

var saveUpdateGateButtonHandler = function () {

    let modalBody = document.getElementById('gate-add-edit-modal');
    let id = modalBody.querySelector('.gate-id').value;
    let name = modalBody.querySelector('.gate-name').value;

    let terminal = modalBody.querySelector('#gate-terminal-selection-list');
    let terminalID = terminal.value;
    let terminalName = terminal.options[terminal.selectedIndex].text;

    let url = "/Gates/CreateNewGate";

    if (id)
        url = "/Gates/UpdateGate";
    else
        id = 0;


    let gate = JSON.stringify({
        "id": id,
        "name": name,
        "terminalId": terminalID
    });

    var ajaxParameters = {
        url: url,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: gate,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                return;
            }

            var tabler = new InterFaceTable();
            tabler.loadGatesTable();
            clearModalInputs('gate-add-edit-modal', ['.gate-id', '.gate-name']);
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'Adding/updating gate');
        }
    };

    $.ajax(ajaxParameters);
};

var removeGate = function (id) {

    let data = JSON.stringify({
        "id": id
    });

    var ajaxParameters = {
        url: "/Gates/RemoveGate",
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: data,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                return;
            }

            var tabler = new InterFaceTable();
            tabler.loadGatesTable();
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'removing gate');
        }
    };

    $.ajax(ajaxParameters);
};

var editGate = function (id, name, terminalID) {

    var modalBody = document.getElementById('gate-add-edit-modal');
    modalBody.querySelector('.gate-id').value = id;
    modalBody.querySelector('.gate-name').value = name;
    modalBody.querySelector('#gate-terminal-selection-list').value = terminalID;

    var myModal = new bootstrap.Modal(modalBody);
    myModal.toggle();
};

var changeTerminalsList = function (listId, airportId, selectedValue) {

    if (airportId == 0) {

        fillTerminalsDropDownList([], listId);
        return;
    };

    let data = JSON.stringify({
        "id": airportId
    });

    var ajaxParameters = {
        url: "/Terminals/GetTerminalsByAirport",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: data,
        beforeSend: beforeSendCRUD,
        success: function (response) {

           fillTerminalsDropDownList(response, listId, selectedValue);
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'Filling terminals list');
        }
    };

    $.ajax(ajaxParameters);
};

var changeGatesList = function (listId, terminalId, selectedValue) {

    if (terminalId == 0) {

        fillGatesDropDownList([], listId);
        return;
    };

    let data = JSON.stringify({
        "id": terminalId
    });

    var ajaxParameters = {
        url: "/Gates/GetGatesByTerminal",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: data,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            fillGatesDropDownList(response, listId, selectedValue);
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'Filling gates list');
        }
    };

    $.ajax(ajaxParameters);
};

var fillGatesDropDownList = function (data, menuId, selectedValue) {

    var menu = document.getElementById(menuId);

    let menuHtml = "";

    menuHtml += '<option value="0">Not selected</option>';

    for (let gateItem of data) {
        menuHtml += '<option value="' + gateItem.id + '">' + gateItem.name + ' (' + gateItem.terminalName + ')</option>';
    }

    menu.innerHTML = menuHtml;

    if (selectedValue != undefined)
        menu.value = selectedValue;
};

var saveFlight = function () {

    let modalBody = document.getElementById('flight-add-edit-modal');
    let id = modalBody.querySelector('.flight-id').value;
    let flightNumber = modalBody.querySelector('.flight-number').value;
    let departureDate = modalBody.querySelector('.departure-date').value.toLocaleString('ua-UA');
    let arrivalDate = modalBody.querySelector('.arrival-date').value.toLocaleString('ua-UA');

    let departureAirportID = modalBody.querySelector('#flight-departure-airport-selection-list').value;
    let arrivalAirportID = modalBody.querySelector('#flight-arrival-airport-selection-list').value;

    let departureTerminalID = modalBody.querySelector('#flight-departure-terminal-selection-list').value;
    let arrivalTerminalID = modalBody.querySelector('#flight-arrival-terminal-selection-list').value;

    let departureGateID = modalBody.querySelector('#flight-departure-gate-selection-list').value;
    let arrivalGateID = modalBody.querySelector('#flight-arrival-gate-selection-list').value;

    let url = "/Flights/CreateNewFlight";

    if (id)
        url = "/Flights/UpdateFlight";
    else
        id = 0;

    let flight = JSON.stringify({
        "id": id
        , "flightNumber": flightNumber
        , "departureDateTime": departureDate
        , "arrivalDateTime": arrivalDate
        , "departureAirportID": departureAirportID
        , "departureAirportID": departureAirportID
        , "arrivalAirportID": arrivalAirportID
        , "departureTerminalID": departureTerminalID
        , "arrivalTerminalID": arrivalTerminalID
        , "departureGateID": departureGateID
        , "arrivalGateID": arrivalGateID
    });

    var ajaxParameters = {
        url: url,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: flight,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                return;
            }

            //var tabler = new InterFaceTable();
            //tabler.loadFlightsPanel();
            clearModalInputs('flight-add-edit-modal',
                [
                    '.flight-id'
                    , '.flight-number'
                    , '.departure-date'
                    , '.arrival-date'
                    , '.flight-departure-airport-selection-list'
                    , '.flight-arrival-airport-selection-list'
                    , '.flight-departure-terminal-selection-list'
                    , '.flight-arrival-terminal-selection-list'
                    , '.flight-departure-gate-selection-list'
                    , '.flight-arrival-gate-selection-list'
                ]);

            changeFlightEditModalElemendtsVision(true);
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'Adding/updating flight');
        }
    };

    $.ajax(ajaxParameters);
};

var saveFlightStatus = function () {

    let modalBody = document.getElementById('flightStatus-add-edit-modal');
    let id = modalBody.querySelector('.flightStatus-id').value;
    let name = modalBody.querySelector('.flightStatus-name').value;
    let secondsTo = modalBody.querySelector('.flightStatus-secondsTo').value;
    let relatedTo = modalBody.querySelector('.flightStatus-relatedTo').value;

    let url = "/FlightStatuses/CreateNewFlightStatus"

    if (id)
        url = "/FlightStatuses/UpdateFlightStatus"
    else id = 0;

    let flightStatus = JSON.stringify({
        "id": id,
        "name": name,
        "secondsTo": secondsTo,
        "arrival": relatedTo == "true"
    });

    var ajaxParameters = {
        url: url,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: flightStatus,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                return;
            }

            var tabler = new InterFaceTable();
            tabler.loadFlightStatuses();
            clearModalInputs('flightStatus-add-edit-modal',
                [
                    '.flightStatus-id'
                    , '.flightStatus-name'
                    , '.flightStatus-secondsTo'
                    , '.flightStatus-relatedTo'
                ]);
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'Adding/updating flight status');
        }
    };

    $.ajax(ajaxParameters);
};

var removeFlightStatus = function (id) {

    let data = JSON.stringify({
        "id": id
    });

    var ajaxParameters = {
        url: "/FlightStatuses/RemoveFlightStatus",
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: data,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                return;
            }

            var tabler = new InterFaceTable();
            tabler.loadFlightStatuses();
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'removing flight status');
        }
    };

    $.ajax(ajaxParameters);
    
};

var editFlightStatus = function (id, name, secondsTo, relatedTo) {

    let modalBody = document.getElementById('flightStatus-add-edit-modal');
    modalBody.querySelector('.flightStatus-id').value = id;
    modalBody.querySelector('.flightStatus-name').value = name;
    modalBody.querySelector('.flightStatus-secondsTo').value = secondsTo;
    modalBody.querySelector('.flightStatus-relatedTo').value = relatedTo == "Arrival";

    var myModal = new bootstrap.Modal(modalBody);
    myModal.toggle();
};

var changeFlightEditModalElemendtsVision = function  (hiddenFlag) {

    let modalBody = document.getElementById('flight-add-edit-modal');
    let removeButton = modalBody.querySelector('#remove-flight');
    removeButton.hidden = hiddenFlag;

    let flightsList = modalBody.querySelector('#flight-selection-row');
    flightsList.hidden = hiddenFlag;

    clearFlightMidalFields();

    if (!hiddenFlag) {

        $.ajax(
            {
                url: "/Flights/GetFlights",
                type: "GET",

                success: function (result) {

                    fillFlightsDropDownList(result, 'flights-selection-list');
                },

                error: function (jqXHR, textStatus, errorThrown) {

                    requestErrorHandler(textStatus, jqXHR.status, 'flights-selection-list', 'loading Flights');
                }
            });
    }
};

var clearFlightMidalFields = function () {

    clearModalInputs('flight-add-edit-modal',
        [
            '.flight-id',
            '.flight-number',
            '.departure-date',
            '.arrival-date',
            '#flight-departure-airport-selection-list',
            '#flight-arrival-airport-selection-list'
        ]);

    fillTerminalsDropDownList([], 'flight-departure-terminal-selection-list');
    fillTerminalsDropDownList([], 'flight-arrival-terminal-selection-list');

    fillGatesDropDownList([], 'flight-departure-gate-selection-list');
    fillGatesDropDownList([], 'flight-arrival-gate-selection-list');
};

var changeFlightslsList = function (listId, flightId) {

    let priceList = document.getElementById('price-list-block');

    if (flightId == 0) {

        clearFlightMidalFields();

        priceList.hidden = true;

        return;
    }

    priceList.hidden = false;

    loadFlightByID(flightId, fillFlightModal);
};

var loadFlightByID = function (flightId, sucessHandler) {

    let ajaxParameters = {
        url: "/Flights/GetFlightByID?id=" + flightId,
        type: "GET",
        cache: false,
        //beforeSend: beforeSendCRUD,
        success: sucessHandler,

        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'getting flight by id');
        }
    };

    $.ajax(ajaxParameters); 

};

var fillFlightsDropDownList = function (data, menuId) {

    var menu = document.getElementById(menuId);

    let menuHtml = "";

    menuHtml += '<option value="0">Not selected</option>';

    for (let flightItem of data) {
        menuHtml += '<option value="' + flightItem.id + '">' + flightItem.flightNumber + ' (' + flightItem.departureDateTime + ' ' + flightItem.departureAirport + ' - ' + flightItem.arrivalDateTime + ' ' + flightItem.arrivalAirport + ')</option>';
    }

    menu.innerHTML = menuHtml;
};

var removeFlight = function () {

    let modalBody = document.getElementById('flight-add-edit-modal');
    let id = modalBody.querySelector('.flight-id').value;

    if (!id) {
        alert("Flight not selected");
        return;
    };


    let data = JSON.stringify({
        "id": id
    });

    var ajaxParameters = {
        url: "/Flights/RemoveFlight",
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: data,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'removing flight status');
        }
    };

    $.ajax(ajaxParameters);

};

var fillFlightModal = function (flight) {

    changeTerminalsList('flight-departure-terminal-selection-list', flight.departureAirportID, flight.departureTerminalID);
    changeTerminalsList('flight-arrival-terminal-selection-list', flight.arrivalAirportID, flight.arrivalTerminalID);

    changeGatesList('flight-departure-gate-selection-list', flight.departureTerminalID, flight.departureGateID);
    changeGatesList('flight-arrival-gate-selection-list', flight.arrivalTerminalID, flight.arrivalGateID);

    let modalBody = document.getElementById('flight-add-edit-modal');
    modalBody.querySelector('.flight-id').value = flight.id;
    modalBody.querySelector('.flight-number').value = flight.flightNumber;
    modalBody.querySelector('.departure-date').value = flight.departureDateTime;
    modalBody.querySelector('.arrival-date').value =  flight.arrivalDateTime;

    modalBody.querySelector('#flight-departure-airport-selection-list').value = flight.departureAirportID;
    modalBody.querySelector('#flight-arrival-airport-selection-list').value = flight.arrivalAirportID;

    let tabler = new InterFaceTable();
    tabler.loadPriceList(flight.id);
};

var savePriceClass = function () {

    let modalBody = document.getElementById('priceClasses-add-edit-modal');
    let id = modalBody.querySelector('.priceClass-id').value;
    let name = modalBody.querySelector('.priceClass-name').value;

    let url = '/PriceClasses/CreateNewPriceClass';

    if (id)
        url = '/PriceClasses/UpdatePriceClass';
    else id = 0;

    let priceClass = JSON.stringify({
        "id": id,
        "name": name
    });

    let ajaxParameters = {
        url: url,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: priceClass,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                return;
            }

            var tabler = new InterFaceTable();
            tabler.loadPriceClasses();

            clearModalInputs('priceClasses-add-edit-modal', ['.priceClass-id', '.priceClass-name']);
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'adding/updateing price class');
        }
    };

    $.ajax(ajaxParameters);
};

var removePriceClasses  = function (id) {

    let data = JSON.stringify({
        "id": id
    });

    var ajaxParameters = {
        url: "/PriceClasses/RemovePriceClass",
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: data,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                return;
            }

            var tabler = new InterFaceTable();
            tabler.loadPriceClasses();
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'removing price class');
        }
    };

    $.ajax(ajaxParameters);
}

var editPriceClasses = function (id, name) {

    var modalBody = document.getElementById('priceClasses-add-edit-modal');
    modalBody.querySelector('.priceClass-id').value = id;
    modalBody.querySelector('.priceClass-name').value = name;

    var myModal = new bootstrap.Modal(modalBody);
    myModal.toggle();
};

var fillPriceClassSelectionList = function (data, selectedValue) {

    var menu = document.getElementById('price-class-selection-list');

    let menuHtml = "";

    menuHtml += '<option value="0">Not selected</option>';

    for (let priceClassItem of data) {
        menuHtml += '<option value="' + priceClassItem.id + '">' + priceClassItem.name + '</option>';
    }

    menu.innerHTML = menuHtml;

    if (selectedValue != undefined)
        menu.value = selectedValue;
};

var savePrice = function () {

    let flightModalBody = document.getElementById('flight-add-edit-modal');
    let flightId = flightModalBody.querySelector('.flight-id').value;

    let modalBody = document.getElementById('price-add-edit-modal');
    let id = modalBody.querySelector('.price-id').value;
    let priceDate = modalBody.querySelector('.price-date').value;
    let priceClassID = modalBody.querySelector('#price-class-selection-list').value;
    let pricePrice = modalBody.querySelector('.price-price').value;

    //alert('id ' + id + ' priceDate ' + priceDate + ' priceClassID ' + priceClassID + ' pricePrice ' + pricePrice + ' flightId ' + flightId);

    let url = "/PriceList/CreateNewPrice";

    if (id)
        url = "/PriceList/UpdatePrice";
    else id = 0;

    let price = JSON.stringify({
        "id": id
        , "flightId": flightId
        , "date": priceDate
        , "priceClassId": priceClassID
        , "price": pricePrice

    });

    var ajaxParameters = {
        url: url,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: price,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                return;
            }

            let tabler = new InterFaceTable();
            tabler.loadPriceList(flightId);

            clearModalInputs('price-add-edit-modal', ['.price-id', '.price-date', '#price-class-selection-list', '.price-price']);
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'adding  price ');
        }
    };

    $.ajax(ajaxParameters);
};

var removePrice = function (id) {

    let data = JSON.stringify({
        "id": id
    });

    var ajaxParameters = {
        url: "/PriceList/RemovePrice",
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: data,
        beforeSend: beforeSendCRUD,
        success: function (response) {

            if (!response.success) {
                alert(response.message);
                return;
            }

            let flightModalBody = document.getElementById('flight-add-edit-modal');
            let flightId = flightModalBody.querySelector('.flight-id').value;

            let tabler = new InterFaceTable();
            tabler.loadPriceList(flightId);            
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'removing price');
        }
    };

    $.ajax(ajaxParameters);
};

var editPrice = function (id, priceDate, priceClassID, pricePrice) {

    let modalBody = document.getElementById('price-add-edit-modal');
    modalBody.querySelector('.price-id').value = id;
    modalBody.querySelector('.price-date').value = '' + priceDate.substr(6, 4) + '-' + priceDate.substr(3, 2) + '-' + priceDate.substr(0, 2);
    modalBody.querySelector('#price-class-selection-list').value = priceClassID;
    modalBody.querySelector('.price-price').value = pricePrice;

    var myModal = new bootstrap.Modal(modalBody);
    myModal.toggle();
};

var AddEventListeners = function (id, handler) {

    var elem = document.getElementById(id);
    elem.onkeyup = handler; 

    //var elem = document.getElementById("userConfirmPassword");
    //elem.onkeyup = passwordKeyDown;
}

var passwordKeyDown = function (e) {
    if (e.code === "Enter" || e.code === "NumpadEnter") {
        loginButtonHandler();
    }
}