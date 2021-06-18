using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using System;

namespace Controle_de_Tarefas.Telas
{
    public class TelaObjetivos : Tela<Objetivo>
    {
        private new ControladorObjetivos controlador;
        private Tarefa tarefa;

        public TelaObjetivos(Tarefa tarefa) : base(tarefa.ctrlObjetivos)
        {
            this.tarefa = tarefa;
            controlador = tarefa.ctrlObjetivos;
            menu();
        }
        public override void menu()
        {
            String opcao = "";
            while (opcao != "S")
            {
                mostrarTarefa();
                Console.WriteLine("\nEscolha uma opção: \n");
                Console.WriteLine("Digite 1 para cadastrar novos objetivos para esta tarefa");
                Console.WriteLine("Digite 2 para marcar objetivos como concluídos");
                Console.WriteLine("Digite 3 para editar esta tarefa");
                Console.WriteLine("Digite S para Voltar\n");
                TipoMensagem.Requisicao.mostrarMensagem("Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                switch (opcao)
                {
                    case "1": cadastrarObjetivos(); break;
                    case "2": concluirObjetivo(); break;
                    case "3": break;
                    case "S": break;
                    default: TipoMensagem.Erro.mostrarMensagem("\nSelecione uma opcão correta!"); break;
                }
            }
        }
        private void mostrarTarefa()
        {
            Console.Clear();
            TipoMensagem.Item.mostrarMensagem(tarefa + "\n");
        }
        private void cadastrarObjetivos()
        {
            controlador.inserir(registroValido());
            TipoMensagem.Sucesso.mostrarMensagem("\nObjetivo adicionado com sucesso");
        }
        private void concluirObjetivo()
        {
            var lista = controlador.objetivosIncompletos();
            mostrarTarefa();
            if (!lista.mostrarLista())
                return;
            String opcao = "";
            while (opcao != "S")
            {
                TipoMensagem.Requisicao.mostrarMensagem("\nDigite o ID do Objetivo para marcar como concluído -- Ou digite S para Sair\n");
                opcao = Console.ReadLine().ToUpperInvariant();
                if (!opcaoValida(opcao))
                    concluirObjetivo();
                int indice = Convert.ToInt32(opcao);
                var objetivo = controlador.objetivosIncompletos()[indice - 1];
                objetivo.concluir();
                TipoMensagem.Sucesso.mostrarMensagem("Objetivo marcado como concluído");
                tarefa.concluiTarefa();
                break;
            }
        }
        public override Objetivo registroValido()
        {
            String descricao;
            Console.Clear();
            while (true)
            {
                TipoMensagem.Requisicao.mostrarMensagem("Digite a descrição do objetivo\n");
                descricao = Console.ReadLine();
                if (descricao.Length > 0)
                    break;
                TipoMensagem.Erro.mostrarMensagem("\nDescrição não pode ser vazia");
            }
            return new Objetivo(descricao, tarefa.id++);
        }
    }
}