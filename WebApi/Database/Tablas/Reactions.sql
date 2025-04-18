CREATE TABLE [dbo].[Reactions]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [user_id] INT NOT NULL, 
    [post_id] INT NOT NULL, 
    [comment_id] INT NOT NULL, 
    [type] NVARCHAR(50) NOT NULL, 
    [created_at] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Reactions_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users]([id]), 
    CONSTRAINT [FK_Reactions_Posts] FOREIGN KEY ([post_id]) REFERENCES [dbo].[Posts]([id]), 
    CONSTRAINT [FK_Reactions_Comments] FOREIGN KEY ([comment_id]) REFERENCES [dbo].[Comments]([id]),
)
