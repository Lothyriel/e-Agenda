CREATE TABLE [dbo].[TBContatos] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [nome]     NVARCHAR (50) NOT NULL,
    [email]    NVARCHAR (50) NOT NULL,
    [telefone] NVARCHAR (50) NOT NULL,
    [empresa]  NVARCHAR (50) NOT NULL,
    [cargo]    NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

