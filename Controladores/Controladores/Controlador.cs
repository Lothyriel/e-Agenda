using e_Agenda.Dominio;
using System.Collections.Generic;
using System.Data;

namespace e_Agenda.Controladores
{
    /// <summary>
    /// Classe controladora genérica.
    /// </summary>
    abstract public class Controlador<T> where T : Entidade
    {
        public List<T> Registros => obterRegistros();

        public abstract string sqlSelecionarPorId { get; }
        public abstract string sqlSelecionarTodos { get; }
        public abstract string sqlInserir { get; }
        public abstract string sqlEditar { get; }
        public abstract string sqlExcluir { get; }
        public abstract string sqlExists { get; }


        /// <summary>
        /// Obtém um registro do banco de dados por ID
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A T.</returns>
        public T getById(int id)
        {
            return Db.Get(sqlSelecionarPorId, ConverterEmRegistro, AdicionarParametro("ID", id));
        }
        /// <summary>
        /// Obtém todos os registros do banco de dados.
        /// </summary>
        /// <returns>A list of TS.</returns>
        public List<T> obterRegistros()
        {
            return Db.GetAll(sqlSelecionarTodos, ConverterEmRegistro);
        }
        /// <summary>
        /// Insere um registro no banco de dados.
        /// </summary>
        /// <param name="registro">The registro.</param>
        public void inserir(T registro)
        {
            registro.id = Db.Insert(sqlInserir, ObtemParametrosRegistro(registro));
        }
        /// <summary>
        /// Edita um registro do banco de dados.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="registro">The registro.</param>
        public void editar(int id, T registro)
        {
            registro.id = id;
            Db.Update(sqlEditar, ObtemParametrosRegistro(registro));
        }
        /// <summary>
        /// Exclui um registro do banco de dados por id.
        /// </summary>
        /// <param name="id">The id.</param>
        public void excluir(int id)
        {
            Db.Delete(sqlExcluir, AdicionarParametro("ID", id));
        }
        /// <summary>
        /// Verifica se um registro está presente no banco de dados por id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A bool.</returns>
        public bool exists(int id)
        {
            return Db.Exists(sqlExists, AdicionarParametro("ID", id));
        }

        /// <summary>
        /// Converte os dados resgatados do banco de dados em uma entidade específica para o programa.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>A T.</returns>
        public abstract T ConverterEmRegistro(IDataReader reader);
        /// <summary>
        /// Obtem os parametros de uma entidade.
        /// </summary>
        /// <param name="registro">The registro.</param>
        /// <returns>A Dictionary.</returns>
        public abstract Dictionary<string, object> ObtemParametrosRegistro(T registro);
        /// <summary>
        /// Retorna um dicionário com os parâmetros de uma entidade.
        /// </summary>
        /// <param name="campo">The campo.</param>
        /// <param name="valor">The valor.</param>
        /// <returns>A Dictionary.</returns>
        protected static Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}