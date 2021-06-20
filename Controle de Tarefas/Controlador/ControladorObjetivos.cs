using Controle_de_Tarefas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controle_de_Tarefas.Controladores
{
    public class ControladorObjetivos : Controlador<Objetivo>
    {
        protected override string nometabela => "TBObjetivos";
        public override String ToString()
        {
            if (Registros.Count == 0)
                return "Nenhum objetivo cadastrado";

            String strObjetivos = "";
            foreach (var objetivo in Registros)
                strObjetivos += "- " + objetivo.ToString("sem ID") + "\n";
            return strObjetivos;
        }
        public List<Objetivo> objetivosIncompletos()
        {
            return Registros.Except(objetivosCompletos()).ToList();
        }
        private List<Objetivo> objetivosCompletos()
        {
            return Registros.FindAll(x => x.finalizado);
        }
    }
}