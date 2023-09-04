CREATE TABLE [dbo].[BlogRaytings] (
    [BlogRaytingID]    INT IDENTITY (1, 1) NOT NULL,
    [BlogID]           INT NOT NULL,
    [BlogTotalScore]   INT NOT NULL,
    [BlogRaytingCount] INT NOT NULL,
    CONSTRAINT [PK_BlogRaytings] PRIMARY KEY CLUSTERED ([BlogRaytingID] ASC)
);

