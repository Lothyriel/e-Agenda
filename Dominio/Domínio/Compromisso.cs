using System;

namespace e_Agenda.Dominio
{
    public class Compromisso : Entidade
    {
        public Compromisso(String assunto, String local, DateTime data_inicio, DateTime data_fim, Contato contato = null)
        {
            this.assunto = assunto;
            this.local = local;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
            this.contato = contato;
        }
        public Contato contato;
        public String assunto { get; set; }
        public String local { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public override string ToString()
        {
            return $"Assunto: {assunto} | Local: {local} | Data: {data_inicio:g} | Fim: {data_fim:t} {(contato != null ? $"| Contato: {contato.nome}" : " ")}";
        }

        public override string validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(assunto))
                resultadoValidacao = "O campo Assunto é obrigatório";

            if (string.IsNullOrEmpty(local))
                resultadoValidacao = "\nO campo Local é obrigatório";

            if (data_inicio == DateTime.MinValue)
                resultadoValidacao += "\nO campo Data é obrigatório";

            if (data_inicio == data_inicio.Date)
                resultadoValidacao += "\nO campo Hora início é obrigatório";

            if (data_inicio == DateTime.MinValue)
                resultadoValidacao += "\nO campo Hora fim é obrigatório";

            if (data_fim <= data_inicio)
                resultadoValidacao += "\nO campo Data fim deve ser maior que Data Início";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
