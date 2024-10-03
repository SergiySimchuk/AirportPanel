CREATE TABLE [dbo].[PriceList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Date] DATE NOT NULL, 
    [PriceClassID] INT NOT NULL, 
    [FlightID] INT NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_PriceList_ToPriceClasses] FOREIGN KEY ([PriceClassID]) REFERENCES [PriceClasses]([Id]), 
    CONSTRAINT [FK_PriceList_ToFlights] FOREIGN KEY ([FlightID]) REFERENCES [Flights]([ID])
)

GO

CREATE UNIQUE INDEX [IX_PriceList_Date_PriceClassID_FlightID] ON [dbo].[PriceList] ([Date], [PriceClassID], [FlightID])
