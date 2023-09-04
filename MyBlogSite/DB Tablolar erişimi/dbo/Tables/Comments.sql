CREATE TABLE [dbo].[Comments] (
    [CommentID]       INT            IDENTITY (1, 1) NOT NULL,
    [CommentUserName] NVARCHAR (MAX) NULL,
    [CommentTitle]    NVARCHAR (MAX) NULL,
    [CommentContent]  NVARCHAR (MAX) NULL,
    [CommentDate]     DATETIME2 (7)  NOT NULL,
    [CommentStatus]   BIT            NOT NULL,
    [BlogID]          INT            NOT NULL,
    [BlogScore]       INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED ([CommentID] ASC),
    CONSTRAINT [FK_Comments_Blogs_BlogID] FOREIGN KEY ([BlogID]) REFERENCES [dbo].[Blogs] ([BlogID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Comments_BlogID]
    ON [dbo].[Comments]([BlogID] ASC);


GO
Create Trigger AddScoreInComment
On Comments 
After Insert
As
Declare @ID int
Declare @Score int
Declare @RaytingCount int
Select @ID=BlogID,@Score=BlogScore from inserted
Update BlogRaytings Set BlogTotalScore=BlogTotalScore+@Score, BlogRaytingCount+=1
Where BlogID=@ID