using Controle_de_Tarefas.Dominio;
using System.Collections.Generic;

namespace Controle_de_Tarefas.Controladores
{
    public class Controlador<T> where T : Entidade
    {
        private int id;
        private readonly List<T> registros = new List<T>();
        public List<T> Registros => registros;

        public void inserir(T registro)
        {
            registro.id = ++id;
            registros.Add(registro);
        }
        public void excluir(int indice)
        {
            registros.RemoveAt(indice);
        }
        public T getById(int id)
        {
            return registros.Find(x => x.id == id);
        }
    }
}