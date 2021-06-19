using Controle_de_Tarefas.Controladores;
using System;

namespace Controle_de_Tarefas.Dominio
{
    public class Tarefa : Entidade
    {
        public readonly ControladorObjetivos ctrlObjetivos = new ControladorObjetivos();
        public Tarefa(uint prioridade, String titulo)
        {
            this.prioridade = prioridade;
            this.titulo = titulo;
            porcentagem_conclusao = 0;
            dt_criacao = DateTime.Now;
        }
        public int porcentagem_conclusao { get; private set; }
        public DateTime dt_criacao { get; private set; }
        public DateTime dt_conclusao { get; private set; }
        public string titulo;
        public uint prioridade;
        public void atualizaConclusao()
        {
            var objetivos = ctrlObjetivos.Registros;
            var concluidos = objetivos.FindAll(x => x.finalizado);
            porcentagem_conclusao = concluidos.Count / objetivos.Count * 100;
        }
        public void concluiTarefa()
        {
            atualizaConclusao();
            if (porcentagem_conclusao == 100)
                dt_conclusao = DateTime.Now;
        }
        public override String ToString()
        {
            return $"ID: {id} | Titulo: {titulo} | Prioridade: {prioridade} | Conclusão: {porcentagem_conclusao}% | Data Criação: {dt_criacao} " +
            $"{(dt_conclusao != DateTime.MinValue ? $" | Data Conclusão: {dt_conclusao}" : "")}\n{ctrlObjetivos}";
        }
    }
}
