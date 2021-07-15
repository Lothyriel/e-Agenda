CREATE TABLE [dbo].[TBCompromissos] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [id_contato]  INT           NULL,
    [assunto]     NVARCHAR (50) NOT NULL,
    [local]       NVARCHAR (50) NOT NULL,
    [data_inicio] DATETIME      NOT NULL,
    [data_fim]    DATETIME      NOT NULL,
    CONSTRAINT [PK_TBCompromissos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

