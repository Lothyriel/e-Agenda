using e_Agenda.Controladores;
using e_Agenda.Dominio;
using System;
using System.Windows.Forms;

namespace WindowsForms.Tarefas
{
    public partial class CadastrarTarefas : Form
    {
        ControladorTarefas controlador;
        public CadastrarTarefas(ControladorTarefas controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
        }

        private void tbar_percentual_Scroll(object sender, EventArgs e)
        {
            lb_percentual.Text = tbar_prioridade.Value.ToString();
        }
        private void bt_cadastrar_Click(object sender, EventArgs e)
        {
            Tarefa tarefa = new Tarefa(tbar_prioridade.Value, tb_titulo.Text);
            validar(tarefa);
        }
        private void validar(Tarefa tarefa)
        {
            string validacao = tarefa.validar();
            if (validacao == "ESTA_VALIDO")
            {
                controlador.inserir(tarefa);
                Dispose();
            }
            else
                MessageBox.Show(validacao);
        }
    }
}
