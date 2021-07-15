using e_Agenda.Dominio;
using System;
using System.Collections.Generic;
using System.Data;

namespace e_Agenda.Controladores
{
    public class ControladorCompromissos : Controlador<Compromisso>
    {
        #region Queries
        private const string sqlInserirCompromisso =
            @"INSERT INTO [TBCOMPROMISSOS]
                (
                    [ASSUNTO],       
                    [LOCAL],             
                    [DATA_INICIO], 
                    [DATA_FIM],
                    [ID_CONTATO]
                )
            VALUES
                (
                    @ASSUNTO,
                    @LOCAL,
                    @DATA_INICIO,
                    @DATA_FIM,
                    @ID_CONTATO
                )";

        private const string sqlEditarCompromisso =
            @" UPDATE [TBCOMPROMISSOS]
                SET 
                    [LOCAL] = @LOCAL, 
                    [ASSUNTO] = @ASSUNTO, 
                    [DATA_INICIO] = @DATA_INICIO,
                    [DATA_FIM] = @DATA_FIM,
                    [ID_CONTATO] = @ID_CONTATO
                WHERE [ID] = @ID";

        private const string sqlExcluirCompromisso =
            @"DELETE FROM [TBCOMPROMISSOS] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodosCompromissos =
            @"SELECT 
                [ID],       
                [ASSUNTO],       
                [LOCAL],             
                [DATA_INICIO],
                [DATA_FIM],
                [ID_CONTATO]
            FROM
                [TBCOMPROMISSOS]";

        private const string sqlSelecionarCompromissoPorId =
            @"SELECT 
                [ID],
                [ASSUNTO],       
                [LOCAL],        
                [DATA_INICIO],
                [DATA_FIM],
                [ID_CONTATO]
             FROM
                [TBCOMPROMISSOS]
             WHERE 
                [ID] = @ID";

        private const string sqlSelectCountDatasEntre =
            @"SELECT
	            COUNT(*)
            FROM 
	            TBCOMPROMISSO
            WHERE 
                [DATA_INICIO] = @DATA_INICIO 
            AND 
                @DATA_INICIO_DESEJADO BETWEEN DATA_INICIO AND DATA_FIM 
            OR 
                @DATA_FIM_DESEJADO BETWEEN DATA_INICIO AND DATA_FIM";

        #endregion
        public string sqlSelecionarAntesDeUmaData => sqlSelecionarTodos + "WHERE [DATA_FIM] < @DATA_FIM";
        public override string sqlInserir => sqlInserirCompromisso;
        public override string sqlEditar => sqlEditarCompromisso;
        public override string sqlExcluir => sqlExcluirCompromisso;
        public override string sqlSelecionarPorId => sqlSelecionarCompromissoPorId;
        public override string sqlSelecionarTodos => sqlSelecionarTodosCompromissos;
        public override Compromisso ConverterEmRegistro(IDataReader reader)
        {
            var assunto = Convert.ToString(reader["ASSUNTO"]);
            var local = Convert.ToString(reader["LOCAL"]);
            var data_inicio = Convert.ToDateTime(reader["DATA_INICIO"]);
            var data_fim = Convert.ToDateTime(reader["DATA_FIM"]);

            Compromisso compromisso = new Compromisso(assunto, local, data_inicio, data_fim, null)
            {
                id = Convert.ToInt32(reader["ID"])
            };
            if (reader["ID_CONTATO"] != DBNull.Value)
                compromisso.contato = new ControladorContatos().getById(Convert.ToInt32(reader["ID_CONTATO"]));

            return compromisso;
        }
        public override Dictionary<string, object> ObtemParametrosRegistro(Compromisso compromisso)
        {
            var parametros = new Dictionary<string, object>
            {
                { "ID", compromisso.id },
                { "DATA_FIM", compromisso.data_fim },
                { "LOCAL", compromisso.local },
                { "DATA_INICIO", compromisso.data_inicio },
                { "ASSUNTO", compromisso.assunto }
            };

            if (compromisso.contato != null)
                parametros.Add("ID_CONTATO", compromisso.contato.id);
            else
                parametros.Add("ID_CONTATO", DBNull.Value);

            return parametros;
        }

        public List<Compromisso> filtrarPorPeriodo(TimeSpan periodo)
        {
            return compromissosFuturos(DateTime.Now.Add(periodo));
        }
        public List<Compromisso> compromissosPassados()
        {
            return Db.GetAll(sqlSelecionarAntesDeUmaData, ConverterEmRegistro, AdicionarParametro("DATA_FIM", DateTime.Now));
        }
        public List<Compromisso> compromissosFuturos(DateTime dataMax)
        {
            return Db.GetAll(sqlSelecionarAntesDeUmaData, ConverterEmRegistro, AdicionarParametro("DATA_FIM", dataMax));
        }

        public bool horarioDisponivel()
        {
            return Db.Exists(sqlSelectCountDatasEntre, sqlSelecionarAntesDeUmaData);
        }
    }
}
