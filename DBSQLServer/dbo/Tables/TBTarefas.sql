CREATE TABLE [dbo].[TBTarefas] (
    [id]                    INT           IDENTITY (1, 1) NOT NULL,
    [porcentagem_conclusao] INT           NOT NULL,
    [dt_criacao]            DATETIME      NOT NULL,
    [dt_conclusao]          DATETIME      NOT NULL,
    [prioridade]            INT           NOT NULL,
    [titulo]                NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TBTarefas] PRIMARY KEY CLUSTERED ([id] ASC)
);

