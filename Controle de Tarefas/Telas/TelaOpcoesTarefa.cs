using Controle_de_Tarefas.Dominio;
using System;

namespace Controle_de_Tarefas.Telas
{
    public class TelaOpcoesTarefa : Tela
    {
        private Tarefa tarefa;

        public TelaOpcoesTarefa(Tarefa tarefa)
        {
            this.tarefa = tarefa;
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
                mostrarMensagem(TipoMensagem.Requisicao, "Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                switch (opcao)
                {
                    case "1": cadastrarObjetivos(); break;
                    case "2": concluirObjetivo(); break;
                    case "3": editar(TelaPrincipal.tarefaValida()); break;
                    case "S": break;
                    default: mostrarMensagem(TipoMensagem.Erro, "\nSelecione uma opcão correta!"); break;
                }
            }
        }

        private void mostrarTarefa()
        {
            Console.Clear();
            mostrarMensagem(TipoMensagem.Item, tarefa + "\n");
        }
        private void cadastrarObjetivos()
        {
            tarefa.adicionarObjetivo(objetivoValido());
            mostrarMensagem(TipoMensagem.Sucesso, "\nObjetivo adicionado com sucesso");
        }
        private void concluirObjetivo()
        {
            mostrarTarefa();
            if (!mostrarLista(tarefa.objetivosIncompletos()))
                return;
            String opcao = "";
            while (opcao != "S")
            {
                mostrarMensagem(TipoMensagem.Requisicao, "\nDigite o número do Objetivo para marcar como concluído -- Ou digite S para Sair\n");
                opcao = Console.ReadLine().ToUpperInvariant();
                if (!indiceValido(tarefa.objetivosIncompletos(), opcao))
                    concluirObjetivo();
                int indice = Convert.ToInt32(opcao);
                var objetivo = tarefa.objetivosIncompletos()[indice - 1];
                objetivo.concluir();
                mostrarMensagem(TipoMensagem.Sucesso, "Objetivo marcado como concluído");
                tarefa.concluiTarefa();
                break;
            }
        }
        public Objetivo objetivoValido()
        {
            String descricao;
            Console.Clear();
            while (true)
            {
                mostrarMensagem(TipoMensagem.Requisicao, "Digite a descrição do objetivo\n");
                descricao = Console.ReadLine();
                if (descricao.Length > 0)
                    break;
                mostrarMensagem(TipoMensagem.Erro, "\nDescrição não pode ser vazia");
            }
            return new Objetivo(descricao, tarefa.id++);
        }
        private void editar(Tarefa tarefaNew)
        {
            tarefa.titulo = tarefaNew.titulo;
            tarefa.prioridade = tarefaNew.prioridade;
            mostrarMensagem(TipoMensagem.Sucesso, "\nEditado com sucesso");
        }
    }
}