using System;

namespace Controle_de_Tarefas.Dominio
{
    public class Objetivo
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
            return $"{descricao} : Status: {(finalizado ? "Completo" : "Incompleto")}";
        }
    }
}