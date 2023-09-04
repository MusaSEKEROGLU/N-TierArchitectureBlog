CREATE TABLE [dbo].[Message2s] (
    [MessageID]      INT            IDENTITY (1, 1) NOT NULL,
    [SenderID]       INT            NULL,
    [ReceiverID]     INT            NULL,
    [Subject]        NVARCHAR (MAX) NULL,
    [MessageDetails] NVARCHAR (MAX) NULL,
    [MessageDate]    DATETIME2 (7)  NOT NULL,
    [MessageStatus]  BIT            NOT NULL,
    CONSTRAINT [PK_Message2s] PRIMARY KEY CLUSTERED ([MessageID] ASC),
    CONSTRAINT [FK_Message2s_Writers_ReceiverID] FOREIGN KEY ([ReceiverID]) REFERENCES [dbo].[Writers] ([WriterID]),
    CONSTRAINT [FK_Message2s_Writers_SenderID] FOREIGN KEY ([SenderID]) REFERENCES [dbo].[Writers] ([WriterID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Message2s_ReceiverID]
    ON [dbo].[Message2s]([ReceiverID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Message2s_SenderID]
    ON [dbo].[Message2s]([SenderID] ASC);

