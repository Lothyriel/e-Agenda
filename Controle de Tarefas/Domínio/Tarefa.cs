using Controle_de_Tarefas.Controladores;
using System;

namespace Controle_de_Tarefas.Dominio
{
    public class Tarefa : Entidade
    {
        public readonly ControladorObjetivos ctrlObjetivos = new ControladorObjetivos();

        public Tarefa(int prioridade, string titulo)
        {
            this.prioridade = prioridade;
            this.titulo = titulo;
            porcentagem_conclusao = 0;
            dt_criacao = DateTime.Now;
            resetaDt_Conclusao();
        }
        public Tarefa(int porcentagem_conclusao, DateTime dt_criacao, int prioridade, String titulo)
        {
            this.prioridade = prioridade;
            this.titulo = titulo;
            this.porcentagem_conclusao = porcentagem_conclusao;
            this.dt_criacao = dt_criacao;
        }
        public int porcentagem_conclusao { get; private set; }
        public DateTime dt_criacao { get; private set; }
        public DateTime dt_conclusao { get; set; }
        public string titulo { get; set; }
        public int prioridade { get; set; }

        public void addObjetivo() { resetaDt_Conclusao(); atualizaConclusao(); }
        public void concluiTarefa()
        {
            atualizaConclusao();
            if (porcentagem_conclusao == 100)
                dt_conclusao = DateTime.Now;
        }
        public void editar(Tarefa nova)
        {
            titulo = nova.titulo;
            prioridade = nova.prioridade;
            new ControladorTarefas().editar(id, this);
        }
        private void resetaDt_Conclusao()
        {
            dt_conclusao = new DateTime(1900, 1, 1);
        }
        private void atualizaConclusao()
        {
            double total = ctrlObjetivos.objetivosTarefa(id).Count;
            double concluidos = ctrlObjetivos.objetivosCompletos(id).Count;
            double resultado = concluidos / total * 100;
            porcentagem_conclusao = (int)resultado;
        }
        public override String ToString()
        {
            return $"ID: {id} | Titulo: {titulo} | Prioridade: {prioridade} | Conclusão: {porcentagem_conclusao}% | Data Criação: {dt_criacao} " +
            $"{(dt_conclusao != new DateTime(1900, 1, 1) ? $" | Data Conclusão: {dt_conclusao}" : "")}\n{ctrlObjetivos.ToString(id)}";
        }
    }
}
