CREATE TABLE [dbo].[Posts]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [user_id] INT NOT NULL, 
    [content] VARCHAR(MAX) NOT NULL, 
    [created_at] DATETIME2 NOT NULL, 

    CONSTRAINT [FK_Posts_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users]([id]) 
    

)
