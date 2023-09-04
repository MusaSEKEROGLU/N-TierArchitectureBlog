CREATE TABLE [dbo].[Messages] (
    [MessageID]      INT            IDENTITY (1, 1) NOT NULL,
    [Sender]         NVARCHAR (MAX) NULL,
    [Receiver]       NVARCHAR (MAX) NULL,
    [Subject]        NVARCHAR (MAX) NULL,
    [MessageDetails] NVARCHAR (MAX) NULL,
    [MessageDate]    DATETIME2 (7)  NOT NULL,
    [MessageStatus]  BIT            NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([MessageID] ASC)
);

