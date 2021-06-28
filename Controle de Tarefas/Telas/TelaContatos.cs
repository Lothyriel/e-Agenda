using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using System;
using System.Linq;

namespace Controle_de_Tarefas.Telas
{
    public class TelaContatos : Tela<Contato>, IMenu
    {
        private new ControladorContatos controlador = new ControladorContatos();
        public TelaContatos() : base(new ControladorContatos()) { }

        public override void menu()
        {
            String opcao = "";
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção: \n");
                Console.WriteLine("Digite 1 para visualizar contatos cadastrados");
                Console.WriteLine("Digite 2 para cadastrar um novo contato");
                Console.WriteLine("Digite 3 para editar um contato");
                Console.WriteLine("Digite 4 para excluir um contato");
                Console.WriteLine("Digite S para Voltar\n");
                TipoMensagem.Requisicao.mostrarMensagem("Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                switch (opcao)
                {
                    case "1": visualizar(controlador.ordenadosPorCargo()); break;
                    case "2": cadastrar(); break;
                    case "3": editar(); break;
                    case "4": excluir(); break;
                    case "S": break;
                    default: TipoMensagem.Erro.mostrarMensagem("\nSelecione uma opcão correta!"); break;
                }
            }
        }
        public override Contato registroValido()
        {
            String nome, email, telefone, empresa, cargo;
            Console.Clear();
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite o nome do contato\n");
                nome = Console.ReadLine();
                if (nome.Length > 0)
                    break;
                TipoMensagem.Erro.mostrarMensagem("\nNome não pode ser vazio");
            }
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite o email do contato\n");
                email = Console.ReadLine();
                if (email.Contains("@") && email.Contains(".com"))
                    break;
                TipoMensagem.Erro.mostrarMensagem("\nEmail deve conter @ e .com");
            }
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite o telefone do contato\n");
                telefone = Console.ReadLine();
                if (telefone.Length == 9)
                    break;
                TipoMensagem.Erro.mostrarMensagem("\nDigite um telefone válido somente números");
            }
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite a empresa do contato\n");
                empresa = Console.ReadLine();
                if (empresa.Length > 0)
                    break;
                TipoMensagem.Erro.mostrarMensagem("\nEmpresa não pode ser vazia");
            }
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite o cargo do contato\n");
                cargo = Console.ReadLine();
                if (cargo.Length > 0)
                    break;
                TipoMensagem.Erro.mostrarMensagem("\nCargo não pode ser vazio");
            }
            return new Contato(nome, email, telefone, empresa, cargo);
        }
    }
}