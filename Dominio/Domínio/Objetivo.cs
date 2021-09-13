using System;

namespace e_Agenda.Dominio
{
    public class Objetivo : Entidade
    {
        public Objetivo(String descricao, int id_tarefa, bool finalizado = false)
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
            return descricao;
        }
        public string ToString(String format)
        {
            if (format == "sem ID")
                return $"{ descricao} | : Status: { (finalizado ? "Completo" : "Incompleto")}";
            if (format == "com ID")
                return $"ID: {id} | Descrição { descricao} | : Status: { (finalizado ? "Completo" : "Incompleto")}";
            return ToString();
        }

        public override string validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(descricao))
                resultadoValidacao = "O campo Descrição é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}