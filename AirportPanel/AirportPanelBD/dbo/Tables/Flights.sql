CREATE TABLE [dbo].[Flights]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DepartureDateTime] DATETIME NOT NULL, 
    [ArrivalDateTime] DATETIME NOT NULL, 
    [FlightNumber] NVARCHAR(20) NOT NULL, 
    [DepartureAirportID] INT NOT NULL, 
    [ArrivalAirportID] INT NOT NULL, 
    [ArrivalTerminalID] INT NOT NULL, 
    [ArrivalGateID] INT NOT NULL, 
    [DepartureTerminalID] INT NOT NULL, 
    [DepartureGateID] INT NOT NULL, 
    CONSTRAINT [FK_Flights_ToAirportsDeparture] FOREIGN KEY ([DepartureAirportID]) REFERENCES [Airports]([ID]), 
    CONSTRAINT [FK_Flights_ToAirportsArrive] FOREIGN KEY ([ArrivalAirportID]) REFERENCES [Airports]([ID]), 
    CONSTRAINT [FK_Flights_ToTerminals_Arrival] FOREIGN KEY ([ArrivalTerminalID]) REFERENCES [Terminals]([ID]), 
    CONSTRAINT [FK_Flights_ToGates_Arrival] FOREIGN KEY ([ArrivalGateID]) REFERENCES [Gates]([ID]), 
    CONSTRAINT [FK_Flights_ToTerminals_Departure] FOREIGN KEY ([DepartureTerminalID]) REFERENCES [Terminals]([ID]), 
    CONSTRAINT [FK_Flights_ToGates_Departure] FOREIGN KEY ([DepartureGateID]) REFERENCES [Gates]([ID]) 
)
