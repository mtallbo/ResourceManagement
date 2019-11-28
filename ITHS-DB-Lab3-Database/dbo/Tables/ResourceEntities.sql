CREATE TABLE [dbo].[ResourceEntities] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [ResourceId]           INT           NOT NULL,
    [EntityId]             INT           NOT NULL,
    [IdentificationNumber] VARCHAR (255) NULL,
    [LostByLoanId]              INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[Resources] ([Id]),
	FOREIGN KEY ([LostByLoanId]) REFERENCES [dbo].[Loans] ([ID])
);

