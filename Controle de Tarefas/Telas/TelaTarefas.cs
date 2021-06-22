using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using System;
using System.Collections.Generic;

namespace Controle_de_Tarefas.Telas
{
    public class TelaTarefas : Tela<Tarefa>, ITela
    {
        private new ControladorTarefas controlador;
        public TelaTarefas() : base(new ControladorTarefas())
        {
        }
        public void menu()
        {
            String opcao = "";
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção: \n");
                Console.WriteLine("Digite 1 para visualizar tarefas pendentes");
                Console.WriteLine("Digite 2 para visualizar tarefas concluídas");
                Console.WriteLine("Digite 3 para cadastrar novas tarefas");
                Console.WriteLine("Digite S para Voltar\n");
                TipoMensagem.Requisicao.mostrarMensagem("Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                switch (opcao)
                {
                    case "1": menuTarefas(controlador.tarefasIncompletas()); break;
                    case "2": menuTarefas(controlador.tarefasCompletas()); break;
                    case "3": cadastrar(); break;
                    case "S": break;
                    default: TipoMensagem.Erro.mostrarMensagem("\nSelecione uma opcão correta!"); break;
                }
            }
        }
        public override Tarefa registroValido()
        {
            String titulo;
            String prioridade;
            int iPrioridade;
            Console.Clear();
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite o título da Tarefa\n");
                titulo = Console.ReadLine();
                if (titulo.Length > 0)
                    break;
                TipoMensagem.Erro.mostrarMensagem("Título não pode ser vazio");
            }
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("\nDigite a prioridade da Tarefa\n");
                prioridade = Console.ReadLine();
                if (int.TryParse(prioridade, out iPrioridade) && iPrioridade <= 1000)
                    break;
                TipoMensagem.Erro.mostrarMensagem("Prioridade precisa ser numérica 0-1000");
            }

            return new Tarefa(iPrioridade, titulo);
        }
        private void menuTarefas(List<Tarefa> lista)
        {
            Console.Clear();
            string opcao = obterOpcao(lista);

            if (opcao == "S") return;

            int id = Convert.ToInt32(opcao);
            Tarefa tarefa = controlador.getById(id);
            new TelaObjetivos(tarefa);
        }
    }
}