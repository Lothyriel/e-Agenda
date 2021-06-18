using Controle_de_Tarefas.Telas;

namespace Controle_de_Tarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal tt = new TelaPrincipal();
            while (true)
                tt.menu();
        }
    }
}
