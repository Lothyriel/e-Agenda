using System;

namespace e_Agenda.Telas
{
    public class TelaPrincipal : IMenu
    {
        public void menu()
        {
            String opcao = "";
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção: \n");
                Console.WriteLine("Digite 1 para menu de Tarefas");
                Console.WriteLine("Digite 2 para menu de Contatos");
                Console.WriteLine("Digite 3 para menu de Compromissos\n");

                TipoMensagem.Requisicao.mostrarMensagem("Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                obterTela(opcao).menu();
            }
        }
        private IMenu obterTela(String opcao)
        {
            switch (opcao)
            {
                case "1": return new TelaTarefas();
                case "2": return new TelaContatos();
                case "3": return new TelaCompromissos();
                default: TipoMensagem.Erro.mostrarMensagem("\nSelecione uma opcão correta!"); return this;
            }
        }
    }
}