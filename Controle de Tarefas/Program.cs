using Controle_de_Tarefas.Domínio;
using Controle_de_Tarefas.Telas;
using System;
using System.Linq;

namespace Controle_de_Tarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            var sexo = typeof(Compromisso).GetProperties().ToList();

            sexo.ToList().ForEach(x => Console.WriteLine(x));

            Console.ReadKey();

            TelaPrincipal tp = new TelaPrincipal();
            while (true)
                tp.menu();
        }
    }
}
