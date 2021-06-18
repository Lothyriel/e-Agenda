using Controle_de_Tarefas.Telas;

namespace Controle_de_Tarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaTarefas tt = new TelaTarefas();
            while (true)
                tt.menu();
        }
    }
}
