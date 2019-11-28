CREATE TABLE [dbo].[Loans] (
    [Id]               INT  IDENTITY (1, 1) NOT NULL,
    [LoanerId]         INT  NOT NULL,
    [BorrowerId]       INT  NOT NULL,
    [ResourceEntityId] INT  NOT NULL,
    [StartDate]        DATE NOT NULL,
    [EndDate]          DATE NOT NULL,
    [ReturnDate]       DATE NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([BorrowerId]) REFERENCES [dbo].[User] ([Id]),
    FOREIGN KEY ([LoanerId]) REFERENCES [dbo].[User] ([Id]),
    FOREIGN KEY ([ResourceEntityId]) REFERENCES [dbo].[ResourceEntities] ([Id])
);

