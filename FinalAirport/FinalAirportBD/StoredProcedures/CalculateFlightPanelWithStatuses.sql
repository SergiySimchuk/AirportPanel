CREATE PROCEDURE [dbo].[CalculateFlightPanelWithStatuses]
	
AS
	
DECLARE @currentDate DateTime = GetDate();

SELECT Flights.Id as ID
	, Flights.FlightNumber as FlightNumber
	, FlightStatuses.Id  as StatusID
	, FlightStatuses.[Name] as StatusName	
	, case (FlightStatuses.Arrival) 
		when 1
			then DATEADD(second, FlightStatuses.SecondsTo, Flights.ArrivalDateTime)  
		else 
			DATEADD(second, FlightStatuses.SecondsTo, Flights.DepartureDateTime) 
	end  as statusDate  
	INTO #Statuses
	FROM [Flights] as Flights
		cross join [FlightStatuses]  

	select 
	statuses.id
	, statuses.FlightNumber
	, Max(statuses.statusDate) as statusDate
	Into #MaxStausDates
	from #Statuses as statuses
	where  statuses.statusDate < @currentDate 
	group by
	statuses.ID,
	statuses.FlightNumber
	
	select 
	statuses.ID
	, statuses.FlightNumber
	, statuses.statusDate
	, statuses.StatusID
	, statuses.StatusName
	into #FinalStatuses
	from #Statuses  as statuses
	join #MaxStausDates  as maxStatuses
	on statuses.ID = maxStatuses.ID
	and statuses.FlightNumber = maxStatuses.FlightNumber
	and statuses.statusDate = maxStatuses.statusDate

SELECT Flights.Id as ID
	, Flights.FlightNumber as FlightNumber
	, Flights.DepartureDateTime as DepartureDateTime
	, Flights.ArrivalDateTime as ArrivalDateTime
	, Flights.DepartureAirportID as DepartureAirportID
	, DepartureAirports.[Name] as DepartureAirport
	, DepartureAirports.City as DepartureCity
	, DepartureAirports.Country as DepartureCountry
	, Flights.ArrivalAirportID as ArrivalAirportID
	, ArrivalAirports.[Name] as ArrivalAirport
	, ArrivalAirports.City as ArrivalCity
	, ArrivalAirports.Country as ArrivalCountry
	, Flights.DepartureTerminalID as DepartureTerminalID
	, TerminalsDeparture.[Name] as DepartureTerminal
	, Flights.DepartureGateID as DepartureGateID
	, GatesDeparture.[Name] as DepartureGate
	, Flights.ArrivalTerminalID as ArrivalTerminalID
	, TerminalsArrival.[Name] as ArrivalTerminal
	, Flights.ArrivalGateID as ArrivalGateID
	, GatesArrival.[Name] as ArrivalGate
	, isnull(FlightStatuses.Id, 0)  as StatusID
	, isnull(FlightStatuses.StatusName, 'unknown') as FlightStatus

	FROM [Flights] as Flights
		join [Airports] as DepartureAirports
			on Flights.DepartureAirportID = DepartureAirports.Id
		join [Airports] as ArrivalAirports 
			on Flights.ArrivalAirportID = ArrivalAirports.Id
		join [Terminals] as TerminalsArrival
			on Flights.ArrivalTerminalID = TerminalsArrival.Id
		join [Gates] as GatesArrival 
			on Flights.ArrivalGateID = GatesArrival.Id
		join [Terminals] as TerminalsDeparture
			on Flights.DepartureTerminalID = TerminalsDeparture.Id
		join [Gates] as GatesDeparture
			on Flights.DepartureGateID = GatesDeparture.Id
		left join #FinalStatuses  as FlightStatuses   
			on Flights.Id = FlightStatuses.ID
			and Flights.FlightNumber = FlightStatuses.FlightNumber
			
	drop table #Statuses 
	drop table #MaxStausDates 
	drop table #FinalStatuses
