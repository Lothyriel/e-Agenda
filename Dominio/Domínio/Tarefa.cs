using System;
using System.Collections.Generic;

namespace e_Agenda.Dominio
{
    public class Tarefa : Entidade
    {
        public Tarefa(int prioridade, string titulo)
        {
            this.prioridade = prioridade;
            this.titulo = titulo;
            porcentagem_conclusao = 0;
            dt_criacao = DateTime.Now;
            resetaDt_Conclusao();
            objetivos = new List<Objetivo>();
        }
        public int porcentagem_conclusao { get; set; }
        public DateTime dt_criacao { get; set; }
        public DateTime dt_conclusao { get; set; }
        public string titulo { get; set; }
        public int prioridade { get; set; }
        public List<Objetivo> objetivos { get; set; }

        public void addObjetivo(Objetivo objetivo)
        {
            objetivos.Add(objetivo);
            resetaDt_Conclusao();
            calculaConclusao();
        }
        public void atualizaConclusao()
        {
            calculaConclusao();
            if (porcentagem_conclusao == 100)
                dt_conclusao = DateTime.Now;
        }
        public void editar(Tarefa nova)
        {
            titulo = nova.titulo;
            prioridade = nova.prioridade;
        }
        private void resetaDt_Conclusao()
        {
            dt_conclusao = new DateTime(1753, 1, 1);
        }
        private void calculaConclusao()
        {
            double total = objetivos.Count;
            double concluidos = objetivos.FindAll(x => x.finalizado).Count;
            double resultado = concluidos / total * 100;
            porcentagem_conclusao = Double.IsNaN(resultado) ? 0 : (int)resultado;
        }
        public String mostrarObjetivos()
        {
            if (objetivos.Count == 0)
                return "Nenhum objetivo cadastrado\n";

            String strObjetivos = "";
            objetivos.ForEach(x => strObjetivos += "- " + x.ToString("sem ID") + "\n");
            return strObjetivos;
        }
        public override String ToString()
        {
            return $"ID: {id} | Titulo: {titulo} | Prioridade: {prioridade} | Conclusão: {porcentagem_conclusao}% | Data Criação: {dt_criacao} " +
            $"{(dt_conclusao != new DateTime(1753, 1, 1) ? $" | Data Conclusão: {dt_conclusao}" : "")}\n{mostrarObjetivos()}";
        }
        public override string validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(titulo))
                resultadoValidacao = "O campo Título é obrigatório";

            if (prioridade == 0)
                resultadoValidacao = "\nO campo Prioridade é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
