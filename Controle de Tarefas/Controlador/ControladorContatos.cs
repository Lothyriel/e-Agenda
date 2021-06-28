using Controle_de_Tarefas.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Controle_de_Tarefas.Controladores
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

        private const string sqlSelecionarTodasContatos =
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

        #endregion
        public override void inserir(Contato registro)
        {
            registro.id = Db.Insert(sqlInserirContato, ObtemParametrosContato(registro));
        }
        public override void editar(int id, Contato registro)
        {
            registro.id = id;
            Db.Update(sqlEditarContato, ObtemParametrosContato(registro));
        }
        public override void excluir(int id)
        {
            Db.Delete(sqlExcluirContato, AdicionarParametro("ID", id));
        }
        public override Contato getById(int id)
        {
            return Db.Get(sqlSelecionarContatoPorId, ConverterEmContato, AdicionarParametro("ID", id));
        }
        public override List<Contato> obterRegistros()
        {
            return Db.GetAll(sqlSelecionarTodasContatos, ConverterEmContato);
        }
        private Contato ConverterEmContato(IDataReader reader)
        {
            var nome = Convert.ToString(reader["NOME"]);
            var email = Convert.ToString(reader["EMAIL"]);
            var telefone = Convert.ToString(reader["TELEFONE"]);
            var empresa = Convert.ToString(reader["EMPRESA"]);
            var cargo = Convert.ToString(reader["CARGO"]);

            Contato contato = new Contato(nome,email,telefone,empresa,cargo)
            {
                id = Convert.ToInt32(reader["ID"])
            };

            return contato;
        }
        private Dictionary<string, object> ObtemParametrosContato(Contato contato)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", contato.id);
            parametros.Add("CARGO", contato.cargo);
            parametros.Add("EMAIL", contato.email);
            parametros.Add("EMPRESA", contato.empresa);
            parametros.Add("NOME", contato.nome);
            parametros.Add("TELEFONE", contato.telefone);

            return parametros;
        }
        private static Dictionary<string, object> AdicionarParametro(string campo, int valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
        public List<Contato> ordenadosPorCargo()
        {
            return Registros.OrderBy(x => x.cargo).ToList();
        }
    }
}