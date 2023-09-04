CREATE TABLE [dbo].[Contacts] (
    [ContactID]       INT            IDENTITY (1, 1) NOT NULL,
    [ContactUserName] NVARCHAR (MAX) NULL,
    [ContactMail]     NVARCHAR (MAX) NULL,
    [ContactSubject]  NVARCHAR (MAX) NULL,
    [ContactMessage]  NVARCHAR (MAX) NULL,
    [ContactDate]     DATETIME2 (7)  NOT NULL,
    [ContactStatus]   BIT            NOT NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED ([ContactID] ASC)
);

