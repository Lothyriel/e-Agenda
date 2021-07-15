using e_Agenda.Dominio;
using System;
using System.Collections.Generic;
using System.Data;

namespace e_Agenda.Controladores
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
                [TBOBJETIVOS] O
            WHERE 
                O.[ID_TAREFA] = ";

        #endregion
        public override string sqlInserir => sqlInserirObjetivo;
        public override string sqlEditar => sqlEditarObjetivo;
        public override string sqlExcluir => sqlExcluirObjetivo;
        public override string sqlSelecionarPorId => sqlSelecionarObjetivoPorId;        //nao usado ainda
        public override string sqlSelecionarTodos => sqlSelecionarTodosObjetivosTarefa;

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
        public List<Objetivo> objetivosCompletos(int id_tarefa)
        {
            return Db.GetAll(sqlSelecionarTodosObjetivosTarefa + id_tarefa + " AND O.[FINALIZADO] =  1", ConverterEmRegistro);
        }
        public List<Objetivo> objetivosIncompletos(int id_tarefa)
        {
            return Db.GetAll(sqlSelecionarTodosObjetivosTarefa + id_tarefa + " AND O.[FINALIZADO] =  0", ConverterEmRegistro);
        }
        public List<Objetivo> objetivosTarefa(int id_tarefa)
        {
            return Db.GetAll(sqlSelecionarTodosObjetivosTarefa + id_tarefa, ConverterEmRegistro);
        }
    }
}