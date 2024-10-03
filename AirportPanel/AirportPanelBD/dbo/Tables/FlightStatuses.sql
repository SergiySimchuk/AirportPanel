CREATE TABLE [dbo].[FlightStatuses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(64) NOT NULL, 
    [SecondsTo] INT NOT NULL, 
    [Arrival] BIT NOT NULL
)
