class InterFaceTable {
    constructor() { }

    BuildFlightsTable(data) {

        let columns = [
            {
                Name: "Fl #",
                code: "flightNumber"
            },
            {
                Name: "Dep d/t",
                code: "departureDateTime",
                itsDateTime: true,

            },
            {
                Name: "Dep.city",
                code: "departureCity"
            },
            {
                Name: "Dep. country",
                code: "departureCountry"
            },
            {
                Name: "Dep.airport",
                code: "departureAirport"
            },
            {
                Name: "Dep. terminal",
                code: "departureTerminal"
            },
            {
                Name: "Dep. gate",
                code: "departureGate"
            },
            {
                Name: "Ar. d/t",
                code: "arrivalDateTime",
                itsDateTime: true
            },
            {
                Name: "Ar. city",
                code: "arrivalCity"
            },
            {
                Name: "Ar. country",
                code: "arrivalCountry"
            },
            {
                Name: "Ar. airport",
                code: "arrivalAirport"
            },
            {
                Name: "Ar. terminal",
                code: "arrivalTerminal"
            },
            {
                Name: "Ar. gate",
                code: "arrivalGate"
            },
            {
                Name: "Status",
                code: "flightStatus"
            },
            {
                Name: "Actions",
                Buttons: [
                    {
                        Text: "Buy ticket",
                        buttonType: "buyTicket"
                    }
                ]
            }
        ];

        var content = document.querySelector('#flightsTable');

        let flights = this.GetTableHTML(data, columns);
        content.innerHTML = flights;

        setButtonHandlerWithIDParameter(content, '.buyTicket', buyTicket);

    }

    GetTableHTML(data, columns) {

        var tableHtml = `<table align="center" class='table table-dark table-striped table-hover table-bordered caption-top align-top text-nowrap' >`;
        tableHtml += "<thead>";
        tableHtml += "<tr>";

        for (var column of columns) {

            if (column.hidden)
                continue;

            tableHtml += `<th>${column.Name}</th>`;
        }

        tableHtml += "</tr>";
        tableHtml += "</thead>";
        tableHtml += "<tbody>";

        for (var item of data) {

            let rowColumnsHtml = "";
            let rowHeaderHtml = `<tr id=${item.id} `;

            for (var column of columns) {

                if (column.hidden) {
                    rowHeaderHtml += ` ${column.code}='${item[column.code]}' `;
                    continue;
                }

                if (column.itsDateTime) {
                    let inDate = new Date(item[column.code]);
                    rowColumnsHtml += `<td>${inDate.toLocaleString('ua-UA')}</td>`;
                    continue;
                }

                if (column.itsDateWithoutTime) {
                    let inDate = new Date(item[column.code]);
                    rowColumnsHtml += `<td>${inDate.toLocaleDateString('ua-UA')}</td>`;
                    continue;
                }

                if (column.Buttons) {
                    rowColumnsHtml += "<td>";
                    for (var button of column.Buttons) {
                        rowColumnsHtml += "<button class='m-1 btn btn-primary " + button.buttonType + "' >";
                        rowColumnsHtml += button.Text;
                        rowColumnsHtml += "</button>";
                    }
                    rowColumnsHtml += "</td>";
                    continue;
                }

                rowColumnsHtml += `<td>${item[column.code]}</td>`;
            }

            tableHtml += rowHeaderHtml + '>';
            tableHtml += rowColumnsHtml;
            tableHtml += "</tr>";
        }

        tableHtml += "</tbody>";
        tableHtml += "</table>";

        return tableHtml;
    }

    loadFlightsPanel() {

        $.ajax(
            {
                url: "/Flights/GetFlights",
                type: "GET",
                context: this,

                success: function (result) {

                    this.BuildFlightsTable(result);
                },

                error: function (jqXHR, textStatus, errorThrown) {

                    requestErrorHandler(textStatus, jqXHR.status, 'flightsTable', 'loading Flights panel');
                }
            });
    }

    loadAirportsTable() {

        $.ajax(
            {
                url: "/Airports/GetAirports",
                type: "GET",
                context: this,
                beforeSend: addTokenToRequest,
                success: function (result) {
                    this.BuildAirportsTable(result);
                    fillAirportsDropDownList(result, 'terminal-airports-selection-list');
                    fillAirportsDropDownList(result, 'flight-departure-airport-selection-list');
                    fillAirportsDropDownList(result, 'flight-arrival-airport-selection-list');
                },
                error: function (jqXHR, textStatus, errorThrown) {

                    requestErrorHandler(textStatus, jqXHR.status, 'airportsTable', 'loading airports');
                }
            });
    }

    BuildAirportsTable(data) {
        let columns = [
            {
                Name: "Name",
                code: "name"
            },
            {
                Name: "City",
                code: "city"
            },
            {
                Name: "Country",
                code: "country"
            },
            {
                Name: "Actions",
                Buttons: [
                    {
                        Text: "Edit",
                        buttonType: "editAirport"
                    },
                    {
                        Text: "Remove",
                        buttonType: "removeAirport"
                    }
                ]
            }
        ];

        var content = document.querySelector('#airportsTable');
        content.innerHTML = this.GetTableHTML(data, columns);

        let handlerParameters = [
            {
                index: 0,
                name: "name"
            },
            {
                index: 1,
                name: "city"
            },
            {
                index: 2,
                name: "country"
            }
        ];

        setButtonHandlerWithIDAndParameters(content, '.editAirport', editAirport, handlerParameters);

        setButtonHandlerWithIDParameter(content, '.removeAirport', removeAirport);
    }

    loadTerminalsTable() {

        $.ajax(
            {
                url: "/Terminals/GetTerminals",
                type: "GET",
                context: this,
                beforeSend: addTokenToRequest,
                success: function (result) {
                    this.buildTerminalsTable(result);
                    fillTerminalsDropDownList(result, 'gate-terminal-selection-list');
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    requestErrorHandler(textStatus, jqXHR.status, 'terminalsTable', 'loading terminals');
                }
            });
    }

    getterminalColumns() {

        return [
            {
                Name: "Airport ID",
                code: "airportID",
                hidden: true
            },
            {
                Name: "Airport",
                code: "airportName"
            },
            {
                Name: "Name",
                code: "name"
            },
            {
                Name: "Actions",
                Buttons: [
                    {
                        Text: "Edit",
                        buttonType: "editTerminal"
                    },
                    {
                        Text: "Remove",
                        buttonType: "removeTerminal"
                    }
                ]
            }
        ];
    }

    buildTerminalsTable(data) {

        let columns = this.getterminalColumns();

        var content = document.querySelector('#terminalsTable');
        content.innerHTML = this.GetTableHTML(data, columns);

        setButtonHandlerWithIDParameter(content, '.removeTerminal', removeTerminal);

        let handlerParameters = [
            {
                index: 1,
                name: "name"
            },
            {
                name: "airportId"
            }
        ];

        setButtonHandlerWithIDAndParameters(content, '.editTerminal', editTerminal, handlerParameters);
    }

    loadGatesTable() {

        $.ajax(
            {
                url: "/Gates/GetGates",
                type: "GET",
                context: this,
                beforeSend: addTokenToRequest,
                success: function (result) {
                    this.buildGatesTable(result);
                },
                error: function (jqXHR, textStatus, errorThrown) {

                    requestErrorHandler(textStatus, jqXHR.status, 'gatesTable', 'loading gates');
                }
            });
    }

    buildGatesTable(data) {

        let columns = [
            {
                Name: "Name",
                code: "name"
            },
            {
                Name: "Terminal ID",
                code: "terminalID",
                hidden: true
            },
            {
                Name: "Terminal",
                code: "terminalName"
            },
            {
                Name: "Airport ID",
                code: "airportID",
                hidden: true
            },
            {
                Name: "Airport",
                code: "airportName"
            },
            {
                Name: "Actions",
                Buttons: [
                    {
                        Text: "Edit",
                        buttonType: "editGate"
                    },
                    {
                        Text: "Remove",
                        buttonType: "removeGate"
                    }
                ]
            }
        ];

        var content = document.querySelector('#gatesTable');
        content.innerHTML = this.GetTableHTML(data, columns);

        setButtonHandlerWithIDParameter(content, '.removeGate', removeGate);

        let handlerParameters = [
            {
                index: 0,
                name: "name"
            },
            {
                name: "terminalId"
            }
        ];

        setButtonHandlerWithIDAndParameters(content, '.editGate', editGate, handlerParameters);
    }

    loadFlightStatuses() {

        $.ajax(
            {
                url: "/FlightStatuses/GetFlightStatuses",
                type: "GET",
                context: this,
                beforeSend: addTokenToRequest,
                success: function (result) {

                    this.buildFlightStatusesTable(result);
                },
                error: function (jqXHR, textStatus, errorThrown) {

                    requestErrorHandler(textStatus, jqXHR.status, 'flightStatusesTable', 'loading flight statuses');
                }
            });
    }

    buildFlightStatusesTable(data) {

        let columns = [
            {
                Name: "Name",
                code: "name"
            },
            {
                Name: "Seconds to",
                code: "secondsTo"
            },
            {
                Name: "Relate to",
                code: "relatedTo"
            },
            {
                Name: "Arrival",
                code: "arrival",
                hidden: true
            },
            {
                Name: "Actions",
                Buttons: [
                    {
                        Text: "Edit",
                        buttonType: "editFlightStatus"
                    },
                    {
                        Text: "Remove",
                        buttonType: "removeFlightStatus"
                    }
                ]
            }
        ];

        var content = document.querySelector('#flightStatusesTable');
        content.innerHTML = this.GetTableHTML(data, columns);

        setButtonHandlerWithIDParameter(content, '.removeFlightStatus', removeFlightStatus);

        let handlerParameters = [
            {
                index: 0,
                name: "name"
            },
            {
                index: 1,
                name: "secondsTo"
            },
            {
                index: 2,
                name: "relatedTo"
            }
        ];

        setButtonHandlerWithIDAndParameters(content, '.editFlightStatus', editFlightStatus, handlerParameters);
    }

    loadPriceClasses() {

        $.ajax(
            {
                url: "/PriceClasses/GetPriceClasses",
                type: "GET",
                context: this,
                beforeSend: addTokenToRequest,
                success: function (result) {

                    this.buildPriceClassesTable(result);
                    fillPriceClassSelectionList(result);
                },
                error: function (jqXHR, textStatus, errorThrown) {

                    requestErrorHandler(textStatus, jqXHR.status, 'priceClassesTable', 'loading price classes');
                }
            });
    }

    buildPriceClassesTable(data) {

        let columns = [
            {
                Name: "Name",
                code: "name"
            },
            {
                Name: "Actions",
                Buttons: [
                    {
                        Text: "Edit",
                        buttonType: "editPriceClasses"
                    },
                    {
                        Text: "Remove",
                        buttonType: "removePriceClasses"
                    }
                ]
            }
        ];

        var content = document.querySelector('#priceClassesTable');
        content.innerHTML = this.GetTableHTML(data, columns);

        setButtonHandlerWithIDParameter(content, '.removePriceClasses', removePriceClasses);

        let handlerParameters = [
            {
                index: 0,
                name: "name"
            }
        ];

        setButtonHandlerWithIDAndParameters(content, '.editPriceClasses', editPriceClasses, handlerParameters);
    }

    loadPriceList(flightId) {

        var ajaxParameters = {
            url: "/PriceList/GetPriceListByFlight?flightId=" + flightId,
            type: "Get",
            cache: false,
            context: this,
            beforeSend: addTokenToRequest,
            success: function (response) {

                this.buildPriceListTable(response);
            },
            error: function (jqXHR, textStatus, errorThrown) {

                requestErrorHandler(textStatus, jqXHR.status, 'priceListTable', 'Geting price list');
            }
        };

        $.ajax(ajaxParameters);
    }

    buildPriceListTable(data) {

        let columns = [
            {
                Name: "Date",
                code: "date",
                itsDateWithoutTime: true
            },
            {
                code: "priceClassID",
                hidden: true
            },
            {
                Name: "Price class",
                code: "priceClassName"
            },
            {
                code: "flightID",
                hidden: true
            },
            {
                Name: "Price",
                Name: "Price",
                code: "price"
            },
            {
                Name: "Actions",
                Buttons: [
                    {
                        Text: "Edit",
                        buttonType: "editPice"
                    },
                    {
                        Text: "Remove",
                        buttonType: "removePrice"
                    }
                ]
            }
        ];

        var content = document.querySelector('#priceListTable');

        if (!data || data.length == 0)
            content.innerHTML = " <br/> No prices yet";
        else
            content.innerHTML = this.GetTableHTML(data, columns);

        setButtonHandlerWithIDParameter(content, '.removePrice', removePrice);

        let handlerParameters = [
            {
                index: 0,
                name: "date"
            },
            {
                name: "priceClassID"
            },
            {
                index: 2,
                name: "price"
            },
        ];

        setButtonHandlerWithIDAndParameters(content, '.editPice', editPrice, handlerParameters);
    }

    loadPassengers() {

        var ajaxParameters = {
            url: "/Passengers/GetAllPassengers",
            type: "Get",
            cache: false,
            context: this,
            beforeSend: addTokenToRequest,
            success: function (response) {

                this.buildPassengersTable(response);
            },
            error: function (jqXHR, textStatus, errorThrown) {

                requestErrorHandler(textStatus, jqXHR.status, 'passengersTable', 'Geting passengers list');
            }
        };

        $.ajax(ajaxParameters);
    }

    buildPassengersTable(data) {
        let columns = [
            {
                Name: "First name",
                code: "firstName"
            },
            {
                Name: "Last name",
                code: "lastName"
            },
            {
                Name: "Passport",
                code: "passport"
            },
            {
                Name: "Nationality",
                code: "nationality"
            },
            {
                Name: "Gender",
                code: "gender"
            }, {
                Name: "Date of birth",
                code: "dateOfBirth",
                itsDateTime: true

            },
            {
                Name: "user ID",
                code: "userID",
                hidden: true
            },
            {
                Name: "login",
                code: "userName"
            }
        ];

        var content = document.querySelector('#passengersTable');
        content.innerHTML = this.GetTableHTML(data, columns);
    };

    loadTickets() {

        var ajaxParameters = {
            url: "/Tickets/GetAllTickets",
            type: "Get",
            cache: false,
            context: this,
            beforeSend: addTokenToRequest,
            success: function (response) {

                this.buildTicketsTable(response);
            },
            error: function (jqXHR, textStatus, errorThrown) {

                requestErrorHandler(textStatus, jqXHR.status, 'ticketsTable', 'Geting tickets list');
            }
        };

        $.ajax(ajaxParameters);
    }

    buildTicketsTable(data) {
        let columns = [
            {
                Name: "Flight number",
                code: "flightNumber"
            },
            {
                Name: "Flight ID",
                code: "flifhtId",
                hidden: true
            },
            {
                Name: "Price class ID",
                code: "priceClassId",
                hidden: true
            },
            {
                Name: "Price class",
                code: "priceClass"
            },
            {
                Name: "Price",
                code: "price"
            },
            {
                Name: "passengerId",
                code: "passengerId",
                hidden: true
            },
            {
                Name: "First name",
                code: "passengerFirstName"
            },
            {
                Name: "Last name",
                code: "passengerLastName"
            },
            {
                Name: "Passport",
                code: "passengerPassport"
            },
            {
                Name: "Nationality",
                code: "passengerNationality"
            },
            {
                Name: "Gender",
                code: "passengerGender"
            }, {
                Name: "Date of birth",
                code: "passengerDateOfBirth",
                itsDateTime: true
            },
            {
                Name: "Row",
                code: "row"
            },
            {
                Name: "Place",
                code: "place"
            }
        ];

        var content = document.querySelector('#ticketsTable');
        content.innerHTML = this.GetTableHTML(data, columns);
    };

}