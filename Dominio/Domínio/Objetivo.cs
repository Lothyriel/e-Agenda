using System;

namespace e_Agenda.Dominio
{
    public class Objetivo : Entidade
    {
        public Objetivo(String descricao, int id_tarefa)
        {
            this.descricao = descricao;
            this.id_tarefa = id_tarefa;
            finalizado = false;
        }
        public Objetivo(String descricao, int id_tarefa, bool finalizado)
        {
            this.descricao = descricao;
            this.finalizado = finalizado;
            this.id_tarefa = id_tarefa;
        }
        public bool finalizado { get; set; }
        public String descricao { get; set; }
        public int id_tarefa { get; set; }

        public void concluir() { finalizado = true; }
        public override string ToString()
        {
            return $"ID: {id} | Descrição { descricao} | : Status: { (finalizado ? "Completo" : "Incompleto")}";
        }
        public string ToString(String format)
        {
            return $"{ descricao} | : Status: { (finalizado ? "Completo" : "Incompleto")}";
        }
    }
}