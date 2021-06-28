using Controle_de_Tarefas.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Controle_de_Tarefas.Controladores
{
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

        private const string sqlSelecionarTodosObjetivos =
            @"SELECT 
                [ID],       
                [DESCRICAO],       
                [FINALIZADO],             
                [ID_TAREFA]                   
            FROM
                [TBOBJETIVOS]";

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

        #endregion
        public override void inserir(Objetivo registro)
        {
            registro.id = Db.Insert(sqlInserirObjetivo, ObtemParametrosObjetivo(registro));
        }
        public override void editar(int id, Objetivo registro)
        {
            registro.id = id;
            Db.Update(sqlEditarObjetivo, ObtemParametrosObjetivo(registro));
        }
        public override void excluir(int id)
        {
            Db.Delete(sqlExcluirObjetivo, AdicionarParametro("ID", id));
        }
        public override Objetivo getById(int id)
        {
            return Db.Get(sqlSelecionarObjetivoPorId, ConverterEmObjetivo, AdicionarParametro("ID", id));
        }
        public override List<Objetivo> obterRegistros()
        {
            return Db.GetAll(sqlSelecionarTodosObjetivos, ConverterEmObjetivo);
        }
        public List<Objetivo> objetivosCompletos(int id_tarefa)
        {
            return objetivosTarefa(id_tarefa).Where(x => x.finalizado).ToList();
        }
        public List<Objetivo> objetivosIncompletos(int id_tarefa)
        {
            return objetivosTarefa(id_tarefa).Where(x => !x.finalizado).ToList();
        }
        public List<Objetivo> objetivosTarefa(int id_tarefa)
        {
            return obterRegistros().Where(x => x.id_tarefa == id_tarefa).ToList();
        }
        private Objetivo ConverterEmObjetivo(IDataReader reader)
        {
            var descricao = Convert.ToString(reader["DESCRICAO"]);
            var finalizado = Convert.ToBoolean(reader["FINALIZADO"]);
            var id_tarefa = Convert.ToInt32(reader["ID_TAREFA"]);

            Objetivo objetivo = new Objetivo(descricao, finalizado, id_tarefa);
            objetivo.id = Convert.ToInt32(reader["ID"]);

            return objetivo;
        }
        private Dictionary<string, object> ObtemParametrosObjetivo(Objetivo objetivo)
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
        private static Dictionary<string, object> AdicionarParametro(string campo, int valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
        public String ToString(int id_tarefa)
        {
            var objetivos = objetivosTarefa(id_tarefa);
            if (objetivos.Count == 0)
                return "Nenhum objetivo cadastrado";

            String strObjetivos = "";
            foreach (var objetivo in objetivos)
                strObjetivos += "- " + objetivo.ToString("sem ID") + "\n";
            return strObjetivos;
        }
    }
}