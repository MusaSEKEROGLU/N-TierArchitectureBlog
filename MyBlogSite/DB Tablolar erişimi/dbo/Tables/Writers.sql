CREATE TABLE [dbo].[Writers] (
    [WriterID]       INT            IDENTITY (1, 1) NOT NULL,
    [WriterName]     NVARCHAR (MAX) NULL,
    [WriterAbout]    NVARCHAR (MAX) NULL,
    [WriterImage]    NVARCHAR (MAX) NULL,
    [WriterMail]     NVARCHAR (MAX) NULL,
    [WriterPassword] NVARCHAR (MAX) NULL,
    [WriterStatus]   BIT            NOT NULL,
    CONSTRAINT [PK_Writers] PRIMARY KEY CLUSTERED ([WriterID] ASC)
);

