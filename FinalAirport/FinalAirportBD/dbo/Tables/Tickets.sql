CREATE TABLE [dbo].[Tickets]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PassengerID] INT NOT NULL, 
    [FlightID] INT NOT NULL, 
    [PriceClassID] INT NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    [Row] INT NOT NULL, 
    [Place] INT NOT NULL, 
    CONSTRAINT [FK_Tickets_To_Passengers] FOREIGN KEY ([PassengerID]) REFERENCES [Passengers]([id]), 
    CONSTRAINT [FK_Tickets_To_Flights] FOREIGN KEY ([FlightID]) REFERENCES [Flights]([ID]), 
    CONSTRAINT [FK_Tickets_To_PriceClasses] FOREIGN KEY ([PriceClassID]) REFERENCES [PriceClasses]([ID])
)
