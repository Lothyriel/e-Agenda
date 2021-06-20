using Controle_de_Tarefas.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Controle_de_Tarefas.Controladores
{
    public class ControladorTarefas : Controlador<Tarefa>
    {
        protected override string nometabela => "TBTarefas";
        public List<Tarefa> tarefasCompletas()
        {
            var tarefasIncompletas = Registros.Where(x => x.porcentagem_conclusao == 100);
            return tarefasIncompletas.OrderByDescending(x => x.dt_conclusao).ToList();
        }
        public List<Tarefa> tarefasIncompletas()
        {
            var tarefasIncompletas = Registros.Except(tarefasCompletas());
            return tarefasIncompletas.OrderByDescending(x => x.prioridade).ToList();
        }
    }
}