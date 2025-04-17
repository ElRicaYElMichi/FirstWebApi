CREATE TABLE [dbo].[Users]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [username] VARCHAR(50) NOT NULL, 
    [name] VARCHAR(50) NOT NULL, 
    [last_name] VARCHAR(50) NOT NULL, 
    [email] VARCHAR(50) NOT NULL, 
    [password] VARCHAR(50) NOT NULL, 
    [created_at] DATETIME2 NOT NULL
)
