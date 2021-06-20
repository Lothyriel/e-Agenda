CREATE TABLE [dbo].[TBTarefas] (
    [id]                    INT           IDENTITY (1, 1) NOT NULL,
    [porcentagem_conclusao] INT           NOT NULL,
    [dt_criacao]            DATETIME2 (7) NOT NULL,
    [dt_conclusao]          DATETIME2 (7) NOT NULL,
    [prioridade]            INT           NOT NULL,
    [titulo]                NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

