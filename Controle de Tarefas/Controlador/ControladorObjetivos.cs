using Controle_de_Tarefas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controle_de_Tarefas.Controladores
{
    public class ControladorObjetivos : Controlador<Objetivo>
    {
        public String printObjetivos()
        {
            if (Registros.Count == 0)
                return "Nenhum objetivo cadastrado";

            String strObjetivos = "";
            foreach (var objetivo in Registros)
                strObjetivos += "- " + objetivo + "\n";
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