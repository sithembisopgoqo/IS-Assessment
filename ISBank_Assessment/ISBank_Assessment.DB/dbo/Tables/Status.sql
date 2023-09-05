CREATE TABLE [dbo].[Status] (
    [StatusId]    INT          IDENTITY (1, 1) NOT NULL,
    [StatusTypes] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([StatusId] ASC)
);

