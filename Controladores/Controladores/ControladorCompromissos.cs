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
            @"SELECT *
            FROM
                [TBCompromissos] AS CP LEFT JOIN 
                [TBContatos] AS CT
            ON
                CT.[ID] = CP.[ID_CONTATO]";

        private const string sqlSelecionarCompromissoPorId =
            @"SELECT *
            FROM
                [TBCompromissos] AS CP LEFT JOIN 
                [TBContatos] AS CT
            ON
                CT.[ID] = CP.[ID_CONTATO]
            WHERE 
                CP.[ID] = @ID";

        private const string sqlExisteCompromisso =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCompromissos]
            WHERE 
                [ID] = @ID";

        private const string sqlVerificarHorarioOcupado =
            @"SELECT COUNT(*)
            FROM [TBCompromissos]
            WHERE
            CAST([DATA_INICIO] AS date) = CAST(@DATA_INICIO_NOVA AS date)
            AND             
            @DATA_INICIO_NOVA BETWEEN [DATA_INICIO] AND [DATA_FIM]
            OR 
            @DATA_FIM_NOVA BETWEEN [DATA_INICIO] AND [DATA_FIM]
            OR
            [DATA_INICIO] BETWEEN @DATA_INICIO_NOVA AND @DATA_FIM_NOVA
            OR 
            [DATA_FIM] BETWEEN @DATA_INICIO_NOVA AND @DATA_FIM_NOVA";

        private const string sqlSelecionarCompromissosPassados =
            @"SELECT * 
            FROM
                [TBCompromissos] AS CP LEFT JOIN 
                [TBContatos] AS CT
            ON
                CT.[ID] = CP.[ID_CONTATO]
            WHERE [DATA_FIM] < @DATA_FIM";

        private const string sqlSelecionarCompromissosFuturosAntesDeUmaData =
            @"SELECT * 
            FROM
                [TBCompromissos] AS CP LEFT JOIN 
                [TBContatos] AS CT
            ON
                CT.[ID] = CP.[ID_CONTATO]
            WHERE [DATA_FIM] < @DATA_FIM
            AND [DATA_FIM] > SYSDATETIME()";

        private const string sqlSelecionarCompromissosFuturos =
            @"SELECT * 
            FROM
                [TBCompromissos] AS CP LEFT JOIN 
                [TBContatos] AS CT
            ON
                CT.[ID] = CP.[ID_CONTATO]
            WHERE [DATA_FIM] > SYSDATETIME()";

        #endregion
        public override string sqlInserir => sqlInserirCompromisso;
        public override string sqlEditar => sqlEditarCompromisso;
        public override string sqlExcluir => sqlExcluirCompromisso;
        public override string sqlSelecionarPorId => sqlSelecionarCompromissoPorId;
        public override string sqlSelecionarTodos => sqlSelecionarTodosCompromissos;
        public override string sqlExists => sqlExisteCompromisso;

        public override Compromisso ConverterEmRegistro(IDataReader reader)
        {
            var assunto = Convert.ToString(reader["ASSUNTO"]);
            var local = Convert.ToString(reader["LOCAL"]);
            var data_inicio = Convert.ToDateTime(reader["DATA_INICIO"]);
            var data_fim = Convert.ToDateTime(reader["DATA_FIM"]);

            var email = Convert.ToString(reader["EMAIL"]);
            var nome = Convert.ToString(reader["NOME"]);
            var telefone = Convert.ToString(reader["TELEFONE"]);
            var empresa = Convert.ToString(reader["EMPRESA"]);
            var cargo = Convert.ToString(reader["CARGO"]);


            Compromisso compromisso = new Compromisso(assunto, local, data_inicio, data_fim)
            {
                id = Convert.ToInt32(reader["ID"])
            };

            Contato contato = null;
            if (reader["ID_CONTATO"] != DBNull.Value)
            {
                contato = new Contato(nome, email, telefone, empresa, cargo)
                {
                    id = Convert.ToInt32(reader["ID_CONTATO"])
                };
            }
            compromisso.contato = contato;

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
            return compromissosFuturosAteData(DateTime.Now.Add(periodo));
        }
        public List<Compromisso> compromissosPassados()
        {
            return Db.GetAll(sqlSelecionarCompromissosPassados, ConverterEmRegistro, AdicionarParametro("DATA_FIM", DateTime.Now));
        }
        public List<Compromisso> compromissosFuturosAteData(DateTime dataMax)
        {
            return Db.GetAll(sqlSelecionarCompromissosFuturosAntesDeUmaData, ConverterEmRegistro, AdicionarParametro("DATA_FIM", dataMax));
        }
        public List<Compromisso> compromissosFuturos()
        {
            return Db.GetAll(sqlSelecionarCompromissosFuturos, ConverterEmRegistro);
        }

        public bool horarioDisponivel(Compromisso comp)
        {
            var parametros = new Dictionary<string, object>
            {
                { "DATA_INICIO_NOVA", comp.data_inicio },
                { "DATA_FIM_NOVA", comp.data_fim }
            };

            return !Db.Exists(sqlVerificarHorarioOcupado, parametros);
        }
    }
}
