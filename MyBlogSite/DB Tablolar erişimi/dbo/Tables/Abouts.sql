CREATE TABLE [dbo].[Abouts] (
    [AboutID]          INT            IDENTITY (1, 1) NOT NULL,
    [AboutDetails1]    NVARCHAR (MAX) NULL,
    [AboutDetails2]    NVARCHAR (MAX) NULL,
    [AboutImage1]      NVARCHAR (MAX) NULL,
    [AboutImage2]      NVARCHAR (MAX) NULL,
    [AboutMapLocation] NVARCHAR (MAX) NULL,
    [AboutStatus]      BIT            NOT NULL,
    CONSTRAINT [PK_Abouts] PRIMARY KEY CLUSTERED ([AboutID] ASC)
);

