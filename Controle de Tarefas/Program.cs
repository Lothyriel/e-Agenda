using Controle_de_Tarefas.Domínio;
using Controle_de_Tarefas.Dominio;
using Controle_de_Tarefas.Telas;
using System;
using System.Linq;

namespace Controle_de_Tarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal tp = new TelaPrincipal();
            while (true)
                tp.menu();
        }
    }
}
