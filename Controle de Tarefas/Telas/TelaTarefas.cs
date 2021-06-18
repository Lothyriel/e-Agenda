using Controle_de_Tarefas.Dominio;
using Controle_de_Tarefas.Controladores;
using System;
using System.Collections.Generic;

namespace Controle_de_Tarefas.Telas
{
    public class TelaTarefas<T> : Tela
    {
        private readonly Controlador<Tarefa> controladorT = new Controlador<Tarefa>();
        private readonly Controlador<Contato> controlador = new Controlador<Contato>();
        public override void menu()
        {
            String opcao = "";
            while (opcao != "S")
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção: \n");
                Console.WriteLine("Digite 1 para visualizar tarefas não concluídas");
                Console.WriteLine("Digite 2 para visualizar tarefas concluídas");
                Console.WriteLine("Digite 3 para cadastrar novas tarefas");
                Console.WriteLine("Digite 4 para excluir tarefas\n");

                mostrarMensagem(TipoMensagem.Requisicao, "Opção:");
                opcao = Console.ReadLine().ToUpperInvariant();
                switch (opcao)
                {
                    case "1": menuTarefa(controlador.tarefasIncompletas()); break;
                    case "2": menuTarefa(controlador.tarefasCompletas()); break;
                    case "3": cadastrar(); break;
                    case "4": excluir(); break;
                    case "S": break;
                    default: mostrarMensagem(TipoMensagem.Erro, "\nSelecione uma opcão correta!"); break;
                }
            }
        }
        public abstract Tarefa registroValido()
        {
            String titulo;
            String prioridade;
            uint iPrioridade;
            Console.Clear();
            while (true)
            {
                mostrarMensagem(TipoMensagem.Requisicao, "Digite o título da Tarefa\n");
                titulo = Console.ReadLine();
                if (titulo.Length > 0)
                    break;
                mostrarMensagem(TipoMensagem.Erro, "Título não pode ser vazio");
            }
            while (true)
            {
                mostrarMensagem(TipoMensagem.Requisicao, "\nDigite a prioridade da Tarefa\n");
                prioridade = Console.ReadLine();
                if (uint.TryParse(prioridade, out iPrioridade) && iPrioridade <= 1000)
                    break;
                mostrarMensagem(TipoMensagem.Erro, "Prioridade precisa ser numérica 0-1000");
            }

            return new Tarefa(iPrioridade, titulo);
        }
        private void menuTarefa(List<Tarefa> lista)
        {
            Console.Clear();
            if (!mostrarLista(lista))
                return;
            String opcao = "";
            mostrarMensagem(TipoMensagem.Requisicao, "\nDigite o número da Tarefa para ver ações -- Ou digite S para Sair\n");
            opcao = Console.ReadLine().ToUpperInvariant();
            if (opcao == "S")
                return;
            if (!indiceValido(lista, opcao))
                menuTarefa(lista);
            Tarefa tarefa = lista[Convert.ToInt32(opcao) - 1];
            new TelaOpcoesTarefa(tarefa);
        }
        private void cadastrar()
        {
            T registro = registroValido();
            controlador.inserir(registro);
        }
        private void excluir()
        {
            var lista = controlador.Registros;
            if (!mostrarLista(lista))
                return;

            mostrarMensagem(TipoMensagem.Requisicao, "Digite o número do Registro para excluir -- Ou digite S para Sair\n");
            String opcao = Console.ReadLine().ToUpperInvariant();

            while (opcao != "S")
            {
                if (!indiceValido(lista, opcao))
                    excluir();
                int indice = Convert.ToInt32(opcao) - 1;
                controlador.excluir(indice);
                mostrarMensagem(TipoMensagem.Sucesso, "Excluído com sucesso\n");
                break;
            }
        }
    }
}