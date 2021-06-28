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
        public override void inserir(Tarefa registro)
        {
            registro.id = Db.Insert(sqlInserirTarefa, ObtemParametrosTarefa(registro));
        }
        public override void editar(int id, Tarefa registro)
        {
            registro.id = id;
            Db.Update(sqlEditarTarefa, ObtemParametrosTarefa(registro));
        }
        public override void excluir(int id)
        {
            Db.Delete(sqlExcluirTarefa, AdicionarParametro("ID", id));
        }
        public override Tarefa getById(int id)
        {
            return Db.Get(sqlSelecionarTarefaPorId, ConverterEmTarefa, AdicionarParametro("ID", id));
        }
        public override List<Tarefa> obterRegistros()
        {
            return Db.GetAll(sqlSelecionarTodasTarefas, ConverterEmTarefa);
        }
        public List<Tarefa> tarefasCompletas()
        {
            return Db.GetAll(sqlSelecionarTodasTarefasConcluidas, ConverterEmTarefa);
        }
        public List<Tarefa> tarefasIncompletas()
        {
            return Db.GetAll(sqlSelecionarTodasTarefasPendentes, ConverterEmTarefa);
        }
        private Tarefa ConverterEmTarefa(IDataReader reader)
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
        private Dictionary<string, object> ObtemParametrosTarefa(Tarefa tarefa)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", tarefa.id);
            parametros.Add("TITULO", tarefa.titulo);
            parametros.Add("PRIORIDADE", tarefa.prioridade);
            parametros.Add("DT_CRIACAO", tarefa.dt_criacao);
            parametros.Add("DT_CONCLUSAO", tarefa.dt_conclusao);
            parametros.Add("PORCENTAGEM_CONCLUSAO", tarefa.porcentagem_conclusao);

            return parametros;
        }
        private static Dictionary<string, object> AdicionarParametro(string campo, int valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}