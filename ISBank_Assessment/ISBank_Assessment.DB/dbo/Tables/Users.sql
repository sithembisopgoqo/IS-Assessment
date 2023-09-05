CREATE TABLE [dbo].[Users] (
    [UserId]              INT            IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [UserName]            VARCHAR (255)  NOT NULL,
    [FirstName]           VARCHAR (50)   NOT NULL,
    [LastName]            VARCHAR (50)   NOT NULL,
    [EmailAddress]        VARCHAR (100)  NULL,
    [DateCreated]         DATETIME2 (7)  NOT NULL,
    [LastLogin]           DATETIME2 (7)  NULL,
    [Password]            VARCHAR (8000) NOT NULL,
    [LastUpdatedBy]       VARCHAR (50)   NULL,
    [LoginCount]          INT            NULL,
    [ForceChangePassword] BIT            NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

