using Controle_de_Tarefas.Dominio;
using System;
using System.Collections.Generic;
using System.Data;

namespace Controle_de_Tarefas.Controladores
{
    public class ControladorTarefas : Controlador<Tarefa>
    {
        #region Queries
        private const string sqlInserirTarefa =
            @"INSERT INTO [TBTAREFAS]
                (
                    [TITULO],       
                    [PRIORIDADE],             
                    [DT_CRIACAO],                    
                    [DT_CONCLUSAO], 
                    [PORCENTAGEM_CONCLUSAO]            
                )
            VALUES
                (
                    @TITULO,
                    @PRIORIDADE,
                    @DT_CRIACAO,
                    @DT_CONCLUSAO,
                    @PORCENTAGEM_CONCLUSAO
                )";

        private const string sqlEditarTarefa =
            @" UPDATE [TBTAREFAS]
                SET 
                    [PRIORIDADE] = @PRIORIDADE, 
                    [TITULO] = @TITULO, 
                    [DT_CRIACAO] = @DT_CRIACAO, 
                    [DT_CONCLUSAO] = @DT_CONCLUSAO,
                    [PORCENTAGEM_CONCLUSAO] = @PORCENTAGEM_CONCLUSAO
                WHERE [ID] = @ID";

        private const string sqlExcluirTarefa =
            @"DELETE FROM [TBTAREFAS] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodasTarefas =
            @"SELECT 
                [ID],       
                [TITULO],       
                [PRIORIDADE],             
                [DT_CRIACAO],                    
                [DT_CONCLUSAO],
                [PORCENTAGEM_CONCLUSAO]
            FROM
                [TBTAREFAS] T
            ORDER BY 
                T.PRIORIDADE DESC";

        private const string sqlSelecionarTarefaPorId =
            @"SELECT 
                [ID],
                [TITULO],       
                [PRIORIDADE],        
                [DT_CRIACAO],       
                [DT_CONCLUSAO],
                [PORCENTAGEM_CONCLUSAO]
             FROM
                [TBTAREFAS]
             WHERE 
                [ID] = @ID";

        private const string sqlSelecionarTodasTarefasConcluidas =
            @"SELECT 
                [ID],
                [TITULO],       
                [PRIORIDADE],             
                [DT_CRIACAO],                    
                [DT_CONCLUSAO],
                [PORCENTAGEM_CONCLUSAO]
            FROM
                [TBTAREFAS] T
            WHERE 
                T.[PORCENTAGEM_CONCLUSAO] = 100
            ORDER BY 
                T.[PRIORIDADE] DESC";

        private const string sqlSelecionarTodasTarefasPendentes =
            @"SELECT 
                [ID],
                [TITULO],       
                [PRIORIDADE],             
                [DT_CRIACAO],                    
                [DT_CONCLUSAO],
                [PORCENTAGEM_CONCLUSAO]
            FROM
                [TBTAREFAS] T
            WHERE 
                T.[PORCENTAGEM_CONCLUSAO] <> 100
            ORDER BY 
                T.[PRIORIDADE] DESC";

        #endregion
        public override string sqlInserir => sqlInserirTarefa;
        public override string sqlEditar => sqlEditarTarefa;
        public override string sqlExcluir => sqlExcluirTarefa;
        public override string sqlSelecionarPorId => sqlSelecionarTarefaPorId;
        public override string sqlSelecionarTodos => sqlSelecionarTodasTarefas;

        public override Tarefa ConverterEmRegistro(IDataReader reader)
        {
            var titulo = Convert.ToString(reader["TITULO"]);
            var prioridade = Convert.ToInt32(reader["PRIORIDADE"]);
            var DT_CRIACAO = Convert.ToDateTime(reader["DT_CRIACAO"]);
            int PORCENTAGEM_CONCLUSAO = Convert.ToInt32(reader["PORCENTAGEM_CONCLUSAO"]);

            Tarefa tarefa = new Tarefa(PORCENTAGEM_CONCLUSAO, DT_CRIACAO, prioridade, titulo)
            {
                id = Convert.ToInt32(reader["ID"])
            };

            if (reader["DT_CONCLUSAO"] != DBNull.Value)
                tarefa.dt_conclusao = Convert.ToDateTime(reader["DT_CONCLUSAO"]);

            tarefa.addObjetivo();

            return tarefa;
        }
        public override Dictionary<string, object> ObtemParametrosRegistro(Tarefa tarefa)
        {
            var parametros = new Dictionary<string, object>
            {
                { "ID", tarefa.id },
                { "TITULO", tarefa.titulo },
                { "PRIORIDADE", tarefa.prioridade },
                { "DT_CRIACAO", tarefa.dt_criacao },
                { "DT_CONCLUSAO", tarefa.dt_conclusao },
                { "PORCENTAGEM_CONCLUSAO", tarefa.porcentagem_conclusao }
            };

            return parametros;
        }

        public List<Tarefa> tarefasCompletas()
        {
            return Db.GetAll(sqlSelecionarTodasTarefasConcluidas, ConverterEmRegistro);
        }
        public List<Tarefa> tarefasIncompletas()
        {
            return Db.GetAll(sqlSelecionarTodasTarefasPendentes, ConverterEmRegistro);
        }
    }
}