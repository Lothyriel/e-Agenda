using e_Agenda.Telas;

namespace e_Agenda
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
