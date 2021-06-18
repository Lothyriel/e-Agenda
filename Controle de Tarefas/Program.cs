namespace Controle_de_Tarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            Controlador controlador = new Controlador();
            while (true)
                new TelaTarefas(controlador).menuPrincipal();
        }
    }
}
