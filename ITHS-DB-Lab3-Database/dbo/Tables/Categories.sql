CREATE TABLE [dbo].[Categories] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Category]       VARCHAR (255) NOT NULL,
    [Identification] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

