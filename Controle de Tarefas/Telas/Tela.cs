using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Controle_de_Tarefas.Telas
{
    public abstract class Tela<T> : IMenu where T : Entidade
    {
        protected Controlador<T> controlador;

        protected Tela(Controlador<T> controlador)
        {
            this.controlador = controlador;
        }

        public abstract void menu();
        public abstract T registroValido();
        public String obterOpcao()
        {
            return obterOpcao(controlador.Registros);
        }
        public String obterOpcao(List<T> lista)
        {
            Console.Clear();
            if (!lista.mostrarLista())
                return "S";

            TipoMensagem.Requisicao.mostrarMensagem("\nDigite o ID do registro para alterar -- Ou digite S para Sair\n");
            String opcao = Console.ReadLine().ToUpperInvariant();

            if (opcao == "S") return opcao;

            if (!opcaoValida(opcao, lista))
            {
                TipoMensagem.Erro.mostrarMensagem("Selecione uma opcão válida");
                return obterOpcao(lista);
            }
            TipoMensagem.Sucesso.mostrarMensagem("Registro selecionado com sucesso");
            return opcao;
        }
        protected bool opcaoValida(string opcao, List<T> lista)
        {
            return int.TryParse(opcao, out int id) && lista.Exists(x => x.id == id);
        }
        protected void visualizar()
        {
            visualizar(controlador.Registros);
        }
        protected virtual void visualizar(List<T> registros)
        {
            Console.Clear();
            registros.mostrarLista();
            TipoMensagem.Requisicao.mostrarMensagem("\nAperte uma tecla para voltar");
            Console.ReadKey();
        }
        protected virtual void cadastrar()
        {
            controlador.inserir(registroValido());
            TipoMensagem.Sucesso.mostrarMensagem("\nRegistro inserido com sucesso");
        }
        protected virtual void editar()
        {
            string opcao = obterOpcao();
            if (opcao == "S") return;

            int id = Convert.ToInt32(opcao);
            controlador.editar(id, registroValido());
        }
        protected void excluir()
        {
            string opcao = obterOpcao();
            if (opcao == "S") return;

            int id = Convert.ToInt32(opcao);
            controlador.excluir(id);
        }
    }
    public enum TipoMensagem
    {
        Sucesso, Erro, Aviso, Requisicao, Item
    }
    public static class Extensions
    {
        public static bool mostrarLista(this IList lista)
        {
            if (lista.Count == 0)
            {
                TipoMensagem.Erro.mostrarMensagem("Nenhum item aqui!");
                return false;
            }
            else
            {
                foreach (var item in lista)
                    Console.WriteLine(item);
                return true;
            }
        }
        public static void mostrarMensagem(this TipoMensagem tipo, String mensagem)
        {
            switch (tipo)
            {
                case TipoMensagem.Erro: Console.ForegroundColor = ConsoleColor.Red; ; break;
                case TipoMensagem.Sucesso: Console.ForegroundColor = ConsoleColor.Green; ; break;
                case TipoMensagem.Aviso: Console.ForegroundColor = ConsoleColor.Yellow; ; break;
                case TipoMensagem.Requisicao: Console.ForegroundColor = ConsoleColor.Blue; ; break;
                case TipoMensagem.Item: Console.ForegroundColor = ConsoleColor.Magenta; ; break;
            }

            Console.Write(mensagem);
            Console.ResetColor();
            if (tipo != TipoMensagem.Requisicao && tipo != TipoMensagem.Item) Console.ReadKey();
        }
    }
}