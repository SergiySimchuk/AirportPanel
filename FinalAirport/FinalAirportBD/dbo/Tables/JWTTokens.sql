CREATE TABLE [dbo].[JWTTokens]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Token] NVARCHAR(MAX) NOT NULL, 
    [RefreshToken] NVARCHAR(MAX) NOT NULL, 
    [Expiration] DATETIME NOT NULL, 
    [RefreshTokenExpiration] DATETIME NOT NULL,
    [IPAdress] NVARCHAR(20) NOT NULL, 
    [UserID] INT NOT NULL, 
    [Created] DATETIME NOT NULL, 
    CONSTRAINT [FK_JWTTokens_To_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([ID])
)
