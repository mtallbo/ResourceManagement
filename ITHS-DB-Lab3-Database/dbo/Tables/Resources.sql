CREATE TABLE [dbo].[Resources] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [CategoryId]  INT           NULL,
    [Name]        VARCHAR (255) NOT NULL,
    [Description] VARCHAR (255) NOT NULL,
    [Cost]        INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ResourcesName]
    ON [dbo].[Resources]([Name] ASC);

