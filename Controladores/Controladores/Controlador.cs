using e_Agenda.Dominio;
using System.Collections.Generic;
using System.Data;

namespace e_Agenda.Controladores
{
    abstract public class Controlador<T> where T : Entidade
    {
        public List<T> Registros => obterRegistros();

        public abstract string sqlSelecionarPorId { get; }
        public abstract string sqlSelecionarTodos { get; }
        public abstract string sqlInserir { get; }
        public abstract string sqlEditar { get; }
        public abstract string sqlExcluir { get; }

        public T getById(int id)
        {
            return Db.Get(sqlSelecionarPorId, ConverterEmRegistro, AdicionarParametro("ID", id));
        }
        public List<T> obterRegistros()
        {
            return Db.GetAll(sqlSelecionarTodos, ConverterEmRegistro);
        }
        public void inserir(T registro)
        {
            registro.id = Db.Insert(sqlInserir, ObtemParametrosRegistro(registro));
        }
        public void editar(int id, T registro)
        {
            registro.id = id;
            Db.Update(sqlEditar, ObtemParametrosRegistro(registro));
        }
        public void excluir(int id)
        {
            Db.Delete(sqlExcluir, AdicionarParametro("ID", id));
        }

        public abstract T ConverterEmRegistro(IDataReader reader);
        public abstract Dictionary<string, object> ObtemParametrosRegistro(T registro);
        protected static Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}