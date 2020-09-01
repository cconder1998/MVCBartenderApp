CREATE TABLE [dbo].[MenuTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DrinkId] INT NOT NULL, 
    [Name] NCHAR(25) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Ingredients] NVARCHAR(MAX) NOT NULL, 
    [Price] FLOAT NOT NULL
)
