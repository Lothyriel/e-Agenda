using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using System;

namespace Controle_de_Tarefas.Telas
{
    public class TelaContato : Tela
    {
        private Controlador<Contato> controlador;

        public TelaContato(Controlador<Contato> controlador)
        {
            this.controlador = controlador;
            menu();
        }
        public override void menu()
        {
            String opcao = "";
            while (opcao != "S")
            {
                Console.WriteLine("\nEscolha uma opção: \n");
                Console.WriteLine("Digite 1 para visualizar os registros");
                Console.WriteLine("Digite 2 para cadastrar um novo registro");
                Console.WriteLine("Digite 4 para editar um registro");
                Console.WriteLine("Digite 5 para excluir um registro");
                Console.WriteLine("Digite S para Voltar\n");
                mostrarMensagem(TipoMensagem.Requisicao, "Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                switch (opcao)
                {
                    case "1": mostrarLista(controlador.Registros); break;
                    case "2": cadastrarbreak;
                    case "3": break;
                    case "4": break;
                    case "S": break;
                    default: mostrarMensagem(TipoMensagem.Erro, "\nSelecione uma opcão correta!"); break;
                }
            }
        }
        public Contato contatoValido()
        {
            String nome;
            String email;
            String telefone;
            String empresa;
            String cargo;
            Console.Clear();
            while (true)
            {
                mostrarMensagem(TipoMensagem.Requisicao, "Digite o nome do contato\n");
                nome = Console.ReadLine();
                if (nome.Length > 0)
                    break;
                mostrarMensagem(TipoMensagem.Erro, "\nNome não pode ser vazio");
            }
            while (true)
            {
                mostrarMensagem(TipoMensagem.Requisicao, "Digite o email do contato\n");
                email = Console.ReadLine();
                if (email.Contains("@") && email.Contains(".com"))
                    break;
                mostrarMensagem(TipoMensagem.Erro, "\nEmail deve conter @ e .com");
            }
            while (true)
            {
                mostrarMensagem(TipoMensagem.Requisicao, "Digite o telefone do contato\n");
                telefone = Console.ReadLine();
                if (telefone.Length == 9)
                    break;
                mostrarMensagem(TipoMensagem.Erro, "\nDigite um telefone válido somente números");
            }
            while (true)
            {
                mostrarMensagem(TipoMensagem.Requisicao, "Digite a empresa do contato\n");
                empresa = Console.ReadLine();
                if (empresa.Length > 0)
                    break;
                mostrarMensagem(TipoMensagem.Erro, "\nEmpresa não pode ser vazia");
            }
            while (true)
            {
                mostrarMensagem(TipoMensagem.Requisicao, "Digite o cargo do contato\n");
                cargo = Console.ReadLine();
                if (cargo.Length > 0)
                    break;
                mostrarMensagem(TipoMensagem.Erro, "\nCargo não pode ser vazio");
            }
            return new Contato(nome, email, telefone, empresa, cargo);
        }
    }
}