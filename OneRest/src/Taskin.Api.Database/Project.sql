CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] VARCHAR(75) NOT NULL, 
    [Detail] VARCHAR(MAX) NULL, 
    [ImageUrl] VARCHAR(255) NULL, 
    [ProjectType] INT NOT NULL
)
