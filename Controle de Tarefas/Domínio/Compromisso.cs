using Controle_de_Tarefas.Dominio;
using System;

namespace Controle_de_Tarefas.Domínio
{
    class Compromisso : Entidade
    {
        public Compromisso(Contato contato, String assunto, String local, DateTime data_inicio, DateTime data_fim)
        {
            this.assunto = assunto;
            this.local = local;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
            this.contato = contato;

        }
        public String assunto { get; set; }
        public String local { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        private Contato contato { get; set; }
        public override string ToString()
        {
            return $"Assunto: {assunto} | Local: {local} Contato: {contato} | Data: {data_inicio.ToString("g")} | Fim: {data_fim.ToString("t")}";
        }
    }
}
