using Controle_de_Tarefas.Domínio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_de_Tarefas.Controladores
{
    class ControladorCompromissos : Controlador<Compromisso>
    {
        protected override string nomeTabela => throw new NotImplementedException();

        public List<Compromisso> compromissosFuturos()
        {
            throw new NotImplementedException();
        }

        public List<Compromisso> compromissosPassados()
        {
            throw new NotImplementedException();
        }
    }
}
