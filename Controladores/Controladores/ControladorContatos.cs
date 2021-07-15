using e_Agenda.Dominio;
using System;
using System.Collections.Generic;
using System.Data;

namespace e_Agenda.Controladores
{
    public class ControladorContatos : Controlador<Contato>
    {
        #region Queries
        private const string sqlInserirContato =
            @"INSERT INTO [TBCONTATOS]
                (
                    [NOME],       
                    [EMAIL],             
                    [TELEFONE],                    
                    [EMPRESA], 
                    [CARGO]            
                )
            VALUES
                (
                    @NOME,
                    @EMAIL,
                    @TELEFONE,
                    @EMPRESA,
                    @CARGO
                )";

        private const string sqlEditarContato =
            @" UPDATE [TBCONTATOS]
                SET 
                    [EMAIL] = @EMAIL, 
                    [NOME] = @NOME, 
                    [TELEFONE] = @TELEFONE, 
                    [EMPRESA] = @EMPRESA,
                    [CARGO] = @CARGO
                WHERE [ID] = @ID";

        private const string sqlExcluirContato =
            @"DELETE FROM [TBCONTATOS] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodosContatos =           //nao to usando agora 
            @"SELECT 
                [ID],       
                [NOME],       
                [EMAIL],             
                [TELEFONE],                    
                [EMPRESA],
                [CARGO]
            FROM
                [TBCONTATOS]";

        private const string sqlSelecionarContatoPorId =
            @"SELECT 
                [ID],
                [NOME],       
                [EMAIL],        
                [TELEFONE],       
                [EMPRESA],
                [CARGO]
             FROM
                [TBCONTATOS]
             WHERE 
                [ID] = @ID";

        private const string sqlSelecionarContatosOrdenadoCargo =
            @"SELECT 
                [ID],       
                [NOME],       
                [EMAIL],             
                [TELEFONE],                    
                [EMPRESA],
                [CARGO]
            FROM
                [TBCONTATOS] C
            ORDER BY 
                C.[NOME] DESC";

        #endregion
        public override string sqlInserir => sqlInserirContato;
        public override string sqlEditar => sqlEditarContato;
        public override string sqlExcluir => sqlExcluirContato;
        public override string sqlSelecionarPorId => sqlSelecionarContatoPorId;
        public override string sqlSelecionarTodos => sqlSelecionarContatosOrdenadoCargo;
        public override Contato ConverterEmRegistro(IDataReader reader)
        {
            var nome = Convert.ToString(reader["NOME"]);
            var email = Convert.ToString(reader["EMAIL"]);
            var telefone = Convert.ToString(reader["TELEFONE"]);
            var empresa = Convert.ToString(reader["EMPRESA"]);
            var cargo = Convert.ToString(reader["CARGO"]);

            Contato contato = new Contato(nome, email, telefone, empresa, cargo)
            {
                id = Convert.ToInt32(reader["ID"])
            };

            return contato;
        }
        public override Dictionary<string, object> ObtemParametrosRegistro(Contato contato)
        {
            var parametros = new Dictionary<string, object>
            {
                { "ID", contato.id },
                { "CARGO", contato.cargo },
                { "EMAIL", contato.email },
                { "EMPRESA", contato.empresa },
                { "NOME", contato.nome },
                { "TELEFONE", contato.telefone }
            };

            return parametros;
        }
    }
}