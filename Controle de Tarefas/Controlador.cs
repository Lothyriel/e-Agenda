using Controle_de_Tarefas.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Controle_de_Tarefas
{
    public class Controlador
    {
        private int id;
        private readonly List<Tarefa> tarefas = new List<Tarefa>();
        public void inserir(Tarefa tarefa)
        {
            tarefa.id = id++;
            tarefas.Add(tarefa);
        }
        public void editar(int id, Tarefa tarefa)
        {
            int indice = tarefas.IndexOf(getById(id));
            tarefas[indice] = tarefa;
        }
        public void excluir(int id)
        {
            tarefas.Remove(getById(id));
        }
        public List<Tarefa> tarefasCompletas()
        {
            var tarefasIncompletas = tarefas.Where(x => x.porcentagem_conclusao == 100);
            return tarefasIncompletas.OrderBy(x => x.prioridade).ToList();
        }
        public List<Tarefa> tarefasIncompletas()
        {
            return tarefas.Except(tarefasCompletas()).OrderBy(x => x.prioridade).ToList();
        }
        private Tarefa getById(int id)
        {
            return tarefas.Find(x => x.id == id);
        }
    }
}