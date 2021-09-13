CREATE TABLE [dbo].[TBObjetivos] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [descricao]  NVARCHAR (50) NOT NULL,
    [finalizado] BIT           NOT NULL,
    [id_tarefa]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBObjetivos_ToTBTarefas] FOREIGN KEY ([id_tarefa]) REFERENCES [dbo].[TBTarefas] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);



