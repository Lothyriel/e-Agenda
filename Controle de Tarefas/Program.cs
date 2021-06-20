using Controle_de_Tarefas.Dominio;
using Controle_de_Tarefas.Telas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Controle_de_Tarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            var tip = tipos();
            var tipStr = tiposEmString(tip);

            tip.ForEach(x => Console.WriteLine(x));
            tipStr.ForEach(x => Console.WriteLine(x));

            Console.ReadKey();

            TelaPrincipal tp = new TelaPrincipal();
            while (true)
                tp.menu();
        }
        private static List<PropertyInfo> tipos()
        {
            return typeof(Tarefa).GetProperties().ToList();
        }
        private static List<String> tiposEmString(List<PropertyInfo> propriedades)
        {
            return propriedades.Select(x => x.Name.ToString().ToUpper()).ToList();
        }
    }
}
