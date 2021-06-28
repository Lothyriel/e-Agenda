using Controle_de_Tarefas.Dominio;
using System.Collections.Generic;

namespace Controle_de_Tarefas.Controladores
{
    abstract public class Controlador<T> where T : Entidade
    {
        public List<T> Registros => obterRegistros();
        public abstract T getById(int id);
        public abstract void inserir(T registro);
        public abstract void editar(int id, T registro);
        public abstract void excluir(int id);
        public abstract List<T> obterRegistros();
    }
}