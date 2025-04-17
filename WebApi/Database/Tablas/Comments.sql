CREATE TABLE [dbo].[Comments]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [post_id] INT NOT NULL, 
    [user_id] INT NOT NULL, 
    [content] VARCHAR(MAX) NOT NULL, 
    [created_at] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Comments_Posts] FOREIGN KEY ([post_id]) REFERENCES [dbo].[Posts]([id]), 
    CONSTRAINT [FK_Comments_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users]([id])
)
