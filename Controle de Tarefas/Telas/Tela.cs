using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Controle_de_Tarefas.Telas
{
    public abstract class Tela<T> where T : Entidade
    {
        protected Controlador<T> controlador;
        protected Tela(Controlador<T> controlador)
        {
            this.controlador = controlador;
        }
        public abstract void menu();
        public abstract T registroValido();

        protected void cadastrar()
        {
            controlador.inserir(registroValido());
            TipoMensagem.Sucesso.mostrarMensagem("\nRegistro adicionado com sucesso");
        }
        protected void editar()
        {
            string opcao = obterOpcao(controlador.Registros);
            if (opcao == "S") return;

            int id = Convert.ToInt32(opcao);
            controlador.editar(id, registroValido());
        }
        protected void excluir()
        {
            string opcao = obterOpcao(controlador.Registros);
            if (opcao == "S") return;

            int id = Convert.ToInt32(opcao);
            controlador.excluir(id);
        }
        protected bool opcaoValida(string opcao, List<T> lista)
        {
            return int.TryParse(opcao, out int id) && lista.Exists(x => x.id == id);
        }
        protected String obterOpcao(List<T> lista)
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
            TipoMensagem.Sucesso.mostrarMensagem("Operação realizada com sucesso");
            return opcao;
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
        public static List<String> concatenarLinhasSQL(this List<String> x, List<String> z)
        {
            List<String> saida = new List<String>();
            for (int i = 0; i < x.Count; i++)
                saida.Add($"{x[i]}={z[i]}");
            return saida;
        }
    }
}