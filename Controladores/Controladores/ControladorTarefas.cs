using e_Agenda.Dominio;
using System;
using System.Collections.Generic;
using System.Data;

namespace e_Agenda.Controladores
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

        private const string sqlExisteTarefa =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBTarefas]
            WHERE 
                [ID] = @ID";

        #endregion
        public override string sqlInserir => sqlInserirTarefa;
        public override string sqlEditar => sqlEditarTarefa;
        public override string sqlExcluir => sqlExcluirTarefa;
        public override string sqlSelecionarPorId => sqlSelecionarTarefaPorId;
        public override string sqlSelecionarTodos => sqlSelecionarTodasTarefas;

        public override string sqlExists => sqlExisteTarefa;

        public override Tarefa ConverterEmRegistro(IDataReader reader)
        {
            var titulo = Convert.ToString(reader["TITULO"]);
            var prioridade = Convert.ToInt32(reader["PRIORIDADE"]);

            Tarefa tarefa = new Tarefa(prioridade, titulo) {
                id = Convert.ToInt32(reader["ID"]),
                dt_criacao = Convert.ToDateTime(reader["DT_CRIACAO"]),
                porcentagem_conclusao = Convert.ToInt32(reader["PORCENTAGEM_CONCLUSAO"])
            };

            if (reader["DT_CONCLUSAO"] != DBNull.Value)
                tarefa.dt_conclusao = Convert.ToDateTime(reader["DT_CONCLUSAO"]);

            tarefa.objetivos = new ControladorObjetivos().objetivosTarefa(tarefa.id);
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

        public class ControladorObjetivos : Controlador<Objetivo>
        {
            #region Queries
            private const string sqlInserirObjetivo =
                @"INSERT INTO [TBOBJETIVOS]
                (
                    [DESCRICAO],       
                    [FINALIZADO],             
                    [ID_TAREFA]                        
                )
            VALUES
                (
                    @DESCRICAO,
                    @FINALIZADO,
                    @ID_TAREFA
                )";

            private const string sqlEditarObjetivo =
                @" UPDATE [TBOBJETIVOS]
                SET 
                    [DESCRICAO] = @DESCRICAO, 
                    [FINALIZADO] = @FINALIZADO, 
                    [ID_TAREFA] = @ID_TAREFA 
                WHERE [ID] = @ID";

            private const string sqlExcluirObjetivo =
                @"DELETE FROM [TBOBJETIVOS] 
                WHERE [ID] = @ID";


            private const string sqlSelecionarObjetivoPorId =
                @"SELECT 
                [ID],
                [DESCRICAO],       
                [FINALIZADO],        
                [ID_TAREFA]
             FROM
                [TBOBJETIVOS]
             WHERE 
                [ID] = @ID";

            private const string sqlSelecionarTodosObjetivosTarefa =
                @"SELECT 
                [ID],       
                [DESCRICAO],       
                [FINALIZADO],             
                [ID_TAREFA]                   
            FROM
                [TBOBJETIVOS] AS O
            WHERE 
                O.[ID_TAREFA] = @ID_TAREFA";

            private const string sqlSelecionarTodosObjetivosIncompletosTarefa =
                @"SELECT 
                [ID],       
                [DESCRICAO],       
                [FINALIZADO],             
                [ID_TAREFA]                   
            FROM
                [TBOBJETIVOS] AS O
            WHERE 
                O.[ID_TAREFA] = @ID_TAREFA
            AND 
                O.[FINALIZADO] =  0";

            private const string sqlExisteObjetivo =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBObjetivos]
            WHERE 
                [ID] = @ID";

            #endregion
            public override string sqlInserir => sqlInserirObjetivo;
            public override string sqlEditar => sqlEditarObjetivo;
            public override string sqlExcluir => sqlExcluirObjetivo;
            public override string sqlSelecionarPorId => sqlSelecionarObjetivoPorId;        //nao usado ainda
            public override string sqlSelecionarTodos => sqlSelecionarTodosObjetivosTarefa;
            public override string sqlExists => sqlExisteObjetivo;

            public override Objetivo ConverterEmRegistro(IDataReader reader)
            {
                var descricao = Convert.ToString(reader["DESCRICAO"]);
                var finalizado = Convert.ToBoolean(reader["FINALIZADO"]);
                var id_tarefa = Convert.ToInt32(reader["ID_TAREFA"]);

                Objetivo objetivo = new Objetivo(descricao, id_tarefa, finalizado)
                {
                    id = Convert.ToInt32(reader["ID"])
                };

                return objetivo;
            }
            public override Dictionary<string, object> ObtemParametrosRegistro(Objetivo objetivo)
            {
                var parametros = new Dictionary<string, object>
            {
                { "ID", objetivo.id },
                { "DESCRICAO", objetivo.descricao },
                { "FINALIZADO", objetivo.finalizado },
                { "ID_TAREFA", objetivo.id_tarefa }
            };

                return parametros;
            }
            public List<Objetivo> objetivosIncompletos(int id_tarefa)
            {
                return Db.GetAll(sqlSelecionarTodosObjetivosIncompletosTarefa, ConverterEmRegistro, AdicionarParametro("ID_TAREFA", id_tarefa));
            }
            public List<Objetivo> objetivosTarefa(int id_tarefa)
            {
                return Db.GetAll(sqlSelecionarTodosObjetivosTarefa, ConverterEmRegistro, AdicionarParametro("ID_TAREFA", id_tarefa));
            }
        }
    }
}