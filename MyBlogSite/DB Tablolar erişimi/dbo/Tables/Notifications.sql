CREATE TABLE [dbo].[Notifications] (
    [NotificationID]         INT            IDENTITY (1, 1) NOT NULL,
    [NotificationType]       NVARCHAR (MAX) NULL,
    [NotificationTypeSymbol] NVARCHAR (MAX) NULL,
    [NotificationDetails]    NVARCHAR (MAX) NULL,
    [NotificationDate]       DATETIME2 (7)  NOT NULL,
    [NotificationStatus]     BIT            NOT NULL,
    [NotificationColor]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED ([NotificationID] ASC)
);

