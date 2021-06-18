using Controle_de_Tarefas.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Controle_de_Tarefas.Controladores
{
    public class Controlador
    {
        private int id;
        private readonly List<Tarefa> tarefas = new List<Tarefa>();
        public List<Tarefa> Tarefas => tarefas;

        public void inserir(Tarefa tarefa)
        {
            tarefa.id = ++id;
            tarefas.Add(tarefa);
        }
        public void editar(int id, Tarefa tarefaNew)
        {
            Tarefa tarefaOld = getById(id);
            tarefaOld.titulo = tarefaNew.titulo;
            tarefaOld.prioridade = tarefaNew.prioridade;
        }
        public void excluir(int indice)
        {
            tarefas.RemoveAt(indice);
        }
        public List<Tarefa> tarefasCompletas()
        {
            var tarefasIncompletas = tarefas.Where(x => x.porcentagem_conclusao == 100);
            return tarefasIncompletas.OrderByDescending(x => x.dt_conclusao).ToList();
        }
        public List<Tarefa> tarefasIncompletas()
        {
            var tarefasIncompletas = tarefas.Except(tarefasCompletas());
            return tarefasIncompletas.OrderByDescending(x => x.prioridade).ToList();
        }
        public Tarefa getById(int id)
        {
            return tarefas.Find(x => x.id == id);
        }
    }
}