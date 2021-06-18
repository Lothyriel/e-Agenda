using System;
using System.Collections.Generic;

namespace Controle_de_Tarefas.Dominio
{
    public class Tarefa
    {
        public Tarefa(int prioridade, String titulo)
        {
            this.prioridade = prioridade;
            this.titulo = titulo;
            porcentagem_conclusao = 0;
            dt_criacao = DateTime.Now;
            objetivos = new List<Objetivo>();
        }

        public int prioridade;
        public string titulo;
        public int id { get; internal set; }
        public int porcentagem_conclusao { get; private set; }
        public DateTime dt_criacao { get; private set; }
        public DateTime dt_conclusao { get; private set; }
        public List<Objetivo> objetivos { get; private set; }

        public void adicionarObjetivo(Objetivo objetivo)
        {
            objetivos.Add(objetivo);
            porcentagem_conclusao = verificaConclusao();
        }
        public int verificaConclusao()
        {
            var concluidos = objetivos.FindAll(x => x.finalizado);
            return concluidos.Count / objetivos.Count * 100;
        }
        public void concluiTarefa()
        {
            dt_conclusao = DateTime.Now;
        }
        public override String ToString()
        {
            return $"Titulo: {titulo} | Prioridade: {prioridade} | Conclusão: {porcentagem_conclusao}% | Data Criação: {dt_criacao} " +
                $"{(dt_conclusao != DateTime.MinValue ? $" | Data Conclusão: {dt_conclusao}" : String.Empty)}\n" +
                printObjetivos();
        }
        public String printObjetivos()
        {
            String sexo = "";
            foreach (var item in objetivos)
                sexo += "- " + item;
            return sexo;
        }
    }
}
