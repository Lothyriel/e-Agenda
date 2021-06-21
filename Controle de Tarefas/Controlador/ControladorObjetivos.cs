using Controle_de_Tarefas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controle_de_Tarefas.Controladores
{
    public class ControladorObjetivos : Controlador<Objetivo>
    {
        protected override string nomeTabela => "TBObjetivos";
        public String ToString(int id_tarefa)
        {
            var objetivos = objetivosTarefa(id_tarefa);
            if (objetivos.Count == 0)
                return "Nenhum objetivo cadastrado";

            String strObjetivos = "";
            foreach (var objetivo in objetivos)
                strObjetivos += "- " + objetivo.ToString("sem ID") + "\n";
            return strObjetivos;
        }

        public List<Objetivo> objetivosTarefa(int id_tarefa)
        {
            return Registros.Where(x => x.id_tarefa == id_tarefa).ToList();
        }

        public List<Objetivo> objetivosIncompletos(int id_tarefa)
        {
            return objetivosTarefa(id_tarefa).FindAll(x => !x.finalizado);
        }
        public List<Objetivo> objetivosCompletos(int id_tarefa)
        {
            return objetivosTarefa(id_tarefa).FindAll(x => x.finalizado);
        }
    }
}