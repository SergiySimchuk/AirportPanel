CREATE TABLE [dbo].[Passengers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Nationality] NVARCHAR(50) NOT NULL, 
    [Passport] NVARCHAR(8) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Gender] NVARCHAR(10) NOT NULL, 
    [UserID] INT NULL 
)
