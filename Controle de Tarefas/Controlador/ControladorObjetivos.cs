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
        public override string sqlInserir => sqlInserirObjetivo;
        public override string sqlEditar => sqlEditarObjetivo;
        public override string sqlExcluir => sqlExcluirObjetivo;
        public override string sqlSelecionarPorId => sqlSelecionarObjetivoPorId;
        public override string sqlSelecionarTodos => sqlSelecionarTodosObjetivos;

        public override Objetivo ConverterEmRegistro(IDataReader reader)
        {
            var descricao = Convert.ToString(reader["DESCRICAO"]);
            var finalizado = Convert.ToBoolean(reader["FINALIZADO"]);
            var id_tarefa = Convert.ToInt32(reader["ID_TAREFA"]);

            Objetivo objetivo = new Objetivo(descricao, finalizado, id_tarefa)
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
            return Registros.Where(x => x.id_tarefa == id_tarefa).ToList();
        }
    }
}