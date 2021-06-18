using System;
using System.Collections.Generic;
using System.Linq;

namespace Controle_de_Tarefas.Dominio
{
    public class Tarefa : Entidade
    {
        public Tarefa(uint prioridade, String titulo)
        {
            this.prioridade = prioridade;
            this.titulo = titulo;
            porcentagem_conclusao = 0;
            id_objetivos = 0;
            dt_criacao = DateTime.Now;
            objetivos = new List<Objetivo>();
        }

        public uint prioridade;
        public string titulo;
        private int id_objetivos;
        private List<Objetivo> objetivos;
        public int porcentagem_conclusao { get; private set; }
        public DateTime dt_criacao { get; private set; }
        public DateTime dt_conclusao { get; private set; }

        public List<Objetivo> objetivosIncompletos()
        {
            return objetivos.Except(objetivosCompletos()).ToList();
        }
        private List<Objetivo> objetivosCompletos()
        {
            return objetivos.FindAll(x => x.finalizado);
        }
        public void adicionarObjetivo(Objetivo objetivo)
        {
            objetivo.id = id_objetivos++;
            objetivos.Add(objetivo);
            atualizaConclusao();
        }
        public void atualizaConclusao()
        {
            var concluidos = objetivos.FindAll(x => x.finalizado);
            porcentagem_conclusao = concluidos.Count / objetivos.Count * 100;
        }
        public void concluiTarefa()
        {
            atualizaConclusao();
            if (porcentagem_conclusao == 100)
                dt_conclusao = DateTime.Now;
        }
        public String printObjetivos()
        {
            if (objetivos.Count == 0)
                return "Nenhum objetivo cadastrado";

            String strObjetivos = "";
            foreach (var objetivo in objetivos)
                strObjetivos += "- " + objetivo + "\n";
            return strObjetivos;
        }
        public override String ToString()
        {
            return $"Titulo: {titulo} | Prioridade: {prioridade} | Conclusão: {porcentagem_conclusao}% | Data Criação: {dt_criacao} " +
            $"{(dt_conclusao != DateTime.MinValue ? $" | Data Conclusão: {dt_conclusao}" : String.Empty)}\n{printObjetivos()}";
        }
    }
}
