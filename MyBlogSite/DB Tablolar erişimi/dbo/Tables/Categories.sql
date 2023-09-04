CREATE TABLE [dbo].[Categories] (
    [CategoryID]          INT            IDENTITY (1, 1) NOT NULL,
    [CategoryName]        NVARCHAR (MAX) NULL,
    [CategoryDescription] NVARCHAR (MAX) NULL,
    [CategoryStatus]      BIT            NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);

