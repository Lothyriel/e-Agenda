using e_Agenda.Controladores;
using e_Agenda.Dominio;
using System;
using System.Collections.Generic;

namespace e_Agenda.Telas
{
    public class TelaTarefas : Tela<Tarefa>
    {
        private new ControladorTarefas controlador = new ControladorTarefas();
        public TelaTarefas() : base(new ControladorTarefas())
        {
        }
        public override void menu()
        {
            String opcao = "";
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção: \n");
                Console.WriteLine("Digite 1 para visualizar tarefas pendentes");
                Console.WriteLine("Digite 2 para visualizar tarefas concluídas");
                Console.WriteLine("Digite 3 para cadastrar novas tarefas\n");
                Console.WriteLine("Digite S para Voltar\n");
                TipoMensagem.Requisicao.mostrarMensagem("Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                switch (opcao)
                {
                    case "1": visualizar(controlador.tarefasIncompletas()); break;
                    case "2": visualizar(controlador.tarefasCompletas()); break;
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
        protected override void visualizar(List<Tarefa> registros)
        {
            Console.Clear();
            string opcao = obterOpcao(registros);

            if (opcao == "S") return;

            int id = Convert.ToInt32(opcao);
            Tarefa tarefa = controlador.getById(id);
            new TelaObjetivos(tarefa);
        }
    }
}