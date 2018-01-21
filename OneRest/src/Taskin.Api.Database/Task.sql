CREATE TABLE [dbo].[Task]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Detail] VARCHAR(MAX) NOT NULL, 
    [Priority] INT NOT NULL, 
    [Effort] INT NULL, 
    [StartDate] DATE NULL, 
    [DueDate] DATETIME NULL, 
    [TaskType] INT NOT NULL
)
