CREATE TABLE [dbo].[Gates]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(8) NOT NULL, 
    [TerminalID] INT NOT NULL, 
    CONSTRAINT [FK_Gates_ToTerminals] FOREIGN KEY ([TerminalID]) REFERENCES [Terminals]([ID])
)
