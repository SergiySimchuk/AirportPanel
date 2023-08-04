

var buyTicket = function (flightId) {

    changeRegButtonsVisiblity();

    let content = document.querySelector('#tickets-container');

    if (isAuthorised()) {
        setCurrentUserName(currentUser());
        loadPassengersForUser();
    }

    loadFlightPanelByID(flightId, fillFlightInfoInBuyTicket);

    loadFlightPriceList(flightId);

    var modalBody = document.getElementById('buy-ticket-modal');
    modalBody.querySelector('.tickets-count').value = 0;
    modalBody.querySelector('.tickets-counter').value = 0;
    var myModal = new bootstrap.Modal(modalBody);
    myModal.toggle();
};

var clearAddTicket = function (flightId) {

    let content = document.querySelector('#tickets-container');
    let prevFlight = GetCookieValue(document.cookie, "previosFlight");
    if (prevFlight != flightId) {

        if (content.children.length > 1) {

            while (content.children.length > 1) {
                content.removeChild(content.children[content.children.length - 1]);
            }
        }

        document.cookie = SetCookieValue("previosFlight", flightId);

        addTicket();
    }
};

var fillFlightInfoInBuyTicket = function (flight) {

    var modalBody = document.getElementById('buy-ticket-modal');
    modalBody.querySelector('.flight-id').value = flight.id; 
    modalBody.querySelector('.flight').value = ''
        + flight.flightNumber
        + ' (' + flight.departureDateTime
        + ' '
        + flight.departureAirport
        + ' - '
        + flight.arrivalDateTime
        + ' '
        + flight.arrivalAirport
        + ')'; 
};

var loadFlightPanelByID = function (flightId, sucessHandler) {

    let ajaxParameters = {
        url: "/Flights/GetFlightPanelByID?id=" + flightId,
        type: "GET",
        cache: false,
        success: sucessHandler,

        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'getting flight by id');
        }
    };

    $.ajax(ajaxParameters);

};

var addTicket = function () {

    let modalBody = document.getElementById('buy-ticket-modal');
    let ticketCounter = ++modalBody.querySelector('.tickets-counter').value;
    
    ++modalBody.querySelector('.tickets-count').value;

    let content = document.querySelector('#tickets-container');

    let ticketBlock = modalBody.querySelector('#ticket-block-template').cloneNode(true);
    
    ticketBlock.querySelector('#ticket-header').innerText = "Ticket " + ticketCounter;

    let ticketBlockId = 'ticket-block-' + ticketCounter;

    ticketBlock.id = ticketBlockId;

    ticketBlock.hidden = false;

    let removeButton = ticketBlock.querySelector('#remove-button-template');
    removeButton.id = removeButton.id.replace('template', ticketCounter);

    removeButton.onclick = () => removeTicketButton(ticketBlockId);

    let passengersSelectionList = ticketBlock.querySelector('#ticket-my-passengers-list-template');
    passengersSelectionList.setAttribute('ticketBlockID', ticketBlockId);

    let savePassengerCheckBox = ticketBlock.querySelector('#save-passenger-column-template');
    savePassengerCheckBox.id = savePassengerCheckBox.id.replace('template', ticketCounter);

    let passengerId = ticketBlock.querySelector('#passenger-id-template');
    passengerId.id = passengerId.id.replace('template', ticketCounter);

    content.appendChild(ticketBlock); 
};

var removeTicketButton = function (ticketBlockId) {

    let ticketBlock = document.getElementById(ticketBlockId);

    let content = document.querySelector('#tickets-container');
    content.removeChild(ticketBlock);

    let modalBody = document.getElementById('buy-ticket-modal');
    --modalBody.querySelector('.tickets-count').value;
};

var loadFlightPriceList = function (flightId) {

   // let curDate = new Date().toLocaleString('ua-UA');
   // debugger;

    var ajaxParameters = {
        url: "/PriceList/GetPriceListByFlightOnDate?flightId=" + flightId, // + "&date=" + curDate,
        type: "Get",
        cache: false,
        context: this,
        success: function (response) {

            fillPricelectionList(response);
            loadPassengersForUser();
            clearAddTicket(flightId);
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'Getting price list');
        }
    };

    $.ajax(ajaxParameters);
};

var fillPricelectionList = function (data, selectedValue) {

    var menu = document.getElementById('ticket-price-list-selection');

    let menuHtml = "";

    menuHtml += '<option value="0">Not selected</option>';

    for (let priceItem of data) {
        menuHtml += '<option value="' + priceItem.priceClassID + '" priceValue="' + priceItem.price + '">' + priceItem.priceClassName + ': ' + priceItem.price + '</option>';
    }

    menu.innerHTML = menuHtml;

    if (selectedValue != undefined)
        menu.value = selectedValue;
};

var changeRegButtonsVisiblity = function () {

    let authorise = isAuthorised();

    let modal= document.getElementById('buy-ticket-modal');
    modal.querySelector('#login-client-button').hidden = authorise;
    modal.querySelector('#log-out-button').hidden = !authorise;
    modal.querySelector('#registr-new-client-button').hidden = authorise;
    let checkBoxes = modal.querySelectorAll('.save-passenger-check-box');

    for (let chB of checkBoxes) {

        chB.hidden = !authorise;
    };

    let myPassengers = modal.querySelectorAll('.ticket-my-passengers-list'); 

    for (let myPas of myPassengers) {

        myPas.hidden = !authorise;
    };
};

var saveBoughtTickets = function () {

    let modal = document.getElementById('buy-ticket-modal');
    let flightId = modal.querySelector('.flight-id').value;

    let tickets = modal.querySelector('#tickets-container').querySelectorAll('.ticket-block');

    for (let ticketBlock of tickets) {

        if (ticketBlock.id == 'ticket-block-template' || ticketBlock.disabled)
            continue;

        let passengerId = Number(ticketBlock.querySelector('.passenger-id').value);
        let savePassenger = ticketBlock.querySelector('.save-passenger-check-box-input').checked;

        let firstName = ticketBlock.querySelector('.passenger-first-name').value;
        let passport = ticketBlock.querySelector('.passenger-passport').value;
        let dateOfBirth = ticketBlock.querySelector('.passenger-date-of-birth').value;
        let lastName = ticketBlock.querySelector('.passenger-last-name').value;
        let gender = ticketBlock.querySelector('.passenger-gender').value;
        let nationality = ticketBlock.querySelector('.passenger-nationality').value;

        let row = ticketBlock.querySelector('.row-place').value;
        let place = ticketBlock.querySelector('.place-place').value;
        let priceClassID = ticketBlock.querySelector('.ticket-price-class').value;
        let priceValue = ticketBlock.querySelector('.ticket-price-class').options[ticketBlock.querySelector('.ticket-price-class').selectedIndex].getAttribute('priceValue');

        let userId = 0;

        if (isAuthorised() && savePassenger)
            userId = GetCookieValue(document.cookie, "currentUserId");

        let passenger = {
            "id": passengerId,
            "firstName": firstName,
            "lastName": lastName,
            "nationality": nationality,
            "passport": passport,
            "gender": gender,
            "dateOfBirth": dateOfBirth,
            "userId": userId
        };

        let ticket = {
            "flightId": flightId,
            "priceClassID": priceClassID,
            "place": place,
            "row": row,
            "price": priceValue
        };

        savePassengerPost(passenger, ticket, ticketBlock.id);
    };
};

var savePassengerPost = function (passenger, ticket, ticketBlockId) {

    let url = "/Passengers/CreateNewPassenger";

    if (passenger.id)
        url = "/Passengers/UpdatePassenger";

    var ajaxParameters = {
        url: url,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: JSON.stringify(passenger),
        success: function (response) {

            ticket.passengerId = response.id;
            saveTicketPost(ticket, ticketBlockId);
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus + ' ' + jqXHR.responseText, jqXHR.status, undefined, 'saving passenger');
        }
    };

    $.ajax(ajaxParameters);
};

var saveTicketPost = function (ticket, ticketBlockId) {

    let url = "/Tickets/CreateNewTicket";

    var ajaxParameters = {
        url: url,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: JSON.stringify(ticket),
        success: function (response) {

            fixSavetTicket(ticketBlockId);
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus + ' ' + jqXHR.responseText, jqXHR.status, undefined, 'saving ticket');
        }
    };

    $.ajax(ajaxParameters);

};

var fixSavetTicket = function (ticketBlockID) {

    let ticketBlock = document.getElementById(ticketBlockID);
    ticketBlock.disabled = true;

    let header = ticketBlock.querySelector('#ticket-header');
    header.innerText = header.innerText + "(saved)";
};

var loadPassengersForUser = function () {

    let currentId = GetCookieValue(document.cookie, "currentUserId");
    let url = "/Passengers/GetPassengersByUser?userId=" + currentId;

    var ajaxParameters = {
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        cache: false,
        success: function (response) {

            fillUserPassengersSelectionList(response);
            
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'getting passengers for user');
        }
    };

    $.ajax(ajaxParameters);
};

var fillUserPassengersSelectionList = function (data) {

    let menuHtml = "";

    menuHtml += '<option value="0">Not selected</option>';

    for (let passengerItem of data) {
        menuHtml += '<option value="' + passengerItem.id + '">' + passengerItem.firstName + ' ' + passengerItem.lastName + ' ' + passengerItem.passport + '</option>';
    }

    let modal = document.getElementById('buy-ticket-modal');
    let myPassengers = modal.querySelectorAll('.ticket-my-passengers-list'); 

    for (let passentelList of myPassengers) {

        passentelList.innerHTML = menuHtml;
    }
};

var onPassengerSelect = function (sender, selectedValue) {

    let ticketBlockId = sender.getAttribute('ticketBlockId');

    if (selectedValue == 0) {

        let ticketBlock = document.getElementById(ticketBlockId);
        ticketBlock.querySelector('.passenger-id').value = "";

        let savePas = ticketBlock.querySelector('.save-passenger-check-box-input');
        
        savePas.disabled = false;
        return;
    }

    let url = "/Passengers/GetPassengerByID?id=" + selectedValue;

    var ajaxParameters = {
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        cache: false,
        success: function (response) {

            fillPassengerFieldsToTicket(ticketBlockId, response);          

        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'getting passengers for user');
        }
    };

    $.ajax(ajaxParameters);

};

var fillPassengerFieldsToTicket = function (ticketBlockId, passenger) {

    let ticketBlock = document.getElementById(ticketBlockId);

    ticketBlock.querySelector('.passenger-id').value = passenger.id;
    ticketBlock.querySelector('.passenger-first-name').value = passenger.firstName;
    ticketBlock.querySelector('.passenger-passport').value = passenger.passport;
    ticketBlock.querySelector('.passenger-date-of-birth').value = dateFromString(passenger.dateOfBirth);
    ticketBlock.querySelector('.passenger-last-name').value = passenger.lastName;
    ticketBlock.querySelector('.passenger-gender').value = passenger.gender;
    ticketBlock.querySelector('.passenger-nationality').value = passenger.nationality;
    
    let savePas = ticketBlock.querySelector('.save-passenger-check-box-input');
    savePas.checked = true;
    savePas.disabled = true;

};

var dateFromString = function (dateStringValue) {

    return '' + dateStringValue.substr(0, 4) + '-' + dateStringValue.substr(5, 2) + '-'  + dateStringValue.substr(8, 2);
};

var executeSearchFlight = function () {

    let searchPanel = document.getElementById('flights-search-panel');

    let flightNumber = searchPanel.querySelector('.flight-number-search').value;
    let departureAirport = searchPanel.querySelector('.departure-airport-search').value;
    let arrivalAirport = searchPanel.querySelector('.arrival-airport-search').value;
    let startDate = searchPanel.querySelector('.start-date-search').value;
    let endDate = searchPanel.querySelector('.end-date-search').value;

    let searchConditions = {
        flightNumber,
        departureAirport,
        arrivalAirport,
        "startDate" : startDate == "" ? "0001-01-01" : startDate,
        "endDate": endDate == "" ? "0001-01-01" : endDate        
    };

    var ajaxParameters = {
        url: "/Flights/GetFlightsByConditions",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: JSON.stringify(searchConditions),
        success: function (response) {

            let tabler = new InterFaceTable();
            tabler.BuildFlightsTable(response);
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus + ' ' + jqXHR.responseText, jqXHR.status, undefined, 'load flights');
        }
    };

    $.ajax(ajaxParameters);
};

var executeSearchTickets = function () {

    let searchPanel = document.getElementById('tickets-search-panel');

    let flightNumber = searchPanel.querySelector('.flight-number-search').value;
    let firstName = searchPanel.querySelector('.first-name-search').value;
    let lastName = searchPanel.querySelector('.last-name-search').value;
    let passport = searchPanel.querySelector('.passport-search').value;
    

    let searchConditions = {
        flightNumber,
        firstName,
        lastName,
        passport
    };

    var ajaxParameters = {
        url: "/Flights//GetTicketsBySearchConditions",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: JSON.stringify(searchConditions),
        success: function (response) {

            let tabler = new InterFaceTable();
            tabler.buildTicketsTable(response);
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus + ' ' + jqXHR.responseText, jqXHR.status, undefined, 'load flights');
        }
    };

    $.ajax(ajaxParameters);
};