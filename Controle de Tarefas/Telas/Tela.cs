using System;
using System.Collections;

namespace Controle_de_Tarefas.Telas
{
    public abstract class Tela
    {
        public abstract void menu();
        protected static bool indiceValido(IList lista, string opcao)
        {
            bool valido = int.TryParse(opcao, out int iOpcao) && iOpcao > 0 && iOpcao <= lista.Count;
            if (!valido)
                mostrarMensagem(TipoMensagem.Erro, "Digite uma opção válida");
            return valido;
        }
        protected static bool mostrarLista(IList lista)
        {
            if (lista.Count == 0)
            {
                mostrarMensagem(TipoMensagem.Erro, "Nenhum item aqui!");
                return false;
            }
            else
            {
                for (int i = 0; i < lista.Count; i++)
                    Console.WriteLine($"[{i + 1}] {lista[i]}");
                return true;
            }
        }
        protected static void mostrarMensagem(TipoMensagem tipo, String mensagem)
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