CREATE TABLE [dbo].[Terminals]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(8) NOT NULL, 
    [AirportID] INT NOT NULL, 
    CONSTRAINT [FK_Terminals_ToAirports] FOREIGN KEY (AirportID) REFERENCES [Airports]([ID]) 
)
