using Controle_de_Tarefas.Dominio;
using System;
using System.Collections.Generic;

namespace Controle_de_Tarefas
{
    public class TelaTarefas
    {
        private Controlador controlador;
        public TelaTarefas(Controlador controlador)
        {
            this.controlador = controlador;
        }

        public void menuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção: \n");
            Console.WriteLine("Digite 1 para o menu de Visualização");
            Console.WriteLine("Digite 2 para o menu de Cadastro\n");
            Console.Write("Opção:");
            switch (Console.ReadLine())
            {
                case "1": menuVisualizar(); break;
                case "2": menuCadastro(); break;
                default: mostrarMensagem(TipoMensagem.Erro, "Selecione uma opcão correta!"); break;
            }
        }
        private void menuVisualizar()
        {
            String opcao = String.Empty;
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção: \n");
                Console.WriteLine("Digite 1 para visualizar tarefas não concluídas");
                Console.WriteLine("Digite 2 para visualizar tarefas concluídas");
                Console.WriteLine("Digite 3 para visualizar tarefas concluídas");
                Console.WriteLine("Digite S para Voltar\n");
                Console.Write("Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                switch (opcao)
                {
                    case "1": cadastrarObjetivos(); break;
                    case "2": mostrarLista(controlador.tarefasCompletas()); break;
                    case "S": break;
                    default: mostrarMensagem(TipoMensagem.Erro, "Selecione uma opcão correta!"); break;
                }
            }
        }
        private void menuCadastro()
        {
            String opcao = String.Empty;
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção: \n");
                Console.WriteLine("Digite 1 para cadastrar uma nova tarefa");
                Console.WriteLine("Digite 2 para editar uma tarefa");
                Console.WriteLine("Digite 3 excluir uma tarefa");
                Console.WriteLine("Digite S para Voltar\n");
                Console.Write("Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                switch (opcao)
                {
                    case "1": Inserir(); break;
                    case "2": Editar(); break;
                    case "3": Excluir(); break;
                    case "S": break;
                    default: mostrarMensagem(TipoMensagem.Erro, "Selecione uma opcão correta!"); break;
                }
            }
        }
        private void Inserir()
        {
            controlador.inserir(new Tarefa(10, "sexo"));
        }
        private void Editar()
        {
            controlador.editar(1, new Tarefa(20, "muito sexo"));
        }
        private void Excluir()
        {
            controlador.excluir(1);
        }
        private void cadastrarObjetivos()
        {
            if (!mostrarLista(controlador.tarefasIncompletas()))
                return;
            mostrarMensagem(TipoMensagem.Aviso, "Digite 1 se deseja inserir objetivos em alguma Tarefa");
            String opcao = Console.ReadLine().ToUpperInvariant();
            while (opcao != "S")
                mostrarMensagem(TipoMensagem.Aviso, "Escolha uma Tarefa para atribuir objetivos");

        }
        private bool mostrarLista(List<Tarefa> lista)
        {
            Console.WriteLine();
            if (lista.Count == 0)
            {
                mostrarMensagem(TipoMensagem.Erro, "Nenhuma tarefa aqui!");
                return false;
            }
            else
            {
                lista.ForEach(x => Console.WriteLine(x));
                Console.ReadKey();
                return true;
            }
        }
        private void mostrarMensagem(TipoMensagem tipo, String mensagem)
        {
            if (tipo is TipoMensagem.Erro)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (tipo is TipoMensagem.Sucesso)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (tipo is TipoMensagem.Aviso)
                Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadKey();
        }
    }
    public enum TipoMensagem
    {
        Sucesso, Erro, Aviso
    }
}