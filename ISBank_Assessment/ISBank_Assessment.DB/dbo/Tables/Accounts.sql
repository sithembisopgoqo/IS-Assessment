CREATE TABLE [dbo].[Accounts] (
    [code]                INT          IDENTITY (1, 1) NOT NULL,
    [person_code]         INT          NOT NULL,
    [account_number]      VARCHAR (50) NOT NULL,
    [outstanding_balance] MONEY        NOT NULL,
    [StatusId]            INT          NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([code] ASC),
    FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([StatusId]),
    CONSTRAINT [FK_Account_Person] FOREIGN KEY ([person_code]) REFERENCES [dbo].[Persons] ([code])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Account_num]
    ON [dbo].[Accounts]([account_number] ASC);

