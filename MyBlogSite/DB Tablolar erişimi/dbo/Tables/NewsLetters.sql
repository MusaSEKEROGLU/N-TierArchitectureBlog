CREATE TABLE [dbo].[NewsLetters] (
    [MailID]     INT            IDENTITY (1, 1) NOT NULL,
    [Mail]       NVARCHAR (MAX) NULL,
    [MailStatus] BIT            NOT NULL,
    CONSTRAINT [PK_NewsLetters] PRIMARY KEY CLUSTERED ([MailID] ASC)
);

