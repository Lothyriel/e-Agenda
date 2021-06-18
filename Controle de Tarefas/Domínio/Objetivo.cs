using System;

namespace Controle_de_Tarefas.Dominio
{
    public class Objetivo
    {
        public Objetivo(String descricao, int id)
        {
            this.descricao = descricao;
            this.id = id;
            finalizado = false;
        }

        public bool finalizado;
        public String descricao;
        public int id;

        public void concluir() { finalizado = true; }
        public override string ToString()
        {
            return $"Descrição {descricao} | : Status: {(finalizado ? "Completo" : "Incompleto")}";
        }
    }
}