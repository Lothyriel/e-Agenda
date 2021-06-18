using Controle_de_Tarefas.Controladores;
using Controle_de_Tarefas.Dominio;
using System;
using System.Collections;

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
            T registro = registroValido();
            controlador.inserir(registro);
        }
        protected void editar()
        {
            var lista = controlador.Registros;
            if (!lista.mostrarLista())
                return;

            TipoMensagem.Requisicao.mostrarMensagem("Digite o ID do Registro para editar -- Ou digite S para Sair\n");
            String opcao = Console.ReadLine().ToUpperInvariant();

            while (opcao != "S")
            {
                if (!opcaoValida(opcao))
                    editar();
                int indice = Convert.ToInt32(opcao) - 1;
                controlador.editar(indice, registroValido());
                TipoMensagem.Sucesso.mostrarMensagem("Editado com sucesso\n");
                break;
            }
        }
        protected void excluir()
        {
            var lista = controlador.Registros;
            if (!lista.mostrarLista())
                return;

            TipoMensagem.Requisicao.mostrarMensagem("Digite o ID do Registro para excluir -- Ou digite S para Sair\n");

            String opcao = Console.ReadLine().ToUpperInvariant();

            while (opcao != "S")
            {
                if (!opcaoValida(opcao))
                    excluir();
                int indice = Convert.ToInt32(opcao) - 1;
                controlador.excluir(indice);
                TipoMensagem.Sucesso.mostrarMensagem("Excluído com sucesso\n");
                break;
            }
        }
        protected bool opcaoValida(string idSelecionado)
        {
            return int.TryParse(idSelecionado, out int id) && controlador.existsById(id);
        }
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
    public enum TipoMensagem
    {
        Sucesso, Erro, Aviso, Requisicao, Item
    }
}
