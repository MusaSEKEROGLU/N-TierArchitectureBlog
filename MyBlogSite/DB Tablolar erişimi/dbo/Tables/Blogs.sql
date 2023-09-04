CREATE TABLE [dbo].[Blogs] (
    [BlogID]             INT            IDENTITY (1, 1) NOT NULL,
    [BlogTitle]          NVARCHAR (MAX) NULL,
    [BlogContent]        NVARCHAR (MAX) NULL,
    [BlogThumbnailImage] NVARCHAR (MAX) NULL,
    [BlogImage]          NVARCHAR (MAX) NULL,
    [BlogCreateDate]     DATETIME2 (7)  NOT NULL,
    [BlogStatus]         BIT            NOT NULL,
    [CategoryID]         INT            NOT NULL,
    [WriterID]           INT            NOT NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED ([BlogID] ASC),
    CONSTRAINT [FK_Blogs_Categories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Blogs_Writers_WriterID] FOREIGN KEY ([WriterID]) REFERENCES [dbo].[Writers] ([WriterID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Blogs_CategoryID]
    ON [dbo].[Blogs]([CategoryID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Blogs_WriterID]
    ON [dbo].[Blogs]([WriterID] ASC);


GO

Create Trigger AddBlogRaytingTable
On Blogs After Insert
As
Declare @ID int
Select @ID=BlogID from inserted
Insert Into BlogRaytings (BlogID,BlogTotalScore,BlogRaytingCount)
Values(@ID,0,0)