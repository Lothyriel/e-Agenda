using Controle_de_Tarefas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controle_de_Tarefas.Controladores
{
    public class ControladorContatos : Controlador<Contato>
    {
        protected override string nomeTabela => "TBContatos";
        public List<Contato> ordenadosPorCargo()
        {
            return Registros.OrderBy(x => x.cargo).ToList();
        }
    }
}