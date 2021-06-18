using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using System;

namespace Controle_de_Tarefas.Telas
{
    public class TelaContatos : Tela<Contato>
    {
        public TelaContatos(Controlador<Contato> controlador) : base(controlador)
        {
            this.controlador = controlador;
            menu();
        }

        public override void menu()
        {
            throw new NotImplementedException();
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