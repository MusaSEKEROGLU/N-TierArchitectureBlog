CREATE TABLE [dbo].[Admins] (
    [AdminID]          INT            IDENTITY (1, 1) NOT NULL,
    [UserName]         NVARCHAR (MAX) NULL,
    [Password]         NVARCHAR (MAX) NULL,
    [Name]             NVARCHAR (MAX) NULL,
    [ShortDescription] NVARCHAR (MAX) NULL,
    [ImageURL]         NVARCHAR (MAX) NULL,
    [Role]             NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED ([AdminID] ASC)
);

