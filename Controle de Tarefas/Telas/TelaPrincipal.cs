using Controle_de_Tarefas.Controladores;
using System;

namespace Controle_de_Tarefas.Telas
{
    public class TelaPrincipal
    {
        private readonly ControladorTarefas controladorT = new ControladorTarefas();
        private readonly ControladorContatos controladorC = new ControladorContatos();
        public void menu()
        {
            String opcao = "";
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção: \n");
                Console.WriteLine("Digite 1 para menu de Tarefas");
                Console.WriteLine("Digite 2 para menu de Contatos\n");

                TipoMensagem.Requisicao.mostrarMensagem("Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                obterTela(opcao).menu();
            }
        }
        private dynamic obterTela(string opcao)
        {
            switch (opcao)
            {
                case "1": return new TelaTarefas(controladorT);
                case "2": return new TelaContatos(controladorC);
                default: TipoMensagem.Erro.mostrarMensagem("\nSelecione uma opcão correta!"); return this;
            }
        }
    }
}