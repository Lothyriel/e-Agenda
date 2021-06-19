using System;

namespace Controle_de_Tarefas.Dominio
{
    public class Objetivo : Entidade
    {
        public Objetivo(String descricao)
        {
            this.descricao = descricao;
            finalizado = false;
        }

        public bool finalizado;
        public String descricao;

        public void concluir() { finalizado = true; }
        public override string ToString()
        {
            return $"ID: {id} | Descrição { descricao} | : Status: { (finalizado ? "Completo" : "Incompleto")}";
        }
        public string ToString(String format)
        {
            return $"Descrição { descricao} | : Status: { (finalizado ? "Completo" : "Incompleto")}";
        }
    }
}