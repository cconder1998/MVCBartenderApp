CREATE TABLE [dbo].[OrderQueue]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(25) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Ingredients] NVARCHAR(MAX) NOT NULL, 
    [Price] FLOAT NOT NULL 
)
